using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UploadPhotos.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace UploadPhotos.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly ContextAppl _contextAppl;
        private readonly IHostingEnvironment hosting;
        public ItemController(ContextAppl contextAppl, IHostingEnvironment _hosting)
        {

            _contextAppl = contextAppl;
            hosting = _hosting;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Items items)
        {
            string fileName=string.Empty;
            string myUpload = Path.Combine(hosting.WebRootPath, "Images");
            fileName = items.ClientFile.FileName;
            string fullpath=Path.Combine(myUpload, fileName);
            items.ClientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
            items.imagePath = fileName;
                     _contextAppl.items.Add(items);
            _contextAppl.SaveChanges();

            return Ok("Done");
        }

    }
}
