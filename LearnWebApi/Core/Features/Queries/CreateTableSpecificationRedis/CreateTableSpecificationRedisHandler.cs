using System;
using Core.Features.Queries.CreateTableSpecificationRedis;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.CreateTableSpecificationRedis
{
    public class PostListTableSpecificationsHandler : IRequestHandler<CreateTableSpecificationRedisQuery, Object>
    {
        private readonly ITableSpecificationRepository _tableSpecificationRepository;
        private readonly ICacheService _cacheService;

        public PostListTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository, ICacheService cacheService)
        {
            _tableSpecificationRepository = tableSpecificationRepository;
            _cacheService = cacheService;
        }

        public async Task<Object> Handle(CreateTableSpecificationRedisQuery query, CancellationToken cancellationToken)
        {
            List<TableSpecification> tableSpecifications = new List<TableSpecification>();
            foreach (DetailTableRedis q in query.ListTable.ToList())
            {
                var newTable = new TableSpecification()
                {
                    TableId = Guid.NewGuid(),
                    TableNumber = q.TableNumber,
                    ChairNumber = q.ChairNumber,
                    TablePic = q.TablePic,
                    TableType = q.Type
                };

                tableSpecifications.Add(newTable);
            }

            await _tableSpecificationRepository.AddBatch(tableSpecifications);

            if (_cacheService.CheckActive())
            {
                List<TableSpecification> specifications = _tableSpecificationRepository.GetAll();
                _cacheService.Remove("tableSpecifications");
                _cacheService.Add("tableSpecifications", specifications);
            }

            return tableSpecifications;
        }
    }
}