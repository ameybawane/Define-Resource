var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();
builder.Services.AddControllers(x =>
{
    x.ReturnHttpNotAcceptable = true;
})
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.WriteIndented = true;
    })
    .AddXmlSerializerFormatters();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting();

app.UseEndpoints((x) =>
{
    x.MapControllers();

});
app.Run();
