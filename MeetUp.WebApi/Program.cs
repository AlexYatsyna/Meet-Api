using MeetUp.Infrastructure;
using MeetUp.Logic;
using MeetUp.Logic.Interfaces;
using MeetUp.Logic.Mapping;
using System.Reflection;

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
        var context = serviceProvider.GetRequiredService<EventDbContext>();
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
    services.AddRazorPages();
    services.AddControllers();
    services.AddAutoMapper(conf =>
        {
            conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            conf.AddProfile(new AssemblyMappingProfile(typeof(IEventDbContext).Assembly));
        });
    services.AddLogic();
    services.AddDB(configuration.GetConnectionString("connectionString1"));
    services.AddCors(opt =>
    {
        opt.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });
}

void ConfigureMiddleWare(WebApplication app)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseCors("AllowAll");
    app.MapControllers();

    app.MapRazorPages();

}