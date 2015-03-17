namespace OFOWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Word
    {
        public Word()
        {
            Pronouns = new HashSet<Pronoun>();
            Adjectives = new HashSet<Adjective>();
            Verbs = new HashSet<Verb>();
        }

        public int WordId { get; set; }

        [Column("Word")]
        [Required]
        [StringLength(50)]
        public string Word1 { get; set; }

        [StringLength(10)]
        public string Token { get; set; }

        public virtual ICollection<Pronoun> Pronouns { get; set; }

        public virtual ICollection<Adjective> Adjectives { get; set; }

        public virtual ICollection<Verb> Verbs { get; set; }
    }
}
