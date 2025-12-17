using ERP_V5_Application.Authentication.Commands.RegisterUser;
using ERP_V5_Application.Behaviours;
using ERP_V5_Application.Products.Commands.CreateProduct;
using ERP_V5_Infrastructure;
using ERP_V5_Infrastructure.Identity;
using ERP_V5_Infrastructure.Identity.Seed;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// add layers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Infrastructure (DbContext + Identity)
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddMediatR(cfg =>
{

    cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommand>();        // Application
    cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommandHandler>(); // Infrastructure
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
});
builder.Services.AddValidatorsFromAssembly(typeof(CreateProductCommand).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));


// Application (MediatR etc.) will be added in Step 2
// builder.Services.AddApplication(...);
var app = builder.Build();

#region SeedData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManger = services.GetRequiredService<RoleManager<ApplicationRole>>();
    await IdentitySeeder.SeedAsync(userManager, roleManger);
}
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// JWT middleware comes in Step 2
app.UseHttpsRedirection();
app.UseAuthentication(); // will be effective after Step 2
app.UseAuthorization();

app.MapControllers();

app.Run();
