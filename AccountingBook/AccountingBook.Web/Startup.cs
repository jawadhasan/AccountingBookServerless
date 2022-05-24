using AccountingBook.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AccountingBook.Web
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      //Db setup
      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddScoped<Repository>();
      services.AddCors();
      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
		      //add this at the start of Configure
      //app.Use(async (HttpContext context, Func<Task> next) =>
      //{
      //  await next.Invoke();

      //  if (context.Response.StatusCode == 404 && !context.Request.Path.Value.Contains("/api"))
      //  {
      //    context.Request.Path = new PathString("/index.html");
      //    context.Response.StatusCode = 200;
      //    await next.Invoke();
      //  }
      //});
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //app.UseDefaultFiles();
      //app.UseStaticFiles();

      // global cors policy
      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseRouting();

      app.UseAuthorization();


      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
