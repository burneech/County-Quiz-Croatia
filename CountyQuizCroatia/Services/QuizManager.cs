using System.Collections.Generic;
using CountyQuizCroatia.Models;
using System.Linq;
using System;

namespace CountyQuizCroatia.Services
{
    public class QuizManager : IQuizManager
    {
        private readonly ICountyService _countyService;
        private List<County> CountiesListRandomized;

        public QuizManager(ICountyService countyService)
        {
            _countyService = countyService;
            ResetQuiz();
        }

        /// <summary>
        /// Creates a new randomized list of counties, effectively reseting the quiz
        /// </summary>
        public void ResetQuiz()
        {
            CountiesListRandomized = _countyService.GetCountyList().OrderBy(x => Guid.NewGuid()).ToList();
        }

        public County GiveMeACountyToGuess()
        {
            if (CountiesListRandomized.Count > 0)
            {
                var countyToGuess = CountiesListRandomized[0];
                CountiesListRandomized.Remove(countyToGuess);
                return countyToGuess;
            }
            else
            {
                return null;
            }
        }

        public int NumOfCountiesLeftToGuess()
        {
            return CountiesListRandomized.Count();
        }
    }
}
