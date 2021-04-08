using CountyQuizCroatia.Models;
using CountyQuizCroatia.Services;
using Stylet;

namespace CountyQuizCroatia.ViewModels
{
    /// <summary>
    /// Quiz game mode
    /// <para>(Get a county name and try to find it on the map)</para>
    /// </summary>
    public class QuizViewModel : Screen
    {
        private readonly IQuizManager _quizManager;

        private County _countyToGuess;
        public County CountyToGuess
        {
            get { return _countyToGuess; }
            set { SetAndNotify(ref _countyToGuess, value); }
        }

        private int _leftToGuess;
        public int LeftToGuess
        {
            get { return _leftToGuess; }
            set { SetAndNotify(ref _leftToGuess, value); }
        }

        private int _wrongGuesses;
        public int WrongGuesses
        {
            get { return _wrongGuesses; }
            set { SetAndNotify(ref _wrongGuesses, value); }
        }

        private bool IsQuizOver;

        public QuizViewModel(IQuizManager quizManager)
        {
            _quizManager = quizManager;
        }

        /// <summary>
        /// Resets quiz progress / starts new quiz
        /// </summary>
        public void ResetState()
        {
            _quizManager.ResetQuiz();
            IsQuizOver = false;
            WrongGuesses = 0;
            LeftToGuess = _quizManager.NumOfCountiesLeftToGuess();
            CountyToGuess = _quizManager.GiveMeACountyToGuess();
        }

        public void IsThisTheCountyToGuess(County countyClicked)
        {
            if (IsQuizOver)
            {
                return;
            }

            if (countyClicked == CountyToGuess)
            {
                LeftToGuess = _quizManager.NumOfCountiesLeftToGuess();
                CountyToGuess = _quizManager.GiveMeACountyToGuess();

                if (CountyToGuess == null)
                {
                    IsQuizOver = true;
                }
            }
            else
            {
                WrongGuesses++;
            }
        }

        public void ResetQuizCommand() => ResetState();
    }
}
