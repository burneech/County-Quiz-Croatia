using CountyQuizCroatia.Models;
using Stylet;

namespace CountyQuizCroatia.ViewModels
{
    /// <summary>
    /// Information game mode
    /// <para>(Click on a county and view details about it)</para>
    /// </summary>
    public class InfoViewModel : Screen
    {
        private County _currentCounty;
        public County CurrentCounty
        {
            get { return _currentCounty; }
            set { SetAndNotify(ref _currentCounty, value); }
        }

        public InfoViewModel()
        {
            ResetState();
        }

        /// <summary>
        /// Shows the default placeholder county
        /// </summary>
        public void ResetState()
        {
            CurrentCounty = new County
            {
                ID = default,
                Name = "-",
                Seat = "-",
                Area = default,
                Population = default
            };
        }
    }
}
