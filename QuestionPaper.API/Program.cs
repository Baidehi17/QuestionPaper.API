
using Microsoft.EntityFrameworkCore;
using QuestionPaper.BLL.Implementation;
using QuestionPaper.BLL.Interface;
using QuestionPaper.Data.Entities.DataContext;
using QuestionPaper.Repository.Repository.Implimentation;
using QuestionPaper.Repository.Repository.Interface;

namespace QuestionPaper.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<QuestionDbcontext>(options
               => options.UseSqlServer(builder.Configuration.GetConnectionString("QuestionDbcontext")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddTransient<DriversDTO>();
            builder.Services.AddTransient<IQuestionDetailsDTO, QuestionDetailsDTO>();
            builder.Services.AddTransient<ISubQuestionDTO, SubQuestionDTO>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corspolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}