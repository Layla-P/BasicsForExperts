using BasicsForExperts.Web.Extensions;
using BasicsForExperts.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>()
                .AddCommandLine(args)
                .Build();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding dependencies
builder.Services.AddHttpClient<WaffleIngredientService>();
builder.Services.AddSingleton<IWaffleCreationService, WaffleCreationService>();


//builder.Services.AddDependencies();
//builder.Services.AddCustomSerializers();
//builder.Services.AddClientsAndPolicies(); 
//builder.Services.AddServiceDiscovery();

builder.Services.AddDatabases(Configuration);

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

using (var scope = app.Services.CreateScope())
{
    var waffleCreationService = scope.ServiceProvider.GetRequiredService<IWaffleCreationService>();
    var response = await waffleCreationService.StartWaffleCreation();

    app.MapGet("/GetWaffleToppings", () => new { ingredients = response.toppings, bases = response.bases });

}

//await app.AddApisAsync();
//app.AddEurekaApi();

app.Run();

