using LearnWebApiMongo.Models;
using LearnWebApiMongo.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebApiMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly AnswerService _answerService;

        public AnswersController(AnswerService answerService)
        {
            _answerService = answerService;
        }

        //[HttpGet]
        //public ActionResult<List<Answer>> Get() =>
        //    _answerService.Get().OrderByDescending(s=>s.CreatedOn);


        [HttpGet]
        public ActionResult<List<Answer>> Get()
        {
            return _answerService.Get().OrderByDescending(s => s.CreatedOn).ToList();
        }

        [HttpGet("{id:length(24)}", Name = "GetAnswer")]
        public ActionResult<Answer> Get(string id)
        {
            var answer = _answerService.Get(id);

            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        [HttpPost]
        public ActionResult<Answer> Create(Answer answer)
        {
            answer.CreatedOn = DateTime.Now;
            answer.UpdatedOn = DateTime.Now;

            _answerService.Create(answer);

            return CreatedAtRoute("GetAnswer", new { id = answer.Id.ToString() }, answer);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Answer answerIn)
        {
            var answer = _answerService.Get(id);

            if (answer == null)
            {
                return NotFound();
            }

            _answerService.Update(id, answerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var answer = _answerService.Get(id);

            if (answer == null)
            {
                return NotFound();
            }

            _answerService.Remove(answer.Id);

            return NoContent();
        }
    }
}
