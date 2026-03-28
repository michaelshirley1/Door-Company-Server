using BusinessApi.Factories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title   = "Door API",
        Version = "v1",
        Description = "REST API exposing Job, Invoice, Order and Quote resources."
    });
});

builder.Services.AddScoped<IJobFactory,     JobFactory>();
builder.Services.AddScoped<IInvoiceFactory, InvoiceFactory>();
builder.Services.AddScoped<IOrderFactory,   OrderFactory>();
builder.Services.AddScoped<IQuoteFactory,   QuoteFactory>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Business API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
