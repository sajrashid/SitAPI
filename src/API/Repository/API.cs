using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Repository
{
    public class Api
    {
        [Key]
        public int APIId { get; set; }
        [MaxLength(500)]
        [Required]
        public string Url { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Desc { get; set; }
        [Required]
        public List<Verb> Verbs { get; set; }
        public List<TestResults> TestResults { get; set; }
    }
}
