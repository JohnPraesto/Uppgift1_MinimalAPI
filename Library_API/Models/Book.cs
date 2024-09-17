﻿using System.ComponentModel.DataAnnotations;

namespace Library_API.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Published { get; set; }
        public bool IsAvailable { get; set; }
    }
}
