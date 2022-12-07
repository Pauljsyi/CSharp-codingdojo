using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFDemo.Models;

namespace EFDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // [HttpGet("")]
    public IActionResult Index()
    {
        return View();    
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // ====== 
    // READ All
    // ======

    [HttpGet("songs")]
    public IActionResult AllSongs()
    {
        List<Song> AllSongs = _context.Songs.ToList();
        return View("AllSongs", AllSongs);
    }

    // ====== 
    // READ ONE
    // ======

    // ====== 
    // CREATE
    // ======

    [HttpPost("songs/create")]
    public IActionResult CreateSong(Song newSong)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newSong);
            _context.SaveChanges();
            return RedirectToAction("AllSongs");
        }
        return View("Index");
    }

    // ====== 
    // DELETE
    // ======
    [HttpPost("songs/{songId}/destroy")]
    public IActionResult DestroySong(int songId)
    {
        System.Console.WriteLine(songId);
        Song? SongToDestroy = _context.Songs.SingleOrDefault(a => a.MusicId == songId);
        _context.Songs.Remove(SongToDestroy);
        _context.SaveChanges();
        return RedirectToAction("AllSongs");
    }

    // ====== 
    // EDIT
    // ======
    [HttpGet("songs/{songId}/edit")]
    public IActionResult EditSong(int songId)
    {
        Song? SongToEdit = _context.Songs.FirstOrDefault(a => a.MusicId == songId);
        // need to pass in SongToEdit to populate form
        return View(SongToEdit);
    }


    // ====== 
    // UPDATE
    // ======

    [HttpPost("songs/{songId}/update")]
    public IActionResult UpdateSong(int songId, Song UpdatedSong)
    {

        Song? SongToUpdate = _context.Songs.FirstOrDefault(a => a.MusicId == songId);
        if (SongToUpdate == null)
        {
            return RedirectToAction("Index");
        }

        if(ModelState.IsValid)
        {
            // Fill out our model
            SongToUpdate.Title = UpdatedSong.Title;
            SongToUpdate.Year = UpdatedSong.Year;
            SongToUpdate.Genre = UpdatedSong.Genre;
            SongToUpdate.Artist = UpdatedSong.Artist;
            SongToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("AllSongs");
        } else {
        return View("EditSong", SongToUpdate);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
