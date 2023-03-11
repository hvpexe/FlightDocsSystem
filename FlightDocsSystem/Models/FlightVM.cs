﻿using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.Models
{
    public class FlightVM
    {
        public int Id { get; set; }
        public string FlightNo { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
        public User Creator { get; set; }
        public int UserId { get; set; }
    }
}
