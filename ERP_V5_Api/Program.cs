using ERP_V5_Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// add layers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure (DbContext + Identity)
builder.Services.AddInfrastructure(builder.Configuration);

// Application (MediatR etc.) will be added in Step 2
// builder.Services.AddApplication(...);

var app = builder.Build();

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
