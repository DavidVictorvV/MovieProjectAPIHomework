using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Models.Movie> movies = new List<Models.Movie>()
        {
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "StarWars" ,Genre = "Action",MovieLength = 120, ReleaseDate = 2002},
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "The Mandalorian" ,Genre = "Action",MovieLength = 120, ReleaseDate = 2019},
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "Thor" ,Genre = "Comedy",MovieLength = 120, ReleaseDate = 2016 },
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "Harry Potter" ,Genre = "Action, Magic",MovieLength = 120, ReleaseDate = 2007 },
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "IT" ,Genre = "Horor",MovieLength = 120, ReleaseDate = 2015 }
        };

        [HttpGet]
        public Models.Movie[] Get()
        {
            return movies.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Models.Movie duckbill)
        {
            if (duckbill.ID == Guid.Empty)
                duckbill.ID = Guid.NewGuid();

            movies.Add(duckbill);
        }

        [HttpPut]
        public void Put([FromBody] Models.Movie duckbill)
        {
            Models.Movie currentDuckbill = movies.FirstOrDefault(x => x.ID == duckbill.ID);
            currentDuckbill.MovieName = duckbill.MovieName;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            movies.RemoveAll(duckbill => duckbill.ID == id);
        }
    }
}
