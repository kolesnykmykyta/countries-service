using CountriesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesService.Tests
{
    public static class TestData
    {
        public static Dictionary<string, string> MockJsonForCountryCode = new Dictionary<string, string>
        {
            {"br", "{\"flags\":{\"png\":\"https://flagcdn.com/w320/br.png\",\"svg\":\"https://flagcdn.com/br.svg\",\"alt\":\"The flag of Brazil has a green field with a large yellow rhombus in the center. Within the rhombus is a dark blue globe with twenty-seven small five-pointed white stars depicting a starry sky and a thin white convex horizontal band inscribed with the national motto 'Ordem e Progresso' across its center.\"},\"name\":{\"common\":\"Brazil\",\"official\":\"Federative Republic of Brazil\",\"nativeName\":{\"por\":{\"official\":\"República Federativa do Brasil\",\"common\":\"Brasil\"}}},\"currencies\":{\"BRL\":{\"name\":\"Brazilian real\",\"symbol\":\"R$\"}},\"capital\":[\"Brasília\"],\"region\":\"Americas\",\"area\":8515767.0,\"population\":212559409}" },
            {"aus",  "{\"flags\":{\"png\":\"https://flagcdn.com/w320/au.png\",\"svg\":\"https://flagcdn.com/au.svg\",\"alt\":\"The flag of Australia has a dark blue field. It features the flag of the United Kingdom — the Union Jack — in the canton, beneath which is a large white seven-pointed star. A representation of the Southern Cross constellation, made up of one small five-pointed and four larger seven-pointed white stars, is situated on the fly side of the field.\"},\"name\":{\"common\":\"Australia\",\"official\":\"Commonwealth of Australia\",\"nativeName\":{\"eng\":{\"official\":\"Commonwealth of Australia\",\"common\":\"Australia\"}}},\"currencies\":{\"AUD\":{\"name\":\"Australian dollar\",\"symbol\":\"$\"}},\"capital\":[\"Canberra\"],\"region\":\"Oceania\",\"area\":7692024.0,\"population\":25687041}"},
            {"100", "{\"flags\":{\"png\":\"https://flagcdn.com/w320/bg.png\",\"svg\":\"https://flagcdn.com/bg.svg\",\"alt\":\"The flag of Bulgaria is composed of three equal horizontal bands of white, green and red.\"},\"name\":{\"common\":\"Bulgaria\",\"official\":\"Republic of Bulgaria\",\"nativeName\":{\"bul\":{\"official\":\"Република България\",\"common\":\"България\"}}},\"currencies\":{\"BGN\":{\"name\":\"Bulgarian lev\",\"symbol\":\"лв\"}},\"capital\":[\"Sofia\"],\"region\":\"Europe\",\"area\":110879.0,\"population\":6927288}" },
            {"invalidRequest", "{\"status\":404,\"message\":\"Not Found\"}" },
        };

        public static Dictionary<string, CountryModel> ExpectedModelForCountryCode = new Dictionary<string, CountryModel>   
        {
            {"br", new CountryModel()
                {
                    Name = "Brazil",
                    FlagURL = "https://flagcdn.com/w320/br.png",
                    Capital = "Brasília",
                    Currency = new CurrencyModel()
                    {
                        Name = "Brazilian real",
                        Symbol = "R$",
                        Code = "BRL",
                    },
                    Area = 8515767.0,
                    Population = 212559409,
                    Region = "Americas",
                }
            },
            {"aus", new CountryModel()
                {
                    Name = "Australia",
                    FlagURL = "https://flagcdn.com/w320/au.png",
                    Capital = "Canberra",
                    Currency = new CurrencyModel()
                    {
                        Name = "Australian dollar",
                        Symbol = "$",
                        Code = "AUD",
                    },
                    Area = 7692024.0,
                    Population = 25687041,
                    Region = "Oceania",
                }
            },
            {"100", new CountryModel()
                {
                    Name = "Bulgaria",
                    FlagURL = "https://flagcdn.com/w320/bg.png",
                    Capital = "Sofia",
                    Currency = new CurrencyModel()
                    {
                        Name = "Bulgarian lev",
                        Symbol = "лв",
                        Code = "BGN",
                    },
                    Area = 110879.0,
                    Population = 6927288,
                    Region = "Europe",
                }
            },
        };
    }
}
