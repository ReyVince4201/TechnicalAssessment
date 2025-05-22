using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Bogus;
using UserIdentityApi.Data;
using UserIdentityApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
builder.Services.AddDbContext<UserIdentityContext>(opt =>
    opt.UseInMemoryDatabase("User Identities"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "User  Identity API",
        Version = "v1",
        Description = "An API to manage user identity profiles"
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

var optionsBuilder = new DbContextOptionsBuilder<UserIdentityContext>();
optionsBuilder.UseInMemoryDatabase("User Identities");
optionsBuilder.EnableSensitiveDataLogging(); 


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserIdentityContext>();

  
    if (!db.UserIdentities.Any(u => u.Id == 1))
    {
        db.UserIdentities.Add(new UserIdentity
        {
            Id = 1,
            UserId = "user1",
            FullName = "John Doe",
            Email = "john.doe@example.com",
            SourceSystem = "SystemA",
            LastUpdated = DateTime.UtcNow,
            IsActive = true
        });
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User  Identity API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularDevClient");
app.MapControllers();
app.Run();
