using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        public readonly IApiSerilogBdContext _context;
        public UpdateProductRequestHandler(IApiSerilogBdContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == request.Id, cancellationToken);

            Product updateProdcut = new(request.Name,request.Description);

            product.Name = request.Name;
            product.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateProductResponse(request.Name, request.Description);
        }
    }
}
