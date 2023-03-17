using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalReplacementJob.Helper
{
    public class GeneralEnums
    {
        public enum KeySkills
        {
            UI = 1,
            UX,
            SocialMedia,
            GraphicsSDesign,
            ContentWriting,
            Seo
        }
        public enum ProgramType
        {
            Internship = 1,
            Job,
            Training,
            MasterClass,
            Webinar,
            Course,
            LiveSeminar,
            Volunteering,
            Others
        }
        public enum ProgramLocation
        {
            LondonUK = 1,
            FullyRemote,
            
        }
        public enum MinimumQualification
        {
            HighSchool = 1,
            College,
            Graduate,
            University,
            Masters,
            PhD,
            Any
        }
        public enum Gender
        {
            Male = 1,
            Female
        }
        public enum QuestionType
        {
            Paragraph = 1,
            ShortAnswer,
            YesOrNo,
            DropDown,
            MultipleChoice,
            Date,
            Number,
            FileUpload,
            Video

        }
    }
}
