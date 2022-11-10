using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Products.GetAll
{
    public record GetlAllResponse(int id,string Name, string description);
}