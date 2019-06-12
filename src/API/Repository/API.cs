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
        public string APIName { get; set; }

        [MaxLength(500)]
        [Required]
        public string Url { get; set; }

        [Required]
        [MaxLength(500)]
        public String CurlCmd { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Desc { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "RunTests must be a true or false value")]
        public bool RunTests { get; set; }

        [MaxLength(100)]
        [Required]
        public string CClink { get; set; }
       
        public List<TestResults> TestResults { get; set; }
        public List<NinetyDayAverage> NinetyDayAverage { get; set; }
    }
}
