using CountyQuizCroatia.Models;

namespace CountyQuizCroatia.Services
{
    public interface IQuizManager
    {
        County GiveMeACountyToGuess();
        int NumOfCountiesLeftToGuess();
        void ResetQuiz();
    }
}