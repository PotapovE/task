using System;
using System.ComponentModel.DataAnnotations;

namespace MyMvcUI.Models
{
    public class TestModel
    {

        public int id { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Desc { get; set; }
        public decimal Price { get; set; }

    }
}
