using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapitalReplacementJob.Helper.GeneralEnums;

namespace CapitalReplacementJob.Model
{
    public class PersonalInformationModel
    {
        //image will be a base 64 string
        public string Image { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public  List<QuestionModel> Questions { get; set; }
         
    }
    public class Profile
    {
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Resume { get; set; }       
        public List<QuestionModel> Questions { get; set; }

    }
    public class AdditionalQuestions
    {        
        public List<QuestionModel> Questions { get; set; }
        public bool HistoryOfEmbassyRejection { get; set; }
    }
    public class QuestionModel
    {
        public QuestionType QuestionType { get; set; }
        public string Question { get; set; }
        public string Choice { get; set; }
        public int MaxChoiceAllowed { get; set; }

    }
     
       
    
}
