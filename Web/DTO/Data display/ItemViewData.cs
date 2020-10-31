using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DTO.DataDisplay
{
    public class ItemViewData
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [FromForm]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        [FromForm]
        public string Description { get; set; }

        [Required]
        [FromForm]
        public string Ingredients { get; set; }

        [Range(0, int.MaxValue)]
        [FromForm]
        [Required]
        public int? Grams { get; set; }

        [Range(0, 999999.99)]
        [FromForm]
        public decimal Calories { get; set; }

        [RegularExpression(@"^(\d){1,2}(:(\d){1,2}){0,2}$")]
        [FromForm]
        public TimeSpan CookingTime { get; set; }

        [Range(0, double.MaxValue)]
        [FromForm]
        public decimal Price { get; set; }

        [FromForm]
        public DateTime? CreationDate { get; set; }


        [NotMapped]
        public string CookingTimeF { get; set; }

        [NotMapped]
        public string PriceF { get; set; }

        [NotMapped]
        public string CurrencySymbol { get; set; }

        [NotMapped]
        public string CaloriesF { get; set; }
    }
}
