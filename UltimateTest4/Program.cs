using NLog;
using UltimateTest4.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Builder;
using Contracts;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/Nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

// to close apicontroller attribute to make our custom response for bad requests.
builder.Services.Configure<ApiBehaviorOptions>(options =>{options.SuppressModelStateInvalidFilter = true;});

//we make content negotiation that lets you choose or rather “negotiate” the 
//content you want to get in a response to the REST API request. 
//By default, ASP.NET Core Web API returns a JSON formatted result.
//to change this we need to configure server formatters to format a response the way we want it.
//A server does not explicitly specify where it formats a response to JSON
//But you can override it by changing configuration options through the AddControllers method. 
//We can add the AddXmlDataContractSerializerFormatters() to enable the server to format the XML response when the client tries negotiating for it:
/*builder.Services.AddControllers(config => { config.RespectBrowserAcceptHeader = true;})
   .AddXmlDataContractSerializerFormatters()
   .AddApplicationPart(typeof(PresentationLayer4.AssemblyReference).Assembly);*/
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
