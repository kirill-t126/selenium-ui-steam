using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGames.Models
{
    internal class SteamGame
    {
        public string ReleaseDate { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            var test = obj as SteamGame;
            return this.Price == test.Price &&
                this.ReleaseDate == test.ReleaseDate &&
                this.Title == test.Title;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }   
}