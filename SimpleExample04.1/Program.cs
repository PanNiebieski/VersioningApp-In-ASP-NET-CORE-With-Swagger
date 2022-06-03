using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//Here
builder.Services.AddApiVersioning
    (options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;

            //options.DefaultApiVersion = new ApiVersion(1, 1);
            options.DefaultApiVersion = ApiVersion.Default;
            options.ApiVersionReader = new MediaTypeApiVersionReader("version");
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
