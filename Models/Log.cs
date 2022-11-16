using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models
{
    public class Log
    {
        public string Id { get; set; }

        [Timestamp]
        [Column(TypeName = "datetime(0)")]
        public DateTime timestamp { get; set; }

        public int case_num { get; set; }

        [StringLength(100)]
        public string? edit_msg { get; set; }

        public ApplicationUser applicationUsers {get; set;}

        public Suggestion suggestion {get; set;}

    }

}