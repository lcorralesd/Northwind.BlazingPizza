using Northwind.BlazingPizza.ViewModels;
using Northwind.BlazingPizza.Proxies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddViewModels();
builder.Services.AddProxies(
    getSpeciaslProxyHttpClient =>
    { 
        string webApiUri = builder.Configuration["BlazingPizzaOptions:WebApiBaseAddress"];
        getSpeciaslProxyHttpClient.BaseAddress = new Uri(webApiUri);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
