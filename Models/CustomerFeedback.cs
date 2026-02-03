using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;

namespace CustomerFeedbackService.Models
{
    public class CustomerFeedback
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        public int Phone {get; set;}

        [Range(1, 5)]
        public double Rating { get; set; }
        
        [StringLength(500)]
        public string FeedbackComment { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}