﻿using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.ViewModels
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

        public string Permission { get; set; } = string.Empty;

    }
}