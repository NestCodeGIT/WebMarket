using Microsoft.EntityFrameworkCore;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Webmarket.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ApplicatonDbContext01Connection") ?? throw new InvalidOperationException("Connection string 'ApplicatonDbContext01Connection' not found.");

//builder.Services.AddDbContext<ApplicatonDbContext01>(options =>
//    options.UseSqlServer(connectionString));;



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicatonDbContext01>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefultConnection")
    ));



builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicatonDbContext01>(); 


builder.Services.AddScoped<ICoverTypeService, CoverTypeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ICopmanyService, CompanyService>();


builder.Services.AddRazorPages().AddRazorRuntimeCompilation();





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
app.UseAuthentication();;



app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
