using CountyQuizCroatia.Services;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
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

        private Color _infoBtnBackground;
        public Color InfoBtnBackground
        {
            get { return _infoBtnBackground; }
            set { SetAndNotify(ref _infoBtnBackground, value); }
        }

        private Color _quizBtnBackground;
        public Color QuizBtnBackground
        {
            get { return _quizBtnBackground; }
            set { SetAndNotify(ref _quizBtnBackground, value); }
        }

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
                    InfoBtnBackground = SolidColorBrushToColor((SolidColorBrush)Application.Current.Resources["MyBlue"]);
                    QuizBtnBackground = SolidColorBrushToColor((SolidColorBrush)Application.Current.Resources["MyGray"]);
                    break;
                case GameMode.Quiz:
                    ActivateItem(_quizVM);
                    _quizVM.ResetState();
                    CurrentGameMode = GameMode.Quiz;
                    InfoBtnBackground = SolidColorBrushToColor((SolidColorBrush)Application.Current.Resources["MyGray"]);
                    QuizBtnBackground = SolidColorBrushToColor((SolidColorBrush)Application.Current.Resources["MyBlue"]);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Converts SolidColorBrush (as used in Application.Resources XAML) to Color (as used in the code)
        /// </summary>
        /// <param name="brush">Color in SolidColorBrush type</param>
        /// <returns>Color in Color type</returns>
        private Color SolidColorBrushToColor(SolidColorBrush brush)
        {
            return Color.FromArgb(brush.Color.A, brush.Color.R, brush.Color.G, brush.Color.B);
        }

        public void ChangeGameModeCommand(GameMode gameMode) => SelectGameMode(gameMode);

        public enum GameMode
        {
            Info,
            Quiz
        }
    }
}
