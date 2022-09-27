using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args); // Setup host

// Add services to the container.

builder.Services.AddControllers(options => {
    // Configure basic API behaviors
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters(); // Add XML input and output formatters
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline. (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); // Personal preference 
// app.MapControllers(); Can be used instead of line immediately above (new for version 6)

app.Run();
