using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Overload.Pim.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        public CreateProductCommandHandler()
        {

        }

        public Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
