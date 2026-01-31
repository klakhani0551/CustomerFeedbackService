using System.ComponentModel.DataAnnotations;

namespace CustomerFeedbackService.Models
{
    public class CustomerFeedback
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }
        
        [StringLength(500)]
        public string FeedbackComment { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}