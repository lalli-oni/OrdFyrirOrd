namespace OFOWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Verb")]
    public partial class Verb
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerbId { get; set; }

        [Key]
        [Column("Verb", Order = 1)]
        [StringLength(50)]
        public string Verb1 { get; set; }

        [StringLength(10)]
        public string Token { get; set; }

        public int? WordInWords { get; set; }

        public virtual Word Word { get; set; }
    }
}
