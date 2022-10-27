using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace rds_test.Models
{

    public class Suggestion
    {
        [Column(TypeName = "varchar(50)")]
        public string? title { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string? description { get; set; }

        public DateTime timestamp { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string? pdsa_plan { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? pdsa_do { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? pdsa_study { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? pdsa_act { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string? status { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? responsible { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? resdept { get; set; }

        [Key]
        [MaxLength(10)]
        public int case_num { get; set; }

        public byte[]? pic_before { get; set; }
        public byte[]? pic_after { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? timeframe { get; set; }
        public DateOnly deadline { get; set; }

        public List<Participants> participants { get; set; }

    }
}