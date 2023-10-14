using Microsoft.EntityFrameworkCore;
using SNGG.DataAccess;
using SNGG.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNGG.Services
{
    public interface ISNGGContextService
    {
        int AddGame(Game game);
        int AddGuess(Guess guess);
        int AddPlayer(Player player);
        Player? GetPlayerByNameAndDateOfBirth(string name, DateTime dateOfBirth);
    }

    public class SNGGContextService : ISNGGContextService
    {
        private readonly SNGGContext _context;

        public SNGGContextService(SNGGContext context)
        {
            _context = context;
        }

        public Player? GetPlayerByNameAndDateOfBirth(string name, DateTime dateOfBirth)
        {
            //var player = _context.Players.Find(name, dateOfBirth);
            var player = _context.Players.AsQueryable().AsNoTracking().FirstOrDefault(p => p.PlayerName == name && p.DateOfBirth == dateOfBirth);
            return player;
        }

        public int AddPlayer(Player player)
        {
            if (player is null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            // bestaat hij al?
            var existingPlayer = GetPlayerByNameAndDateOfBirth(player.PlayerName, player.DateOfBirth);
            if (existingPlayer is not null)
            {
                player.Id = existingPlayer.Id;
                return player.Id;
            }

            _context.Players.Add(player);
            _context.SaveChanges();
            return player.Id;
        }

        public int AddGame(Game game)
        {
            if (game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Games.Add(game);
            _context.SaveChanges();
            return game.Id;
        }

        public int AddGuess(Guess guess)
        {
            if (guess is null)
            {
                throw new ArgumentNullException(nameof(guess));
            }

            _context.Guesses.Add(guess);
            _context.SaveChanges();
            return guess.Id;
        }
    }
}
