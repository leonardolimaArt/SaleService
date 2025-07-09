using Basket.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddStackExchangeRedisCache(options =>
{
    var conn = Environment.GetEnvironmentVariable("REDIS_URL") ?? builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");

    if (string.IsNullOrWhiteSpace(conn))
                throw new InvalidOperationException("REDIS_URL connection string not found.");

    options.Configuration = conn;
 
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

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
