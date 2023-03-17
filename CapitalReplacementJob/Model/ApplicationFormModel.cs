using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapitalReplacementJob.Helper.GeneralEnums;

namespace CapitalReplacementJob.Model
{
    public class ApplicationFormModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="Program Title is required") ]
        public string Title { get; set; }

        [MinLength(250, ErrorMessage = "Summary cannot be more than 250 characters")]
        public string Summary { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Program Description is required")]
        public string Description { get; set; }

        public KeySkills Skils { get; set; }

        public string Benefits { get; set; }

        public string Criteria { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Program type is required")]
        public ProgramType Type { get; set; }

        public DateOnly Start { get; set; }

        [Required(ErrorMessage =" Application open date is required")]
        public DateOnly Open { get; set; }

        [Required(ErrorMessage = " Application close date is required")]
        public DateOnly Close { get; set; }

        public int DurationInMonths { get; set; }

        [Required(ErrorMessage = " Program Location date is required")]
        public ProgramLocation Location { get; set; }

        public MinimumQualification MinimumQualification { get; set; }

        public int MaxNumOfApplication { get; set; }
    }
}
