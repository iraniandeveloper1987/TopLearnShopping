using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TopLearn.Web.Pages.Admin.Controllers
{
    public class UploadFileController : Controller
    {

        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string ckEditorFuncNum, string ckEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();



            var path = Path.Combine(    
                Directory.GetCurrentDirectory(), "wwwroot/images/AppImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }



            var url = $"{"/images/AppImages/"}{fileName}";


            return Json(new { uploaded = true, url });
        }
    }
}
