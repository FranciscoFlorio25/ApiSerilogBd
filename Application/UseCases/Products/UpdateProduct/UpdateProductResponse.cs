using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Products.UpdateProduct
{
    public record UpdateProductResponse(string Name, string Description);
}