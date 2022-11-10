using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Products.GetAll
{
    public record GetlAllRequest : IRequest<IEnumerable<GetlAllResponse>>;

}
