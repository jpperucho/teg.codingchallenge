using TEG.CodingChallenge.Business.Interface.Manager;
using TEG.CodingChallenge.Business.Interface.Repository;
using TEG.CodingChallenge.Business.Manager;
using TEG.CodingChallenge.Business.Repository;
using TEG.CodingChallenge.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuration
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));

// Setup controllers.
builder.Services.AddControllers();

// Setup CORS.
builder.Services.AddCors(o =>
{
    o.AddPolicy("default", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mannagers.
builder.Services.AddSingleton<IVenueManager, VenueManager>();
builder.Services.AddSingleton<IEventManager, EventManager>();

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

app.UseCors("default");

app.MapControllers();

app.Run();
