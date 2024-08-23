using MediatR;

namespace Core.Features.Queries.GetTableSpecificationsRedis;

public class GetTableSpecificationsRedisQuery : IRequest<GetTableSpecificationsRedisResponse>
{
    public Guid TableSpecificationId { get; set; }
}