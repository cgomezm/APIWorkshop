using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Linq;
using APIWorkshop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace myfirstapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ArtistController : ControllerBase
    {
        private MusicDBContext _dBContext { get; set; }

        public ArtistController(MusicDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        public List<Artist> Get()
        {
             /* EAGER LOADING */
            return _dBContext.Set<Artist>()
            .Include(artist => artist.Albums)
            .ToList();

            /* EXPLICIT LOADING */
            // var all = _dBContext.Artists;

            // var a = all
            // .Single(b => b.Id == 4);

            // _dBContext.Entry(a)
            //     .Collection(b => b.Albums)
            //     .Load();

            // return all.ToList();

       }


        [HttpPost]
        [Authorize(Policy = "super")]
        public List<Artist> Post(Artist artist)
        {
            var artists = new List<Artist>();

            if (ModelState.IsValid)
            {
                _dBContext.Set<Artist>().Add(artist);
                _dBContext.SaveChanges();
                artists = _dBContext.Set<Artist>().ToList();
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
            var artists = new List<Artist>(); ;

            var artist = _dBContext.Find<Artist>(id);
            _dBContext.Set<Artist>().Remove(artist);
            _dBContext.SaveChanges();

            artists = _dBContext.Set<Artist>().ToList();
            return artists;
        }

        [HttpPut]
        public List<Artist> Put(Artist artist)
        {
            var artists = new List<Artist>();
            _dBContext.Set<Artist>().Update(artist);

            foreach (var item in artist.Albums)
            {
                if(_dBContext.Set<Album>().Any(a => a.Id == item.Id)){
                    _dBContext.Entry(item).State = EntityState.Modified; // added row
                }
                else{
                    _dBContext.Entry(item).State = EntityState.Added; // added row
                     _dBContext.Set<Album>().Add(item);
                }
            }

            _dBContext.SaveChanges();

            artists = _dBContext.Set<Artist>().ToList();
            return artists;
        }
    }
}