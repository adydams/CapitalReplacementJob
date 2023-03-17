using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalReplacementJob.Repository
{
    public interface IImageVideo
    {
       string ImageAndVideoToUrlService(string base64string, string Title, string Id);
    }
}
