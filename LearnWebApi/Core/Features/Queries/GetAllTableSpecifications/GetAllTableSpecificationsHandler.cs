using System.Text.Json;
using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.GetListTableSpecifications;

public class GetAllTableSpecificationsHandler : IRequestHandler<GetAllTableSpecificationsQuery, Object>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;

    public GetAllTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }

    public async Task<Object> Handle(GetAllTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
        List<TableSpecification> tableSpecifications = _tableSpecificationRepository.GetAll();

        if (tableSpecifications is null)
            return new List<TableSpecification>();

        return tableSpecifications;
    }
}