using Application.UseCases.Products.CreateProduct;
using Application.UseCases.Products.GetAll;
using Application.UseCases.Products.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiSerilogBd.Api.Routes.ProductRoutes
{
    public static class ProductsRoutes
    {
        public static IEndpointRouteBuilder MapProducts(this IEndpointRouteBuilder builder)
        {
            builder.MapGet(pattern: "/Products", async ([FromServices] IMediator mediator)
                => Results.Ok(await mediator.Send(request: new GetlAllRequest())))
                .WithName(endpointName: "GetProducts")
                .Produces<IEnumerable<GetlAllResponse>>(StatusCodes.Status200OK, contentType: "application/json");

            builder.MapPost(pattern: "/Products", async ([FromServices] IMediator mediator, [FromBody] CreateProductRequest request)
                => Results.Ok(await mediator.Send(request)))
                .WithName(endpointName: "CreateProducts")
                .Produces<CreateProductRequest>(StatusCodes.Status200OK, contentType: "application/json");

            builder.MapPut(pattern: "/Products/Update", async ([FromServices] IMediator mediator, [FromBody] UpdateProductRequest request)
                => Results.Ok(await mediator.Send(request)))
                .WithName(endpointName: "UpdateProduct")
                .Produces<UpdateProductRequest>(StatusCodes.Status200OK, contentType: "application/json");

            return builder;
        }
    }
}
