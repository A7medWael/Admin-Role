using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UploadPhotos.Models;
namespace UploadPhotos.Controllers
{
    [Authorize(Roles = ClsRole.RoleAdmin)]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task< IActionResult> Index()
        {
            var _user = await _userManager.Users.ToListAsync();
            return View(_user);
        }
        [HttpGet]
        public async Task<IActionResult> addRole(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
            var userRole=await _userManager.GetRolesAsync(user);
            var allRoles=await _roleManager.Roles.ToListAsync();
            if (allRoles != null)
            {
                var rolelist = allRoles.Select(r => new ViewRoleModel()
                {
                    roleId = r.Id,
                    roleName = r.Name,
                    useRole = userRole.Any(x => x == r.Name)
                });
                ViewBag.userName = user.UserName;
                ViewBag.userId = userId;
                return View(rolelist);
            }
            else
                return NotFound();
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>addRole(string userId,string jsonRoles)
        {
            var user =await _userManager.FindByIdAsync(userId);
            //  List<ViewRoleModel>myRoles=JsonConvert.DeserializeObject<List<ViewRoleModel>>(jsonRoles);
            try
            {
                List<ViewRoleModel> myRoles = JsonConvert.DeserializeObject<List<ViewRoleModel>>(jsonRoles);
              if (user != null &&jsonRoles!=null)
              {
                var userRolrs = await _userManager.GetRolesAsync(user);
                foreach (var role in myRoles)
                 {
                    if (userRolrs.Any(x => x == role.roleName.Trim()) && !role.useRole)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.roleName.Trim());
                    }
                    if (!userRolrs.Any(x => x == role.roleName.Trim()) && role.useRole)
                    {
                        await _userManager.AddToRoleAsync(user, role.roleName.Trim());
                    }
                 }
                    return RedirectToAction("Index");

              }
            else
                return NotFound();
                // Rest of your code
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return BadRequest("Error deserializing JSON: " + ex.Message);
            }
           

        }
    }
}
