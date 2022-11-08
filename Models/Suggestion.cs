using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace rds_test.Models
{

    public class Suggestion
    {
        [Required]
        [StringLength(50)]
        public string? title { get; set; }

        [StringLength(500)]
        public string? description { get; set; }

        [Timestamp]
        [Column(TypeName = "datetime(0)")]
        public DateTime timestamp { get; set; }

        [StringLength(500)]
        public string? pdsa_plan { get; set; }

        [StringLength(500)]
        public string? pdsa_do { get; set; }

        [StringLength(500)]
        public string? pdsa_study { get; set; }

        [StringLength(500)]
        public string? pdsa_act { get; set; }

        [StringLength(1)]
        public string? status { get; set; }

        [StringLength(50)]
        public string? responsible { get; set; }

        [StringLength(50)]
        public string? resdept { get; set; }

        public int case_num { get; set; }
        public string? emp_num { get; set; }

        public byte[]? pic_before { get; set; }
        public byte[]? pic_after { get; set; }

        [StringLength(50)]
        public string? timeframe { get; set; }

        public DateOnly? deadline { get; set; }

        public int emp_num {get; set;}

        public Emp emp {get; set;}

        public List<Participants> participants { get; set; }
        public ApplicationUser? applicationUsers { get; set; }

    }
}