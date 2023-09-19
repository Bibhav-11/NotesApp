using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NotesApp.Data;
using NotesApp.Interface;
using NotesApp.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NoteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesDb"));
});
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteLabelRepository, NoteLabelRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://127.0.0.1:5173"));
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
