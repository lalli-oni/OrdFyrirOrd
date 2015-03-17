namespace OFOWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerbId { get; set; }

        [Required]
        [StringLength(50)]
        public string Verb { get; set; }

        [StringLength(10)]
        public string Token { get; set; }
    }
}
