using AcademicShare.Web.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NupsiSign.Models.DbSet;
using NupsiSign.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the Question service
builder.Services.AddSingleton<QuestionService>();

// Add the database context
builder.Services.AddDbContext<NupsiSignDbContext>(opts => opts.UseSqlServer(connectionString).UseLazyLoadingProxies().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

// Configure the password hasher to use 300,000 iterations
builder.Services.Configure<PasswordHasherOptions>(options => options.IterationCount = 300000);

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<NupsiSignDbContext>();

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

app.Run();