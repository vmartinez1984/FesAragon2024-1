using Banca.Bl;
using Banca.Entities;
using Banca.Helpers;
using Banca.Repositorios.CodigosPostales;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<BancaContext>();
builder.Services.AddScoped<CodigoPostalRepo>();
builder.Services.AddScoped<CodigoPostalBl>();
builder.Services.AddScoped<ClienteBl>();
builder.Services.AddScoped<AhorroBl>();
builder.Services.AddScoped<TransaccionBl>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddControllersWithViews();

//swagger
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    )
);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FiltroDeExcepcion));
});

//builder.Host.UseSerilog((hostContext, services, configuration) =>
//{
//    configuration.ReadFrom.Configuration(hostContext.Configuration);
//});

var app = builder.Build();

//swagger
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowWebApp");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
