using Microsoft.EntityFrameworkCore;
using CustomerFeedbackService.Data;

var builder= WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlite("Data Source=customerfeedback.db")
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();