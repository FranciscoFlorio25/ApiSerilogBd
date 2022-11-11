using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Products.CreateProduct
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public readonly IApiSerilogBdContext _context;
        public readonly ILogger<CreateProductRequestHandler> _logger;
        public CreateProductRequestHandler(IApiSerilogBdContext context, ILogger<CreateProductRequestHandler> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name, request.Description);

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogWarning("File Was created");

            return new CreateProductResponse(product.Name,product.Description);
        }
    }
}
