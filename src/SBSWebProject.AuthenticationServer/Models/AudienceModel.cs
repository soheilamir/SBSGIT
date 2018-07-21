﻿using System.ComponentModel.DataAnnotations;

namespace SBSWebProject.AuthenticationServer.Models
{
    public class AudienceModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}