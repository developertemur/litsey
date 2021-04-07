using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace litsey.Models
{
    [Table("GroupSubject")]
    public partial class GroupSubject
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("groupId")]
        public long? GroupId { get; set; }
        [Column("subjectId")]
        public long? SubjectId { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty("GroupSubjects")]
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("GroupSubjects")]
        public virtual Subject Subject { get; set; }
    }
}
