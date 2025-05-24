using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Core.Interfaces.Repositries;
using TaskManagement.Core.Interfaces.Services;
using TaskManagement.Infrastructure.Repositries;
using TaskManagement.Core.Services;
using TaskManagement.Core.Interfaces.Servicies;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskManagement.Infrastructure.Validators;
using TaskManagement.Core.Dtos.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITaskRepositry, TaskRepositry>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserRepositry, UserRepositry>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddValidatorsFromAssemblyContaining<TaskSaveDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserSaveDto>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
