using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerFeedbackService.Data;
using CustomerFeedbackService.Models;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace CustomerFeedbackService.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class CustomerFeedbackController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        public CustomerFeedbackController (AppDbContext dbContext)
        {
             _dbcontext=dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerFeedback>>> GetAll()
        {
            return Ok(await _dbcontext.CustomerFeedbacks.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerFeedback>> GetById (int id)
        {
            var feedback = await _dbcontext.CustomerFeedbacks.FindAsync(id);
            if(feedback==null)
            return NotFound();
            return feedback;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerFeedback>> Create(CustomerFeedback feedback)

        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            _dbcontext.CustomerFeedbacks.Add(feedback);
            await _dbcontext.SaveChangesAsync();
            return CreatedAtAction (nameof(GetById), new {id=feedback.Id}, new
            {
                message="Feedback Submitted Successfully.",
                data=feedback
            });
        }    


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerFeedback feedback)
        {
        if(id != feedback.Id)
                return BadRequest("No Valid ID found.");
            var existing = await _dbcontext.CustomerFeedbacks.FindAsync(id);

        if (existing == null)
            
                return NotFound("Feedback Not Found.");
                existing.CustomerName=feedback.CustomerName;
                existing.Ratings=feedback.Ratings;
                existing.FeedbackComment=feedback.FeedbackComment;
           
        await _dbcontext.SaveChangesAsync();

        return Ok(new
        {
            message="Feedback Updated Successfully.",
            data = existing
        });

        
    }
     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(int id)
        {
            var feedback =await _dbcontext.CustomerFeedbacks.FindAsync(id);
            if(feedback==null)
            return NotFound("Feedback Not Found.");
            _dbcontext.CustomerFeedbacks.Remove(feedback);
            await _dbcontext.SaveChangesAsync();

            return Ok(new
            {
                message="Feedback Deleted Successfully.",
                deleted_Id=id
            });
        }
}}