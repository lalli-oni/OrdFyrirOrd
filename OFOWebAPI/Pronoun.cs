namespace OFOWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pronoun
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PronounId { get; set; }

        [Column("Pronoun")]
        [StringLength(10)]
        public string Pronoun1 { get; set; }

        [StringLength(10)]
        public string Token { get; set; }

        public int? PronounsToWords { get; set; }

        public virtual Word Word { get; set; }
    }
}
