using CheckNationalCode.Core.ApplicationServices.Users;
using CheckNationalCode.Core.Domain.Users;
using CheckNationalCode.Endpoint.Rest.Middlewares;
using InfraStructures.Data.EF.SqlServer.Common;
using InfraStructures.Data.EF.SqlServer.RequestUser;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IRequestUserRepository, RequestUserRepository>();
builder.Services.AddDbContext<RequestUserContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Request"));
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("nationalcode", typeof(MelliCodeConstraint));
});
var app = builder.Build();
app.UseStaticFiles();

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext context) =>
{
    context.Response.StatusCode = 500;
    context.Response.ContentType = "text/html";
    return Results.File("wwwroot/error.html", "text/html");
});
app.MapGet("/users/{nationalCode:nationalcode}", (string nationalCode, IRequestUserRepository requestUserRepository) =>
{
    var entity = new RequestUser
    {
        Request = nationalCode
    };
    requestUserRepository.Add(entity);
    if (nationalCode.Length == 10)
        return Results.Ok($"Melli Code Is Valid: {nationalCode}");
    if (nationalCode.Length == 11)
        return Results.Ok($"Legal Code Is Valid: {nationalCode}");
    else
        return Results.BadRequest("Melli Code Is Not Valid");
});
app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Melli Code Is Not Valid");
});
app.Run();
