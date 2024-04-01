using Auth.Application;
using Auth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure()
        .AddPersistance(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler();

    //if (app.Environment.IsDevelopment())
    //{
        app.UseSwagger();
        app.UseSwaggerUI();
    //}

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}