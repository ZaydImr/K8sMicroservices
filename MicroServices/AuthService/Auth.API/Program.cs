using Auth.Application;
using Auth.Domain.Models;
using Auth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure()
        .AddPersistance(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers().RequireAuthorization();
    app.MapGroup("api").MapIdentityApi<AppUser>().AllowAnonymous();

    app.Run();
}