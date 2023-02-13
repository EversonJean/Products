using Application.AutoMapper;
using Application.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services
        .AddRouting(ops => ops.LowercaseUrls = true)
        .AddControllers()
        .AddNewtonsoftJson(opts =>
        {
            opts.SerializerSettings.Converters.Add(new StringEnumConverter());
            opts.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfiles());
});

var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new()
    {
        Title = "Products CRUD with Mongo DB",
        Version = "v1",
        Description = "Exemple Project with Mongo DB",
    });
});

builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddApplications();

var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(cultureInfo);
    options.SupportedCultures = new List<CultureInfo> { cultureInfo };
    options.SupportedUICultures = new List<CultureInfo> { cultureInfo };
    options.RequestCultureProviders.Clear();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
