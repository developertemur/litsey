using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace litsey.Models
{
    [Table("Subject")]
    public partial class Subject
    {
        public Subject()
        {
            GroupSubjects = new HashSet<GroupSubject>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nomi")]
        public string Nomi { get; set; }

        [InverseProperty(nameof(GroupSubject.Subject))]
        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
    }
}
