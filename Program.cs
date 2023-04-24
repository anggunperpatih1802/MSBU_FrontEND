using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MVCCallWebAPI_ANGGUN.Models.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DB_Demo_APIContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DB_Demo_APIConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var db_demo_apicontext = service.GetService<DB_Demo_APIContext>();

}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Enable middleware to serve generated Swagger as a JSON endpoint.        
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),        
// specifying the Swagger JSON endpoint.        
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=tr_bpkbMVCCallWebAPI}/{action=Index}/{id?}");

app.Run();
