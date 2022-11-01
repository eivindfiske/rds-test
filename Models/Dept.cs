using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rds_test.Models
{
    public class Dept
    {
        public string? dept { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string team { get; set; }

        public List<Emp> emp { get; set; }

    }

}