using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    //[Table("Artist")]
    public class Artist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Artist Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}