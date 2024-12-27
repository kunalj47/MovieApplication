using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }    
        public DateTime DateOfBirth { get; set; }
      
        //many to many realtion with movies 

        public ICollection<Movie> Movies { get; set;}

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

    }
}
