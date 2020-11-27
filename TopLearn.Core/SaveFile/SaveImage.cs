using System.IO;
using Microsoft.AspNetCore.Http;

namespace TopLearn.Core.SaveFile
{
    public class SaveFile
    {
        public static bool Save(IFormFile file, string physicalAddressFile)
        {
            try
            {
                using (var stream = new FileStream(physicalAddressFile, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }
            catch
            {
                return false;
            }


            return true;
        }
    }
}
