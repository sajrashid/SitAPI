using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Models
{
    public class ApiList
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public List<Api> APIS { get; set; }
    }
}
