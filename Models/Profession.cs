using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace litsey.Models
{
    [Table("Profession")]
    public partial class Profession
    {
        public Profession()
        {
            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nomi")]
        public string Nomi { get; set; }

        [InverseProperty(nameof(Group.Profession))]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
