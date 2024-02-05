using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesService.Models
{
    /// <summary>
    /// Contains the most common information about the currency.
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

        /// <summary>
        /// Method to compare CurrencyModel to any object.
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>True if objects are equal, false if they are not equal.</returns>
        public override bool Equals(object? obj)
        {
            CurrencyModel? other = obj as CurrencyModel;
            return other is not null &&
                other.Code == this.Code &&
                other.Name == this.Name &&
                other.Symbol == this.Symbol;
        }
    }
}
