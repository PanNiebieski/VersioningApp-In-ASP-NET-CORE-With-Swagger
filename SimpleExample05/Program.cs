using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SimpleExample04;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//Here
builder.Services.AddApiVersioning
    (options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            //options.DefaultApiVersion = new ApiVersion(1, 1);
            //options.DefaultApiVersion = ApiVersion.Default;

     
        }
    );

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'Wersja 'VVV";
    setup.SubstituteApiVersionInUrl = true;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(
            options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
                }
            }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
