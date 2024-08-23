﻿using System.Text.Json;
using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.GetAllTableSpecificationsRedis;

public class GetListTableSpecificationsHandler : IRequestHandler<GetAllTableSpecificationsRedisQuery, Object>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;
    private readonly ICacheService _cacheService;

    public GetListTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository, ICacheService cacheService)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
        _cacheService = cacheService;
    }

    public async Task<Object> Handle(GetAllTableSpecificationsRedisQuery query, CancellationToken cancellationToken)
    {
        List<TableSpecification>? tableSpecifications = _cacheService.Get<TableSpecification>("tableSpecifications");
        if (tableSpecifications is null)
        {
            if (_cacheService.CheckActive())
            {
                List<TableSpecification> specifications = _tableSpecificationRepository.GetAll();
                _cacheService.Add("tableSpecifications", specifications);
            }
            tableSpecifications = _tableSpecificationRepository.GetAll();
        }

        if (tableSpecifications is null)
            return new List<TableSpecification>();

        return tableSpecifications;
    }
}