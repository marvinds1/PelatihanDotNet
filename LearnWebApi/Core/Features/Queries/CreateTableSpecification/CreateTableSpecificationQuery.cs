using MediatR;

namespace Core.Features.Queries.CreateTableSpecification
{
    public class CreateTableSpecificationQuery : IRequest<Object>
    {
        public List<DetailTable> ListTable { get; set; }
    }

    public class DetailTable
    {
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public string TablePic { get; set; }
        public string Type { get; set; }
    }
}
