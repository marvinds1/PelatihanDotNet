using MediatR;

namespace Core.Features.Queries.CreateTableSpecificationRedis
{
    public class CreateTableSpecificationRedisQuery : IRequest<Object>
    {
        public List<DetailTableRedis> ListTable { get; set; }
    }

    public class DetailTableRedis
    {
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public string TablePic { get; set; }
        public string Type { get; set; }
    }
}
