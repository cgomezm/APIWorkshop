using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Album
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Album Id is required")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        //[ForeignKey("ArtistId")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}