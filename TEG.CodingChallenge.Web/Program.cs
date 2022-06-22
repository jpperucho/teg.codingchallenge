using TEG.CodingChallenge.Business.Interface.Repository;
using TEG.CodingChallenge.Business.Repository;
using TEG.CodingChallenge.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuration
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories.
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddSingleton<IVenueRepository, VenueRepository>();

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
