using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CountriesService.Models
{
    /// <summary>
    /// Contains the most common information about the country instance.
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        /// Common name of the country.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Information about the local currency.
        /// </summary>
        public CurrencyModel? Currency { get; set; }

        /// <summary>
        /// Capital of the country.
        /// </summary>
        public string? Capital { get; set; }

        /// <summary>
        /// Region of the country.
        /// </summary>
        public string? Region { get; set; }

        /// <summary>
        /// Area of the country.
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// Population of the country.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// URL to the image of the country flag.
        /// </summary>
        public string? FlagURL { get; set; }
    }
}
