using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJYBlog.Models
{
    public class RegisterCity
    {
        public Writer Writer { get; set; }
        public string CountryValue { get; set; }
        public string CountryName { get; set; }

        public List<RegisterCity> RegisterCities()
        {
            List<RegisterCity> cities = new List<RegisterCity>();
            cities.Add(new RegisterCity { CountryName = "Düzce", CountryValue = "Düzce" });
            cities.Add(new RegisterCity { CountryName = "İstanbul", CountryValue = "İstanbul" });
            cities.Add(new RegisterCity { CountryName = "Ankara", CountryValue = "Ankara" });
            cities.Add(new RegisterCity { CountryName = "İzmir", CountryValue = "İzmir" });
            cities.Add(new RegisterCity { CountryName = "Trabzon", CountryValue = "Trabzon" });
            return cities;
        }
    }


}
