using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesService.Models
{
    /// <summary>
    /// Defines class to save the most common information about the currency.
    /// </summary>
    public class CurrencyModel
    {
        /// <summary>
        /// Code of the currency.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Name of the currency.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Symbol of the currency.
        /// </summary>
        public string? Symbol { get; set; }
    }
}
