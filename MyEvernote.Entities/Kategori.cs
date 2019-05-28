using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("Kategoriler")]
    public class Kategori:MyEntitiyBase
    {
        [Required,StringLength(50)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }

        public virtual List<Note> notes{ get; set; }

        public Kategori()
        {
            notes = new List<Note>();
        }
    }
}
