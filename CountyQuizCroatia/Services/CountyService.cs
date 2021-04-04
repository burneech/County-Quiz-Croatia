using System.Collections.Generic;
using CountyQuizCroatia.Models;

namespace CountyQuizCroatia.Services
{
    public class CountyService : ICountyService
    {
        private List<County> Counties { get; set; }

        public CountyService()
        {
            PopulateCountiesList();
        }

        public County GetCountyByID(string countyID)
        {
            return Counties.Find(c => c.ID == countyID);
        }

        public List<County> GetCountyList()
        {
            return Counties;
        }

        // TODO - This should be read from a JSON file or something similar...
        private void PopulateCountiesList()
        {
            Counties = new List<County>
            {
                new County { ID = "BPZ", Name = "Brodsko-posavska", Area = 2030, Population = 158575, Seat = "Slavonski Brod" },
                new County { ID = "KAZ", Name = "Karlovačka", Area = 3626, Population = 128899, Seat = "Karlovac" },
                new County { ID = "KZZ", Name = "Krapinsko-zagorska", Area = 1229, Population = 132892, Seat = "Krapina" },
                new County { ID = "MEZ", Name = "Međimurska", Area = 729, Population = 113804, Seat = "Čakovec" },
                new County { ID = "SDZ", Name = "Splitsko-dalmatinska", Area = 4540, Population = 454798, Seat = "Split" },
                new County { ID = "VSZ", Name = "Vukovarsko-srijemska", Area = 2454, Population = 179521, Seat = "Vukovar" },
                new County { ID = "ZAZ", Name = "Zagrebačka", Area = 3060, Population = 317606, Seat = "Zagreb" },
                new County { ID = "GZG", Name = "Grad Zagreb", Area = 641, Population = 790017, Seat = "-" },
                new County { ID = "BBZ", Name = "Bjelovarsko-bilogorska", Area = 2640, Population = 119764, Seat = "Bjelovar" },
                new County { ID = "DNZ", Name = "Dubrovačko-neretvanska", Area = 1781, Population = 122568, Seat = "Dubrovnik" },
                new County { ID = "ISZ", Name = "Istarska", Area = 2813, Population = 208055, Seat = "Pazin" },
                new County { ID = "KKZ", Name = "Koprivničko-križevačka", Area = 1748, Population = 115584, Seat = "Koprivnica" },
                new County { ID = "LSZ", Name = "Ličko-senjska", Area = 5353, Population = 50927, Seat = "Gospić" },
                new County { ID = "OBZ", Name = "Osječko-baranjska", Area = 4155, Population = 305032, Seat = "Osijek" },
                new County { ID = "PSZ", Name = "Požeško-slavonska", Area = 1823, Population = 78034, Seat = "Požega" },
                new County { ID = "PGZ", Name = "Primorsko-goranska", Area = 3588, Population = 296195, Seat = "Rijeka" },
                new County { ID = "SKZ", Name = "Šibensko-kninska", Area = 2984, Population = 109375, Seat = "Šibenik" },
                new County { ID = "SMZ", Name = "Sisačko-moslavačka", Area = 4468, Population = 172439, Seat = "Sisak" },
                new County { ID = "VAZ", Name = "Varaždinska", Area = 1262, Population = 175951, Seat = "Varaždin" },
                new County { ID = "VPZ", Name = "Virovitičko-podravska", Area = 2024, Population = 84836, Seat = "Virovitica" },
                new County { ID = "ZDZ", Name = "Zadarska", Area = 3646, Population = 170017, Seat = "Zadar" }
            };
        }
    }
}
