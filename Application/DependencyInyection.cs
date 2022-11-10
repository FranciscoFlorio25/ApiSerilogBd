using Application.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddMediatR(typeof(IApiSerilogBdContext));

            return service;
        }
    }
}
