namespace OFOWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adjective
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdjectiveId { get; set; }

        [Key]
        [Column("Adjective", Order = 1)]
        [StringLength(50)]
        public string Adjective1 { get; set; }

        [StringLength(10)]
        public string Token { get; set; }

        public int? AdjectiveToWords { get; set; }

        public virtual Word Word { get; set; }
    }
}
