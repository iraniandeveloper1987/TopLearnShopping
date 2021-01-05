using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using SharpCompress.Archives;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.SaveFile.ExtractEpisodeFiles
{
    public class ExtractEpisode : IDisposable
    {
        static IArchive _archive;   
        public static void Extract(CourseEpisode episode, IFormFile file)
        {
           
            string extractpath = string.Empty;

            string fileNameMp4 = file.FileName.Replace(".rar", ".mp4");

            if (episode.IsFree)
            {
                extractpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Videos/Episodes/FreeOnlineCourse/");
            }
            else
            {
                extractpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Videos/Episodes/MoneyOnlineCourse");
            }

            _archive = ArchiveFactory.Open(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Videos/Episodes/" + episode.EpisodeFileName));
            var entries = _archive.Entries.OrderBy(x => x.Key.Length);
            
            foreach (var en in entries)
            {
                if (Path.GetExtension(en.Key) == ".mp4")
                {

                    en.WriteTo(System.IO.File.Create(Path.Combine(extractpath, fileNameMp4)));

                }
            }

          
        }

        public void Dispose()
        {
            _archive.Dispose();

        }
    }
}
