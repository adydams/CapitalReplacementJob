using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalReplacementJob.Repository
{
    public class ImageVideoRepo : IImageVideo
    {
        private readonly IHostingEnvironment _env;

        public ImageVideoRepo(IHostingEnvironment env)
        {
            _env = env;
        }
        public string ImageAndVideoToUrlService(string base64string, string Title, string Id)
            {
                var ExtesionSubstrings = base64string.Substring(0, 5);
                string ext = "";
                switch (ExtesionSubstrings.ToUpper())
                {
                    case "IVBOR":
                        ext = ".png";
                        break;
                    case "/9J/4":
                        ext = ".jpg";
                        break;
                    case "JVBER":
                        ext = ".pdf";
                        break;
                    case "AAABA":
                        ext = ".ico";
                        break;
                    case "UMFYI":
                        ext = ".rar";
                        break;
                    case "E1XYD":
                        ext = ".rtf";
                        break;
                    case "U1PKC":
                        ext = ".txt";
                        break;
                    case "AAAAF":
                        ext = "mp4";
                        break;
                    case "MQOWM":
                    case "77U/M":
                        ext = ".srt";
                        break;
                    default:
                        ext = string.Empty;
                        break;
                };

                //creating a folder to save application images and videos in the environment
                // for optimization of DB
                string folderName = Title.Replace(" ", "").ToUpper() + Id;
                var domainpath = $"{_env.WebRootPath}{Path.DirectorySeparatorChar}application{Path.DirectorySeparatorChar}{folderName}";

                //if application folder does not exist under application folder
                if (!Directory.Exists(domainpath)) { Directory.CreateDirectory(domainpath); } //Create logs folder
                string fileName = (Title.ToUpper() + Id).ToString();

                //creating a folder path
                var folderpath = $"{domainpath}{Path.DirectorySeparatorChar}{fileName}{ext}";

                byte[] buffer = Convert.FromBase64String(base64string);
                File.WriteAllBytes(folderpath, buffer);

                var fileUrl = new Uri(folderpath).AbsoluteUri.Trim();//
                                                                     //.Replace(DefaultRootAbsolute, DefaultUrl);
                return fileUrl;
            
        }
    }
}
