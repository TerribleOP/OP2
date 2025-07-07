using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5.App_Code
{
	public class GamesRegister : IEnumerable<Games>
	{
		public DateTime date { get; set; }

		private List<Games> games;

        public GamesRegister()
        {
            this.games = new List<Games>();
        }

        public GamesRegister(DateTime date)
        {
            this.date = date;
            this.games = new List<Games>();
        }
        /// <summary>
        /// Adds a game to the register.
        /// </summary>
        /// <param name="game"></param>
        public void AddGame(Games game)
        {
            this.games.Add(game);
        }
        /// <summary>
        /// Returns a game from register by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Games Get(int index)
        {
            return this.games[index];
        }

        public IEnumerator<Games> GetEnumerator()
        {
            foreach (Games game in this.games)
            {
                yield return game;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}