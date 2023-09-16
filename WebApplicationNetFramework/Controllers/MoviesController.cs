using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationNetFramework.Models;
using WebApplicationNetFramework.Utilities;

namespace WebApplicationNetFramework.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomLogger _customLogger;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
            _customLogger = new CustomLogger();
        }

        public ActionResult Edit(int id) 
        {
            return Content($"id = {id}");
        }

        //movies list
        public ActionResult Index(int? pageIndex, string sortBy) 
        {
            /*            if (!pageIndex.HasValue)
                            pageIndex = 1;*/
            var movies = _context.Movies;

            return View(movies);

/*            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));*/
        }

        public ActionResult NewMovie() 
        {
            var movie = new Movie();
            return View();
        }

        public ActionResult Save(Movie movie) 
        {
            if( movie.Id != 0 )
            {
                var movieToUpdate = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);

                movieToUpdate.Name = movie.Name;
                movieToUpdate.Genre = movie.Genre;
                movieToUpdate.Copies = movie.Copies;

                _context.SaveChanges();

            } else
            {
                _context.Movies.Add(movie);
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Update(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault( m => m.Id == id);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            TempData["message"] = "uploading..";
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    using (var reader = new StreamReader(file.InputStream))
                    {
                        while(!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                var values = line.Split(',');
                                
                                foreach (var v in values)
                                {
                                    string[] valuesArray = v.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (valuesArray.Length == 3)
                                    {
                                        var movie = new Movie
                                        {
                                            Name = valuesArray[0].Trim(),
                                            Genre = valuesArray[1].Trim(),
                                            Copies = int.Parse(valuesArray[2].Trim())
                                        };

                                        if (_context.Movies.FirstOrDefault(x => x.Name == movie.Name) != null)
                                        {
                                            _customLogger.Log($"ERROR: Movie named {movie.Name} already exists");
                                            throw new DuplicateWaitObjectException($"Movie named {movie.Name} already exists");
                                        }

                                        _context.Movies.Add(movie);
                                        _context.SaveChanges();

                                        var movieInserted = _context.Movies.FirstOrDefault(x => x.Name == movie.Name);

                                        //log
                                        _customLogger.Log("Movie ADDED: " + movieInserted.ToString());
                                       
                                    } else
                                    {
                                        throw new FormatException($"Invalid format in: {v}");
                                    }
                                }

                                
                            }
                        }
                    }

                    
                    TempData["message"] = "Movies added successfully";
                }
                catch(Exception ex)
                {
                    TempData["message"] = "Error: " + ex.Message;
                }
            }
            else
            {
                TempData["message"] = "Please select a file to upload.";
            }
            return RedirectToAction("Index");
        }
    }
}