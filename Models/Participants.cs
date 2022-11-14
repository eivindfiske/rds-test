using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models
{
    public class Participants
    {
        public int case_num { get; set; }
        public Suggestion suggestion { get; set; }

        public string Id { get; set; }
        public ApplicationUser applicationUsers { get; set; }

    }
}