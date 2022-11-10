using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Products.GetAll
{
    public class GetlAllRequestHandler : IRequestHandler<GetlAllRequest, IEnumerable<GetlAllResponse>>
    {
        public readonly IApiSerilogBdContext _context;
        public GetlAllRequestHandler(IApiSerilogBdContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetlAllResponse>> Handle(GetlAllRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);

            return products.Select(x => new GetlAllResponse(x.Id, x.Name, x.Description));
        }
    }
}
