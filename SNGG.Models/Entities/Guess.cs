﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SNGG.Models.Entities
{
    [Table("Guesses")]
    public class Guess : BaseEntity
    {
        public int Ships { get; set; }
        public int Buoys { get; set; }

        [Column(TypeName = "bigint")]
        /// <summary>
        /// Time between guesses in milliseconds
        /// </summary>
        public double GuessTime { get; set; }

        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        [JsonIgnore]
        public virtual Game Game { get; set; }
    }
}
