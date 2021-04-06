using CountyQuizCroatia.Models;
using System.Collections.Generic;

namespace CountyQuizCroatia.Services
{
    /// <summary>
    /// Handles the county data
    /// </summary>
    public interface ICountyService
    {
        County GetCountyByID(string countyID);
        List<County> GetCountyList();
    }
}