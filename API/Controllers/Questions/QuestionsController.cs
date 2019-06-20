using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.QuestionDTO;
using API.Models;
using API.Services.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Questions
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service, educoursedbContext context)
        {
            _service = service;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestion()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetQuestionsAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDTO questionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddQuestionAsync(questionDTO);
            // return Ok(result);
            //return CreatedAtAction("GetQuestion", new { id = questionsDTO.Id }, questionsDTO);
            return Ok(result);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _service.FindQuestionAsync(id);
            if (question == false)
            {
                return NotFound();
            }

            await _service.DeleteQuestionAsync(id);

            return Ok(question);
        }
    }
}