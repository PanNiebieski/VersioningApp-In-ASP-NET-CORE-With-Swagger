using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using SimpleExample01.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//Here
builder.Services.AddApiVersioning
    (options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
           
            options.DefaultApiVersion = ApiVersion.Default;
            options.ApiVersionReader = new HeaderApiVersionReader("My-Version");

            //options.ApiVersionReader = ApiVersionReader.Combine(
            //        new HeaderApiVersionReader("My-Version"),
            //        new MediaTypeApiVersionReader("version")
            //);

            options.ReportApiVersions = true;

        }
    );



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
