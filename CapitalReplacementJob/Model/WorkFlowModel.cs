using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalReplacementJob.Model
{
    public class WorkFlowModel
    {
        public class Stage
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Placement { get; set; }
            public bool DisplayStageToCandidate { get; set; }
            public List< VideoInterview> VideoInterview { get; set; }
        }
        public class VideoInterview
        {
           
            public string InterviewQuestion { get; set; }
            public string InformationAboutVideo { get; set; }
            public int DurationInSec { get; set; }
            public int DeadlineInDays { get; set; }
        }
    }
}
