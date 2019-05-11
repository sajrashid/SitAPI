using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Models
{
    public class Api
    {
        [Key]
        public int APIId { get; set; }
        [MaxLength(500)]
        public string Url { get; set; }
        public List<Verb> Verbs { get; set; }


    }
}
