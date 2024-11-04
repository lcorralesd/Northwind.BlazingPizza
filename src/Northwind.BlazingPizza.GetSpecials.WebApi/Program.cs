var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services from IOC to the container.
builder.Services.AddGetSpecialsServices(getSpecialsOptions =>
{
    builder.Configuration.GetRequiredSection(GetSpecialsOptions.SectionKey).Bind(getSpecialsOptions);
},
getSpecialsDBOptions =>
{
    builder.Configuration.GetRequiredSection(GetSpecialsDBOptions.SectionKey).Bind(getSpecialsDBOptions);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis:6379";
    options.InstanceName = "GetSpecials";
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet(Endpoints.GetSpecials, async(IGetSpecialsController controller) =>
{
    return TypedResults.Ok(await controller.GetSpecialsAsync());
});

app.UseCors();

app.InitializeDB();


app.Run();

