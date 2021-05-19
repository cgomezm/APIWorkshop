using System.ComponentModel.DataAnnotations;

namespace Models.Album
{
    public class Album
    {
        [Required(ErrorMessage = "Album Id is required")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        [Required(ErrorMessage = "Artist Id is required")]
        public int ArtistId { get; set; }
    }
}