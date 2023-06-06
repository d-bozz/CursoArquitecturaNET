using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using HealthChecks.UI.Client;
using Services.WebApi.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddValidator();
builder.Services.AddHealthCheck(builder.Configuration);

var app = builder.Build();

// configure the Http request pipeline
if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
// build a swagger endpoint for each discovered API version
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
foreach (var description in provider.ApiVersionDescriptions)
{
c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
}
});
}

app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
Predicate = _ => true,
ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();

public partial class Program { };