using CountyQuizCroatia.Services;
using System.Windows.Shapes;
using System.Diagnostics;
using Stylet;
using System;

namespace CountyQuizCroatia.ViewModels
{
    /// <summary>
    /// Application shell window
    /// </summary>
    public class ShellViewModel : Conductor<IScreen>.StackNavigation
    {
        private readonly InfoViewModel _infoVM;
        private readonly QuizViewModel _quizVM;
        private readonly ICountyService _countyService;
        public GameMode CurrentGameMode { get; set; }

        public ShellViewModel(InfoViewModel infoVM, QuizViewModel quizVM, ICountyService countyService)
        {
            _infoVM = infoVM;
            _quizVM = quizVM;
            _countyService = countyService;

            SelectGameMode(GameMode.Info);
        }

        /// <summary>
        /// Event handler for clicking the county on the map (left mouse up)
        /// </summary>
        /// <param name="sender">County path object</param>
        public void ClickOnCounty(object sender, EventArgs e)
        {
            if (sender is Path countyID)
            {
                var county = _countyService.GetCountyByID(countyID.Name);

                switch (CurrentGameMode)
                {
                    case GameMode.Info:
                        _infoVM.CurrentCounty = county;
                        break;
                    case GameMode.Quiz:
                        _quizVM.IsThisTheCountyToGuess(county);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Select the application game mode
        /// </summary>
        /// <param name="gameMode">Game mode to set</param>
        private void SelectGameMode(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.Info:
                    ActivateItem(_infoVM);
                    _infoVM.ResetState();
                    CurrentGameMode = GameMode.Info;
                    break;
                case GameMode.Quiz:
                    ActivateItem(_quizVM);
                    _quizVM.ResetState();
                    CurrentGameMode = GameMode.Quiz;
                    break;
                default:
                    break;
            }
        }

        public void ChangeGameModeCommand(GameMode gameMode) => SelectGameMode(gameMode);

        public enum GameMode
        {
            Info,
            Quiz
        }
    }
}
