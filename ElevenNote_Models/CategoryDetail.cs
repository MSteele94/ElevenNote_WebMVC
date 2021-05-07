using ElevenNote_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote_Models
{
    public class CategoryDetail
    {
        public int? CategoryId { get; set; }
        public string Subject { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
