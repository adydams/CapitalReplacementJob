using CapitalReplacementJob.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalReplacementJob.Repository
{
    public interface IApplication
    {
        Task<IActionResult> CreateApplication(ApplicationModel submitApplication);
        Task<IActionResult> GetApplications();
        Task<IActionResult> GetApplicationbyId(string id, string category);
        Task<IActionResult> UpdateApplication(ApplicationModel data, string id, string category);
        Task<IActionResult> DeleteApplication(string id, string category);
    }
}
