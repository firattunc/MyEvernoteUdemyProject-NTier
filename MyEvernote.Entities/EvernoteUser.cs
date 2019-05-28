using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("EvernoteUser")]
    public class EvernoteUser:MyEntitiyBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SurName { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(70)]
        public string Email { get; set; }
        [Required,StringLength(100)]
        public string Password { get; set; }

        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        [Required]
        public Guid ActivateGuid { get; set; }
              

        public virtual List<Note> Notes { get; set; }
        public virtual List<Comment> Comments{ get; set; }
        public virtual List<Liked> Likes{ get; set; }
    }
}
