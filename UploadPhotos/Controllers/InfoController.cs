using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UploadPhotos.Models;

namespace UploadPhotos.Controllers
{
    [Authorize( Roles =ClsRole.RoleAdmin)]
    public class InfoController : Controller
    {
        private readonly ContextAppl _contextAppl;
        
        public InfoController(ContextAppl contextAppl)
        {

            _contextAppl = contextAppl;
            

        }
        [HttpGet]
        public IActionResult Index()
        {
            var inf=_contextAppl.infos.ToList();
            return View(inf);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Info info)
        {
            MemoryStream stream = new MemoryStream();
            info.ClientFile.CopyTo(stream);
            info.dbimage = stream.ToArray();
            _contextAppl.infos.Add(info);
            _contextAppl.SaveChanges();
            return Ok("Done");
        }
    }
}
