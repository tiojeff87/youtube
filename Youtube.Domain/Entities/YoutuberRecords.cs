using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Youtube.Domain.Entities
{
    public class YoutuberRecords
    {
        [Key]
        public int Votos { get; set; }

        [ForeignKey("YoutuberId")]
        public int YoutuberId { get; set; }

        [ValidateNever]
        public Youtuber Youtuber { get; set; } = null!;

        [Display(Name = "Youtuber Trophy")]
        public required string Youtuber_Trophy { get; set; }
    }
}