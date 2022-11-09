using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models
{
    public class Log
    {
        [ForeignKey("emp_num")]
        public string? emp_num { get; set; }

        [Key]
        public DateTime timestamp { get; set; }

        [ForeignKey("case_num")]
        public int case_num { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? edit_msg { get; set; }

    }

}