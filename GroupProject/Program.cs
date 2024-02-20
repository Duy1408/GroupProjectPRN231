
using Newtonsoft.Json;
using Repo;
using Repo.Interface;
using Service;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
      );



builder.Services.AddTransient<IRealEstateRepo,RealEstateRepo>();
builder.Services.AddTransient<IRealEstateService, RealEstateService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
