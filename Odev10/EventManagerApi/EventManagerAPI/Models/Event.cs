using System;
using System.ComponentModel.DataAnnotations;
using EventManagerAPI.ValidationAttributes;

namespace EventManagerAPI.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MustStartWithUppercase]
        public string Name { get; set; }

        [Required]
        [DescriptionMustNotContainName]
        public string Description { get; set; }

        [Required]
        [NoPastDate]
        public DateTime EventDate { get; set; }
    }
}