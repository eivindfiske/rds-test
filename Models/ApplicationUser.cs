using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Display(Name = "Ansattnummer")]
    public string? emp_num { get; set; }

    [PersonalData]
    [Display(Name = "Navn")]
    [Column(TypeName = "varchar(50)")]
    public string? name { get; set; }

    [PersonalData]
    [Display(Name = "Team")]
    [Column(TypeName = "varchar(50)")]
    public string? team { get; set; }

    [PersonalData]
    [Display(Name = "Avdeling")]
    public Dept? dept { get; set; }


    public List<Participants> participants { get; set; }

    public List<Suggestion> suggestions { get; set; }
}

