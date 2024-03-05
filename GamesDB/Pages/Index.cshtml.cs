using GamesDB.Data;
using GamesDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GamesDB.Pages
{
    public class IndexModel : PageModel
    {
        public List<Game> Games { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Games = _context.Games.Include(g => g.Genres).ToList();
        }
    }
}