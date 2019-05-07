using MediatR;

namespace Overload.Pim.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
