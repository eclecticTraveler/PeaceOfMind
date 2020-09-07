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
        private ISurveyHandler _surveyHandler;

        public SurveyController(ISurveyHandler surveyHandler)
        {
            _surveyHandler = surveyHandler;
        }
        // GET api/v1/surveys
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var surveys = _surveyHandler.GetAvailableSurveys();
                return Ok(surveys);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/surveys/
        [HttpGet("{surveyId}")]
        public IActionResult Get(int surveyId)
        {
            try
            {
                // TODO: What are you going to send back? Maybe info about that survey
                return Ok(surveyId);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/surveys/1/questions
        [HttpGet("{surveyId}/questions")]
        public IActionResult GetQuestions(int surveyId)
        {
            try
            {
                var surveyQuestions = _surveyHandler.GetSurveyQuestions(surveyId);

                if (surveyQuestions == null)
                {
                    return NotFound(surveyId);
                }
                return Ok(surveyQuestions);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/v1/surveys/1/answers
        [HttpPost("{surveyId}/answers")]
        public IActionResult Post(int surveyId, [FromBody] IEnumerable<AnswerDto> answers)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = _surveyHandler.ProcessSurveyAnswers(surveyId, answers);
                return Created(nameof(answers), result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
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