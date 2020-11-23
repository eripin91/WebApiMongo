using LearnWebApiMongo.Models;
using LearnWebApiMongo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebApiMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly SurveyService _surveyService;

        public SurveysController(SurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public ActionResult<List<Survey>> Get() =>
            _surveyService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSurvey")]
        public ActionResult<Survey> Get(string id)
        {
            var survey = _surveyService.Get(id);

            if (survey == null)
            {
                return NotFound();
            }

            return survey;
        }

        [HttpGet("{id:int}")]
        public ActionResult<List<Survey>> GetSurveyByPage(int id)
        {
            var survey = _surveyService.Get(id);

            if (survey == null)
            {
                return NotFound();
            }

            return survey;
        }
        
        [HttpPost]
        public ActionResult<Survey> Create(Survey survey)
        {
            _surveyService.Create(survey);

            return CreatedAtRoute("GetSurvey", new { id = survey.Id.ToString() }, survey);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Survey surveyIn)
        {
            var survey = _surveyService.Get(id);

            if (survey == null)
            {
                return NotFound();
            }

            _surveyService.Update(id, surveyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var survey = _surveyService.Get(id);

            if (survey == null)
            {
                return NotFound();
            }

            _surveyService.Remove(survey.Id);

            return NoContent();
        }
    }
}
