using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models
{
    public class Emp
    {
        [Display(Name = "Ansattnummer")]
        public int emp_num { get; set; }
        [Display(Name = "Navn")]

        [Column(TypeName = "varchar(50)")]
        public string? name { get; set; }
        [Display(Name = "Passord")]

        [Column(TypeName = "varchar(50)")]
        public string? password { get; set; }

        [Display(Name = "Team")]
        [Column(TypeName = "varchar(50)")]
        public string team { get; set; }

        [Display(Name = "Avdeling")]
        public Dept dept { get; set; }

        [Display(Name = "Admin")]
        public bool admin { get; set; }

        public List<Participants> participants { get; set; }

        public List<Suggestion> suggestions { get; set; }


    }
}