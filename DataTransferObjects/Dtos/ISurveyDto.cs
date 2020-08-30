namespace PeaceOfMind.DataMovement.Dtos
{
    public interface ISurveyDto
    {
        int SurveyId { get; set; }
        string SurveyName { get; set; }
        string SurveyApiPath { get; set; }
    }
}