namespace OFOWebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WordListModel : DbContext
    {
        public WordListModel()
            : base("name=WordListModel")
        {
        }

        public virtual DbSet<Pronoun> Pronouns { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<Adjective> Adjectives { get; set; }
        public virtual DbSet<Verb> Verbs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pronoun>()
                .Property(e => e.Pronoun1)
                .IsFixedLength();

            modelBuilder.Entity<Pronoun>()
                .Property(e => e.Token)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.Token)
                .IsFixedLength();

            modelBuilder.Entity<Word>()
                .Property(e => e.Token)
                .IsFixedLength();

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Pronouns)
                .WithOptional(e => e.Word)
                .HasForeignKey(e => e.PronounsToWords);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Adjectives)
                .WithOptional(e => e.Word)
                .HasForeignKey(e => e.AdjectiveToWords);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Verbs)
                .WithOptional(e => e.Word)
                .HasForeignKey(e => e.WordInWords);

            modelBuilder.Entity<Adjective>()
                .Property(e => e.Token)
                .IsFixedLength();

            modelBuilder.Entity<Verb>()
                .Property(e => e.Token)
                .IsFixedLength();
        }
    }
}
