using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models
{
    public class Emp
    {
        [Key]
        public int emp_num { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? password { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string team { get; set; }
        public Dept dept { get; set; }

        public bool admin { get; set; }

        public List<Participants> participants { get; set; }


    }
}