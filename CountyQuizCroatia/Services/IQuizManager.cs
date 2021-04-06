using CountyQuizCroatia.Models;

namespace CountyQuizCroatia.Services
{
    /// <summary>
    /// Manages the quiz logic
    /// </summary>
    public interface IQuizManager
    {
        County GiveMeACountyToGuess();
        int NumOfCountiesLeftToGuess();
        void ResetQuiz();
    }
}