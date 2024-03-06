﻿using System.ComponentModel.DataAnnotations;

namespace CRMApp.DOMAIN.Entities

{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? PasswordHash { get; set; }

    }
}
