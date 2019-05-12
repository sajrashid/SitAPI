using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Repository
{
    public class TestResults
    {

        [Key]
        public int TestId { get; set; }
        [Required]
        public  int APIId { get; set; }
        [Required]
        [MaxLength(3)]
        public int StatusCode { get; set; }
        [Required]
        public double RespTime { get; set; }
        [Required]
        public int FailCount { get; set; }
        [Required]
        public int PassCount { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public List<Error> Error { get; set; }

    }
}
