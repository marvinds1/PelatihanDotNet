using System;
using Core.Features.Queries.CreateTableSpecification;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.Models;
using Persistence.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Features.Queries.CreateTableSpecification
{
	public class CreateTableSpecificationHandler : IRequestHandler<CreateTableSpecificationQuery, Object>
    {

        private readonly ITableSpecificationRepository _tableSpecificationRepository;

        public CreateTableSpecificationHandler(ITableSpecificationRepository tableSpecificationRepository)
        {
            _tableSpecificationRepository = tableSpecificationRepository;
        }

        public async Task<Object> Handle(CreateTableSpecificationQuery query, CancellationToken cancellationToken)
        {
            List<TableSpecification> tableSpecifications = new List<TableSpecification>();

            foreach (DetailTable q in query.ListTable.ToList())
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

            _tableSpecificationRepository.AddBatch(tableSpecifications);

            return tableSpecifications;
        }
    }
}



