using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models
{
    public class Participants
    {
        public int case_num { get; set; }
        public Suggestion suggestion { get; set; }

        public int emp_num { get; set; }
        public Emp emp { get; set; }

    }
}