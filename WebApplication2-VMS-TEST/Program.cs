using WebApplication2_VMS_TEST.Models;
using WebApplication2_VMS_TEST.Interfaces;
using WebApplication2_VMS_TEST.Repository;
using Microsoft.EntityFrameworkCore;
using WebApplication2_VMS_TEST.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVehicleRepository,VehicleRepository>();
builder.Services.AddScoped<IDailyActivityRepository,DailyActivityRepository>();
builder.Services.AddScoped<IMaintenanceExpenseRepository,MaintenanceExpenseRepository>();
builder.Services.AddScoped<IDashBoardRepository,DashBoardRepository>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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

app.Run();

//UserModel user = new UserModel()
//{
//    UserId = 1,
//    Username = "VMSTest1",
//    Password = "password",
//};

//DataContext dc = new DataContext();

//dc.Users.Add(user);
//dc.SaveChanges();
//Console.WriteLine("Press Any Key To Continue");
//Console.ReadKey();