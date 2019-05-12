using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Repository
{
    public class Error
    {
        [Key]
        public int ErrId { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ErrMsg { get; set; }
   
    }
}
