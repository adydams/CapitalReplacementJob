using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapitalReplacementJob.Helper.GeneralEnums;
using static CapitalReplacementJob.Model.WorkFlowModel;

namespace CapitalReplacementJob.Model
{
    

    public class ApplicationModel : TableEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("category")]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Program Title is required")]
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

        public DateTime Start { get; set; }

        [Required(ErrorMessage = " Application open date is required")]
        public DateTime Open { get; set; }

        [Required(ErrorMessage = " Application close date is required")]
        public DateTime Close { get; set; }

        public int DurationInMonths { get; set; }

        [Required(ErrorMessage = " Program Location date is required")]
        public ProgramLocation Location { get; set; }

        public MinimumQualification MinimumQualification { get; set; }

        public int MaxNumOfApplication { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = " FirstName is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = " Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = " Email is required")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public List<QuestionModel> PersonalInformationQuestions { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Resume { get; set; }
        public List<QuestionModel> ProfileQuestions { get; set; }

        public string Name { get; set; }
        public string VideoType { get; set; }
        public string Placement { get; set; }
        public bool DisplayStageToCandidate { get; set; }
        public List<VideoInterview> VideoInterview { get; set; }

    }
}
