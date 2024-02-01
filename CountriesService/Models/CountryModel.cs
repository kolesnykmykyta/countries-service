using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CountriesService.Models
{
    public class CountryModel
    {
        public string? Name { get; set; }
        public CurrencyModel? Currency { get; set; }
        public string? Capital { get; set; }
        public string? Region { get; set; }
        public List<string>? Languages { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public string? FlagURL { get; set; }
    }
}
