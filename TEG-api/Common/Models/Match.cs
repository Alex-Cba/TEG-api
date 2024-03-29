﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEG_api.Common.Enums;

namespace TEG_api.Common.Models
{
    [Table("Matchs")]
    public class Match
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreationDateUTC { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? SaveDateUTC { get; set; }
        public DateTimeOffset? EndDateUTC { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public string Winner { get; set; }
        public int? MapId { get; set; }
        public int MatchConfigId { get; set; }
        public ColorPlayer? TurnActual { get; set; }
        public List<ColorPlayer?> TurnOrder { get; set; }
        public virtual Map? Map { get; set; }
        public virtual MatchConfig MatchConfig { get; set; }
        public virtual ICollection<PlayerGameSetup> PlayerGameSetups { get; set; }
    }
}
