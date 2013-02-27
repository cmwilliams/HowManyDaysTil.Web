using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DaysUntoWeb.Infrastructure.Entities;

namespace DaysUntoWeb.Models
{
    public class HomeViewModel
    {
        public IList<Holiday> Holidays { get; set; }
        public string Country { get; set; }
    }
}