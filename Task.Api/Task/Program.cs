using Application.Common.Helper;
using Infrastructure;
using Services.IServices;
using Services.Services;
using System.Text.Json.Serialization;
using Task.Middlewares;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    //after done mapping stop this section
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.WriteIndented = false;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<ICategoreyServices, CategoreyServices>();
builder.Services.AddScoped<ISubCategoreyServices, SubCategoreyServices>();
builder.Services.AddHttpClient<IStackOverflowApiService, StackOverflowApiService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
