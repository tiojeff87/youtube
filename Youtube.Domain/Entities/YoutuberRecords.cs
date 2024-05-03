﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Youtube.Domain.Entities
{
    public class YoutuberRecords
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Youtuber Trophy")]
        public int Youtuber_Trophy { get; set; }

        [ForeignKey("YoutubeId")]
        public int YoutubeId { get; set; }

        [ValidateNever]
        public Youtuber Youtuber { get; set; } = null!;

        [Display(Name = "Special Details")]
        public string? SpecialDetails { get; set; }
    }
}