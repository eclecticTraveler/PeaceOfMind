using PeaceOfMind.API.Handlers;
using PeaceOfMind.Service.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.API.Factory
{
    public class ApiFactory
    {
        public static ISurveyHandler CreateSurveyHandler()
        {
            return new SurveyHandler();
        }

        public static ISurveyManager CreateSurveyManager()
        {
            return new SurveyManager();
        }
    }
}
