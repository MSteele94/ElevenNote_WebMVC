﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote_Models
{
    public class NoteEdit
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Note Subject")]
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsStarred { get; set; }
    }
}
