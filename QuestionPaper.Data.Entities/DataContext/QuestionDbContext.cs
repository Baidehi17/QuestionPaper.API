using Microsoft.EntityFrameworkCore;
using QuestionPaper.Data.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPaper.Data.Entities.DataContext
{
    public class QuestionDbcontext:DbContext
    {
        public QuestionDbcontext() { }
        public QuestionDbcontext(DbContextOptions<QuestionDbcontext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TL217;Database=questionDbContext;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<questionDetails>()
                .HasMany(b => b.subQuestions)
                .WithOne(b => b.questionDetails)
                .HasForeignKey(b => b.questionDetails_id);
        }
        public DbSet<questionDetails> questionDetails { get; set; }
        public DbSet<subQuestions> subQuestions { get; set; }
    }
}
