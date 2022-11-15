using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace rds_test.Models
{

    public class Suggestion
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Tittel")]
        public string? title { get; set; }

        [StringLength(500)]
        [Display(Name = "Beskrivelse")]
        public string? description { get; set; }

        [Timestamp]
        [Column(TypeName = "datetime(0)")]
        public DateTime timestamp { get; set; }

        [StringLength(500)]
        [Display(Name = "Plan")]
        public string? pdsa_plan { get; set; }

        [StringLength(500)]
        [Display(Name = "Do")]
        public string? pdsa_do { get; set; }

        [StringLength(500)]
        [Display(Name = "Study")]
        public string? pdsa_study { get; set; }

        [StringLength(500)]
        [Display(Name = "Act")]
        public string? pdsa_act { get; set; }

        [StringLength(1)]
        [Display(Name = "Status")]
        public string? status { get; set; }

        [StringLength(50)]
        [Display(Name = "Ansvarlig")]
        public string? responsible { get; set; }

        [StringLength(50)]
        [Display(Name = "Ansvarlig avdeling")]
        public string? resdept { get; set; }

        public int case_num { get; set; }
        public string Id { get; set; }

        [Display(Name = "Bilde før endring")]
        public string? pic_before_data { get; set; }

        [NotMapped]
        public IFormFile? pic_before { get; set; }

        [Display(Name = "Bilde etter endring")]
        public string? pic_after_data { get; set; }

        [NotMapped]
        public IFormFile? pic_after { get; set; }

        [StringLength(50)]
        public string? timeframe { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tidsfrist")]
        public DateTime? deadline { get; set; }

        public ApplicationUser applicationUsers { get; set; }
        public List<Participants> participants { get; set; }
        public List<Log> log { get; set; }


    }
}