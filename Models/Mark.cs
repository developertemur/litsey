using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace litsey.Models
{
    [Table("Mark")]
    public partial class Mark
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("studentId")]
        public long? StudentId { get; set; }
        [Column("s1")]
        public long? S1 { get; set; }
        [Column("s2")]
        public long? S2 { get; set; }
        [Column("s3")]
        public long? S3 { get; set; }
        [Column("s4")]
        public long? S4 { get; set; }
        [Column("q1")]
        public long? Q1 { get; set; }
        [Column("q2")]
        public long? Q2 { get; set; }
        [Column("q3")]
        public long? Q3 { get; set; }
        [Column("q4")]
        public long? Q4 { get; set; }
        [Column("olimpiada")]
        public long? Olimpiada { get; set; }
        [Column("tanlov")]
        public long? Tanlov { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Marks")]
        public virtual Student Student { get; set; }
    }
}
