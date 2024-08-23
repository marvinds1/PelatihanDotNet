using Core.Features.Queries.GetTableSpecificationsRedis;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace GetTableSpecificationsRedis;

public class GetTableSpecificationsRedisHandler : IRequestHandler<GetTableSpecificationsRedisQuery, GetTableSpecificationsRedisResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;
    private readonly ICacheService _cacheService;

    public GetTableSpecificationsRedisHandler(ITableSpecificationRepository tableSpecificationRepository, ICacheService cacheService)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
        _cacheService = cacheService;
    }

    public async Task<GetTableSpecificationsRedisResponse> Handle(GetTableSpecificationsRedisQuery query, CancellationToken cancellationToken)
    {
        List<TableSpecification>? tableSpecification = _cacheService.Get<TableSpecification>("tableSpecifications");
        if (tableSpecification is null)
        {
            if (_cacheService.CheckActive())
            {
                List<TableSpecification> specifications = _tableSpecificationRepository.GetAll();
                _cacheService.Add("tableSpecifications", specifications);
            }
            tableSpecification = new List<TableSpecification>
            { _tableSpecificationRepository.GetById(query.TableSpecificationId) };
        }

        var res = tableSpecification.Find(o => o.TableId.Equals(query.TableSpecificationId));


        if (tableSpecification is null)
            return new GetTableSpecificationsRedisResponse();

        var response = new GetTableSpecificationsRedisResponse()
        {
            TableId = res.TableId,
            ChairNumber = res.ChairNumber,
            TableNumber = res.TableNumber,
            TablePic = res.TablePic,
            TableType = res.TableType
        };

        return response;
    }
}