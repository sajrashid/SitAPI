using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Repository
{
    public class NinetyDayAverage
    {
        [Key]
        public int AvgId { get; set; }
        [Required]
        public double AvgRespTime { get; set; }
    }
}
