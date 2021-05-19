using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Artist
{
    public class Artist
    {
        [Required(ErrorMessage = "Artist Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Artist Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Models.Album.Album> Albums { get; set; }
    }
}