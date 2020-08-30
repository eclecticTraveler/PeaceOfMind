using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeaceOfMind.API.Handlers;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.API.Factory;

namespace PeaceOfMind.API.Controllers
{
    //[Route("api/v1/[controller]")]
    [Route("api/v1/surveys")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        // GET api/v1/surveys
        [HttpGet]
        public IActionResult Get()
        {     
            ISurveyHandler surveyHandler = ApiFactory.CreateSurveyHandler();
            var surveys = surveyHandler.GetAvailableSurveys();
            //var ee = JsonConvert.SerializeObject(surveys);
            return Ok(surveys);
        }

        // GET api/v1/surveys/
        [HttpGet("{surveyId}")]
        public IActionResult Get(int surveyId)
        {
            // Here we are sending back the specific question within a survey
            return Ok(surveyId);
        }

        // GET api/v1/surveys/1/questions
        [HttpGet("{surveyId}/questions")]
        public IActionResult GetQuestions(int surveyId)
        {
            ISurveyHandler surveyHandler = ApiFactory.CreateSurveyHandler();
            var surveyQuestions = surveyHandler.GetSurveyQuestions(surveyId);
            
            if (surveyQuestions == null)
            {
                return NotFound();
            }
            return Ok(surveyQuestions);
        }

        // POST api/v1/surveys/1/answers
        [HttpPost("{surveyId}/answers")]
        public IActionResult Post(int surveyId, [FromBody] IEnumerable<AnswerDto> answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ISurveyHandler surveyHandler = ApiFactory.CreateSurveyHandler();
            var result = surveyHandler.ProcessSurveyAnswers(surveyId, answers);
            return CreatedAtAction(nameof(answers), answers);
        }

        //[HttpGet("{surveyId}/results")]
        //[HttpPost]
        //public IActionResult Post([FromBody] IEnumerable<AnswerDto> answers)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    ISurveyHandler surveyHandler = ApiFactory.CreateSurveyHandler();
        //    var surveyQuestions = surveyHandler.GetSurveyQuestions(1);

        //    return Ok();
        //}

        // TODO: GET for scale results based on date (maybe on a different controller)

    }
}