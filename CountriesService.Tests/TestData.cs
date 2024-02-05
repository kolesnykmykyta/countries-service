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
        public static readonly string InvalidRequest = "{\"status\":404,\"message\":\"Not Found\"}";

        public static Dictionary<string, string> MockJsonForCountryCode = new Dictionary<string, string>
        {
            {"br", "{\"flags\":{\"png\":\"https://flagcdn.com/w320/br.png\",\"svg\":\"https://flagcdn.com/br.svg\",\"alt\":\"The flag of Brazil has a green field with a large yellow rhombus in the center. Within the rhombus is a dark blue globe with twenty-seven small five-pointed white stars depicting a starry sky and a thin white convex horizontal band inscribed with the national motto 'Ordem e Progresso' across its center.\"},\"name\":{\"common\":\"Brazil\",\"official\":\"Federative Republic of Brazil\",\"nativeName\":{\"por\":{\"official\":\"República Federativa do Brasil\",\"common\":\"Brasil\"}}},\"currencies\":{\"BRL\":{\"name\":\"Brazilian real\",\"symbol\":\"R$\"}},\"capital\":[\"Brasília\"],\"region\":\"Americas\",\"area\":8515767.0,\"population\":212559409}" },
            {"aus",  "{\"flags\":{\"png\":\"https://flagcdn.com/w320/au.png\",\"svg\":\"https://flagcdn.com/au.svg\",\"alt\":\"The flag of Australia has a dark blue field. It features the flag of the United Kingdom — the Union Jack — in the canton, beneath which is a large white seven-pointed star. A representation of the Southern Cross constellation, made up of one small five-pointed and four larger seven-pointed white stars, is situated on the fly side of the field.\"},\"name\":{\"common\":\"Australia\",\"official\":\"Commonwealth of Australia\",\"nativeName\":{\"eng\":{\"official\":\"Commonwealth of Australia\",\"common\":\"Australia\"}}},\"currencies\":{\"AUD\":{\"name\":\"Australian dollar\",\"symbol\":\"$\"}},\"capital\":[\"Canberra\"],\"region\":\"Oceania\",\"area\":7692024.0,\"population\":25687041}"},
            {"100", "{\"flags\":{\"png\":\"https://flagcdn.com/w320/bg.png\",\"svg\":\"https://flagcdn.com/bg.svg\",\"alt\":\"The flag of Bulgaria is composed of three equal horizontal bands of white, green and red.\"},\"name\":{\"common\":\"Bulgaria\",\"official\":\"Republic of Bulgaria\",\"nativeName\":{\"bul\":{\"official\":\"Република България\",\"common\":\"България\"}}},\"currencies\":{\"BGN\":{\"name\":\"Bulgarian lev\",\"symbol\":\"лв\"}},\"capital\":[\"Sofia\"],\"region\":\"Europe\",\"area\":110879.0,\"population\":6927288}" },
        };

        public static Dictionary<string, CountryModel> ExpectedModelsForCountryCode = new Dictionary<string, CountryModel>   
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

        public static Dictionary<string, string> MockJsonForCountryName = new Dictionary<string, string>
        {
            {"ukraine", "[{\"flags\":{\"png\":\"https://flagcdn.com/w320/ua.png\",\"svg\":\"https://flagcdn.com/ua.svg\",\"alt\":\"The flag of Ukraine is composed of two equal horizontal bands of blue and yellow.\"},\"name\":{\"common\":\"Ukraine\",\"official\":\"Ukraine\",\"nativeName\":{\"ukr\":{\"official\":\"Україна\",\"common\":\"Україна\"}}},\"currencies\":{\"UAH\":{\"name\":\"Ukrainian hryvnia\",\"symbol\":\"₴\"}},\"capital\":[\"Kyiv\"],\"region\":\"Europe\",\"area\":603500.0,\"population\":44134693}]" },
            {"deutschland", "[{\"flags\":{\"png\":\"https://flagcdn.com/w320/de.png\",\"svg\":\"https://flagcdn.com/de.svg\",\"alt\":\"The flag of Germany is composed of three equal horizontal bands of black, red and gold.\"},\"name\":{\"common\":\"Germany\",\"official\":\"Federal Republic of Germany\",\"nativeName\":{\"deu\":{\"official\":\"Bundesrepublik Deutschland\",\"common\":\"Deutschland\"}}},\"currencies\":{\"EUR\":{\"name\":\"Euro\",\"symbol\":\"€\"}},\"capital\":[\"Berlin\"],\"region\":\"Europe\",\"area\":357114.0,\"population\":83240525}]" },
            {"egyp", "[{\"flags\":{\"png\":\"https://flagcdn.com/w320/eg.png\",\"svg\":\"https://flagcdn.com/eg.svg\",\"alt\":\"The flag of Egypt is composed of three equal horizontal bands of red, white and black, with Egypt's national emblem — a hoist-side facing gold eagle of Saladin — centered in the white band.\"},\"name\":{\"common\":\"Egypt\",\"official\":\"Arab Republic of Egypt\",\"nativeName\":{\"ara\":{\"official\":\"جمهورية مصر العربية\",\"common\":\"مصر\"}}},\"currencies\":{\"EGP\":{\"name\":\"Egyptian pound\",\"symbol\":\"£\"}},\"capital\":[\"Cairo\"],\"region\":\"Africa\",\"area\":1002450.0,\"population\":102334403}]" },
        };

        public static Dictionary<string, CountryModel> ExpectedModelsForCountryName = new Dictionary<string, CountryModel>
        {
            {"ukraine", new CountryModel()
                {
                    Name = "Ukraine",
                    FlagURL = "https://flagcdn.com/w320/ua.png",
                    Capital = "Kyiv",
                    Currency = new CurrencyModel()
                    {
                        Name = "Ukrainian hryvnia",
                        Symbol = "₴",
                        Code = "UAH",
                    },
                    Area = 603500.0,
                    Population = 44134693,
                    Region = "Europe",
                }
            },
            {"deutschland", new CountryModel()
                {
                    Name = "Germany",
                    FlagURL = "https://flagcdn.com/w320/de.png",
                    Capital = "Berlin",
                    Currency = new CurrencyModel()
                    {
                        Name = "Euro",
                        Symbol = "€",
                        Code = "EUR",
                    },
                    Area = 357114.0,
                    Population = 83240525,
                    Region = "Europe",
                }
            },
            {"egyp", new CountryModel()
                {
                    Name = "Egypt",
                    FlagURL = "https://flagcdn.com/w320/eg.png",
                    Capital = "Cairo",
                    Currency = new CurrencyModel()
                    {
                        Name = "Egyptian pound",
                        Symbol = "£",
                        Code = "EGP",
                    },
                    Area = 1002450.0    ,
                    Population = 102334403,
                    Region = "Africa",
                }
            },
        };

        public static Dictionary<string, string> MockJssonForCountryCapital = new Dictionary<string, string>
        {
            {"tallin", "[{\"flags\":{\"png\":\"https://flagcdn.com/w320/ee.png\",\"svg\":\"https://flagcdn.com/ee.svg\",\"alt\":\"The flag of Estonia is composed of three equal horizontal bands of blue, black and white.\"},\"name\":{\"common\":\"Estonia\",\"official\":\"Republic of Estonia\",\"nativeName\":{\"est\":{\"official\":\"Eesti Vabariik\",\"common\":\"Eesti\"}}},\"currencies\":{\"EUR\":{\"name\":\"Euro\",\"symbol\":\"€\"}},\"capital\":[\"Tallinn\"],\"region\":\"Europe\",\"area\":45227.0,\"population\":1331057}]" },
            {"lond", "[{\"flags\":{\"png\":\"https://flagcdn.com/w320/gb.png\",\"svg\":\"https://flagcdn.com/gb.svg\",\"alt\":\"The flag of the United Kingdom — the Union Jack — has a blue field. It features the white-edged red cross of Saint George superimposed on the diagonal red cross of Saint Patrick which is superimposed on the diagonal white cross of Saint Andrew.\"},\"name\":{\"common\":\"United Kingdom\",\"official\":\"United Kingdom of Great Britain and Northern Ireland\",\"nativeName\":{\"eng\":{\"official\":\"United Kingdom of Great Britain and Northern Ireland\",\"common\":\"United Kingdom\"}}},\"currencies\":{\"GBP\":{\"name\":\"British pound\",\"symbol\":\"£\"}},\"capital\":[\"London\"],\"region\":\"Europe\",\"area\":242900.0,\"population\":67215293}]" },
            {"warsaw","[{\"flags\":{\"png\":\"https://flagcdn.com/w320/pl.png\",\"svg\":\"https://flagcdn.com/pl.svg\",\"alt\":\"The flag of Poland is composed of two equal horizontal bands of white and red.\"},\"name\":{\"common\":\"Poland\",\"official\":\"Republic of Poland\",\"nativeName\":{\"pol\":{\"official\":\"Rzeczpospolita Polska\",\"common\":\"Polska\"}}},\"currencies\":{\"PLN\":{\"name\":\"Polish złoty\",\"symbol\":\"zł\"}},\"capital\":[\"Warsaw\"],\"region\":\"Europe\",\"area\":312679.0,\"population\":37950802}]" },
        };

        public static Dictionary<string, CountryModel> ExpectedModelsForCountryCapital = new Dictionary<string, CountryModel>
        {
            {"tallin", new CountryModel()
                {
                    Name = "Estonia",
                    FlagURL = "https://flagcdn.com/w320/ee.png",
                    Capital = "Tallin",
                    Currency = new CurrencyModel()
                    {
                        Name = "Euro",
                        Symbol = "€",
                        Code = "EUR",
                    },
                    Area = 45227.0,
                    Population = 1331057,
                    Region = "Europe",
                }
            },
            {"lond", new CountryModel()
                {
                    Name = "United Kingdom",
                    FlagURL = "https://flagcdn.com/w320/gb.png",
                    Capital = "London",
                    Currency = new CurrencyModel()
                    {
                        Name = "British pound",
                        Symbol = "£",
                        Code = "GBP",
                    },
                    Area = 242900.0,
                    Population = 67215293,
                    Region = "Europe",
                }
            },
            {"warsaw", new CountryModel()
                {
                    Name = "Poland",
                    FlagURL = "https://flagcdn.com/w320/pl.png",
                    Capital = "Warsaw",
                    Currency = new CurrencyModel()
                    {
                        Name = "Polish złoty",
                        Symbol = "zł",
                        Code = "PLN",
                    },
                    Area = 312679.0,
                    Population = 37950802,
                    Region = "Europe",
                }
            },
        };
    }
}
