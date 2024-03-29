﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GamesDB.Models
{
    public class GameGenres
    {
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        
    }
}
