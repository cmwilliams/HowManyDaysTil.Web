﻿using System;

namespace HowManyDaysTil.Web.Infrastructure.Entities
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public DateTime HolidayDate { get; set; }
        public string HolidayName { get; set; }
        public string Country { get; set; }
    }
}