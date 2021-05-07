using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote_Data
{
    public class Category
    {
        [Key]
        public int? CategoryId { get; set; }
        [Display(Name = "Note Subject")]
        public string Subject { get; set; }
        public ICollection<Note> Notes { get; set; }
        //public virtual List<Note> Notes { get; set; } = new List<Note>();
    }
}
