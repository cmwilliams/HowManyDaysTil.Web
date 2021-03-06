﻿using System;

namespace HowManyDaysTil.Web.Infrastructure.Entities
{
    public class CalendarEvent
    {
        public int CalendarEventId { get; set; }
        public string Name { get; set; }
        public DateTime CalendarEventDate { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}