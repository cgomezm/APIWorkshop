using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models.Artist;
using Models.Album;
using System.Linq;

namespace myfirstapi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ArtistController : ControllerBase
    {
        [HttpGet]
        public List<Artist> Get()
        {
            return GetAllArtist();
        }


        [HttpPost]
        public List<Artist> Post(Artist artist)
        {
            var artists = new List<Artist>();

            if (ModelState.IsValid)
            {
                artists = GetAllArtist();
                artists.Add(artist);
            }
            else
            {
                artists = new List<Artist>();
            }

            return artists;
        }

        [HttpDelete]
        public List<Artist> Delete(int id)
        {
            var artists = GetAllArtist();
            var artist = artists.Where(q => q.Id == id).FirstOrDefault();

            artists.Remove(artist);

            return artists;
        }

        [HttpPut]
        public List<Artist> Put(Artist artist)
        {
            var artists = GetAllArtist();

            var art = artists.Where(q => q.Id == artist.Id).FirstOrDefault();

            if (art != null)
            {
                art.Name = artist.Name;
                art.Description = artist.Description;

                if (art.Albums != null && artist.Albums != null)
                {
                    var albums = art.Albums.ToList();

                    foreach (var albumExist in albums)
                    {
                        foreach (var albumArrive in artist.Albums)
                        {
                            if (albumArrive.Id == albumExist.Id)
                            {
                                albumExist.ArtistId = albumArrive != null ? albumArrive.ArtistId : 0;
                                albumExist.Name = albumArrive != null ? albumArrive.Name : string.Empty;
                                albumExist.Year = albumArrive != null ? albumArrive.Year : 0;
                            }
                        }
                    }
                }
            }

            return artists;
        }

        private List<Artist> GetAllArtist()
        {
            return new List<Artist>()
            {
                new Artist()
                {
                    Id = 1, Name = "AC/DC", Description = "One",
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Id = 1, Name = "Black in Black", Year = 1980, ArtistId = 1
                        },
                        new Album()
                        {
                            Id = 2, Name = "Highway to Hell", Year = 1979, ArtistId = 1
                        },
                        new Album()
                        {
                            Id = 3, Name = "The Razors Edge", Year = 1990, ArtistId = 1
                        }
                    }
                },
                new Artist()
                {
                    Id = 2, Name = "Adelle", Description = "This is Adelle",
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Id = 4, Name = "21", Year = 2011, ArtistId = 2
                        },
                        new Album()
                        {
                            Id = 5, Name = "25", Year = 2015, ArtistId = 2
                        },
                        new Album()
                        {
                            Id = 6, Name = "19", Year = 2008, ArtistId = 2
                        }
                    }
                },
                new Artist()
                {
                    Id = 3, Name = "Ed Sheeran", Description = "This is Ed",
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Id = 7, Name = "Deluxe", Year = 2017, ArtistId = 3
                        },
                        new Album()
                        {
                            Id = 8, Name = "Afterglow", Year = 2020, ArtistId = 3 //Single
                        },
                        new Album()
                        {
                            Id = 9, Name = "+", Year = 2011, ArtistId = 3
                        }
                    }
                },
                new Artist()
                {
                    Id = 4, Name = "Diomedez Diaz", Description = "Esto es valllenato",
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Id = 10, Name = "Experiencias Vividas", Year = 1999, ArtistId = 4
                        },
                        new Album()
                        {
                            Id = 11, Name = "Título de Amor", Year = 1993, ArtistId = 4
                        },
                        new Album()
                        {
                            Id = 12, Name = "Muchas Gracias", Year = 2006, ArtistId = 4
                        }
                    }
                }
            };
        }

    }
}