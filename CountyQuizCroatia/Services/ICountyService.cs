using CountyQuizCroatia.Models;
using System.Collections.Generic;

namespace CountyQuizCroatia.Services
{
    public interface ICountyService
    {
        County GetCountyByID(string countyID);
        List<County> GetCountyList();
    }
}