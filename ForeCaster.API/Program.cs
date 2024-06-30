using ForeCaster.API;
using ForeCaster.API.Adapters.OpenMeteo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpCacheHeaders();
builder.Services.AddCache(builder.Configuration, []);

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IMeteoApiClient, MeteoApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.MapControllers();
app.Run();