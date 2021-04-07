using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace litsey.Models
{
    [Table("Group")]
    public partial class Group
    {
        public Group()
        {
            GroupSubjects = new HashSet<GroupSubject>();
            Students = new HashSet<Student>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nomi")]
        public string Nomi { get; set; }
        [Column("professionId")]
        public long? ProfessionId { get; set; }
        [Column("grade")]
        public long Grade { get; set; }

        [ForeignKey(nameof(ProfessionId))]
        [InverseProperty("Groups")]
        public virtual Profession Profession { get; set; }
        [InverseProperty(nameof(GroupSubject.Group))]
        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
        [InverseProperty(nameof(Student.Group))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
