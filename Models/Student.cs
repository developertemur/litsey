using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace litsey.Models
{
    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Mark>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nomi")]
        public string Nomi { get; set; }
        [Required]
        [Column("surname")]
        public string Surname { get; set; }
        [Required]
        [Column("sharif")]
        public string Sharif { get; set; }
        [Required]
        [Column("Manzil")]
        public string Manzil { get; set; }
        [Column("groupId")]
        public long? GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Students")]
        public virtual Group Group { get; set; }
        [InverseProperty(nameof(Mark.Student))]
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
