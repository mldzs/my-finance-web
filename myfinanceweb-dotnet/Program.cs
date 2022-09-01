using myfinance_web_netcore.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

CreateDalInstance(app);

app.Run();

void CreateDalInstance(WebApplication app)
{
    IConfiguration configuration = app.Configuration;
    DAL.Configuration = configuration;
    var objDAL = DAL.GetInstance;
    // objDAL.Connect();
    // objDAL.ExecuteSqlCommand("INSERT INTO PLANO_CONTAS(DESCRICAO, TIPO) VALUES('Luz', 'D'");
}
