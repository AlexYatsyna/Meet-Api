using MeetUp.Infrastructure;
using MeetUp.Logic;
using MeetUp.Logic.Interfaces;
using MeetUp.Logic.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    services.AddAuthentication(conf =>
    {
        conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer("Bearer", opt =>
    {
        opt.Authority = "http://localhost:2387";
        opt.Audience = "MeetUpWebApi";
        opt.RequireHttpsMetadata = false;
    });
    services.AddSwaggerGen(conf =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        conf.IncludeXmlComments(xmlPath);
    });
}

void ConfigureMiddleWare(WebApplication app)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(conf =>
    {
        conf.RoutePrefix = "";
        conf.SwaggerEndpoint("swagger/v1/swagger.json", "MeetUp Web Api");
    });
    app.UseRouting();
    app.UseCors("AllowAll");
    app.UseAuthentication();
    app.UseAuthorization(); 
    app.MapControllers();

    app.MapRazorPages();

}