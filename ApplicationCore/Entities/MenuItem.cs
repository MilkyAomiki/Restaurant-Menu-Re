using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class MenuItem
    {
        [Key]
        [Column("id")]
        public int Id { get; private set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; private set; }

        [StringLength(255)]
        [Column("title")]
        public string Title { get; private set; }

        [Column("ingridients")]
        public string Ingridients { get; private set; }

        [StringLength(500)]
        [Column("description")]
        public string Description { get; private set; }

        [Range(0, double.MaxValue)]
        [Column("price")]
        public double Price { get; private set; }

        [Range(0, int.MaxValue)]
        [Column("grams")]
        public int Grams { get; private set; }

        [Range(0, double.MaxValue)]
        [Column("calories")]
        public double Calories { get; private set; }

        [Range(0, int.MaxValue)]
        [Column("cooking_time")]
        public int CookingTime { get; private set; }

        public MenuItem(int id, DateTime creationDate, string title, string ingridients, string description, double price, int grams, double calories, int cookingTime)
        {
            Id = id;
            CreationDate = creationDate;
            Title = title;
            Ingridients = ingridients;
            Description = description;
            Price = price;
            Grams = grams;
            Calories = calories;
            CookingTime = cookingTime;
        }



    }
}
