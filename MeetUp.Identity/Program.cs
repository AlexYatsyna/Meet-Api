using MeetUp.Identity;
using MeetUp.Identity.DB;
using MeetUp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AuthDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

ConfigureMiddleWare(app);


app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{

    services.AddControllersWithViews();
    services.AddDbContext<AuthDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("connectionString1")));

    services.AddIdentity<AppUser, IdentityRole>(conf =>
    {
        conf.Password.RequiredLength = 8;
        conf.Password.RequireNonAlphanumeric = false;
        conf.Password.RequireUppercase = false;
    }).AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();
    services.AddIdentityServer()
        .AddAspNetIdentity<AppUser>()
        .AddInMemoryApiResources(Configuration.ApiResources)
        .AddInMemoryIdentityResources(Configuration.IdentityResources)
        .AddInMemoryApiScopes(Configuration.ApiScopes)
        .AddInMemoryClients(Configuration.Clients)
        .AddDeveloperSigningCredential();


    services.ConfigureApplicationCookie(conf =>
    {
        conf.Cookie.Name = "MeetUp.Identity.Cookie";
        conf.LoginPath = "/Auth/Login";
        conf.LogoutPath = "/Auth/Logout";
    });
}

void ConfigureMiddleWare(WebApplication app)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseIdentityServer();
    app.MapDefaultControllerRoute();

}