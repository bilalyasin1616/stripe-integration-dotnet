using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Serializable]
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime DateCreated { get; set; }

        [StringLength(150)]
        public string CreatedByName { get; set; }

        public int CreatedById { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime DateLastUpdated { get; set; }

        [StringLength(150)]
        public string LastUpdateByName { get; set; }

        public int LastUpdatedById { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
