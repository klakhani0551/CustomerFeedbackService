using Microsoft.EntityFrameworkCore;
using CustomerFeedbackService.Models;

namespace CustomerFeedbackService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<CustomerFeedback> CustomerFeedbacks{get; set;}
        

    }
    
}