using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Models
{
    public class Verb
    {
        [Key]
        public int VerbId { get; set; }
        [MaxLength(50)]
        public virtual  string Name { get; set; }
        [MaxLength(500)]
        public string Parameters { get; set; }

    }
}
