using Microsoft.EntityFrameworkCore;
using SendingSMS.Model;
using SendingSMS.Model.Repository;
using SendingSMS.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration["ConnectionStrings:SqlServer"];
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));  
builder.Services.AddScoped<IContactRepository , ContactRepository>();   
builder.Services.AddScoped<IShortLinkService , ShortLinkService>();   
builder.Services.AddScoped<IMessageService , MessageService>();   

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
