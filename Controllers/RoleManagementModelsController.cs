using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppFinal.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAppFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

            // Ensure the Admin role exists during initialization
            InitializeRoles().Wait();
        }

        private async Task InitializeRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);
            }
        }

        // GET: api/roles
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        // GET: api/roles/{roleName}
        [HttpGet("{roleName}")]
      
        public async Task<IActionResult> GetRole(string roleName)
        {
            var role = await _roleManager.FindByIdAsync(roleName);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            return Ok(role);
        }

        // POST: api/roles
        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            if (string.IsNullOrEmpty(model.RoleName))
            {
                return BadRequest("Role name cannot be empty.");
            }

            var role = new IdentityRole(model.RoleName);
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok("Role created successfully.");
            }

            return BadRequest(result.Errors);
        }

        // PUT: api/roles
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleManagementModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleName);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            role.Name = model.RoleName;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return Ok("Role updated successfully.");
            }

            return BadRequest(result.Errors);
        }

        // DELETE: api/roles/{roleName}
        [HttpDelete("{roleName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByIdAsync(roleName);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok("Role deleted successfully.");
            }

            return BadRequest(result.Errors);
        }

        // POST: api/roles/assign-role-to-user
        [HttpPost("assign-role-to-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] RoleManagementModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);

            if (!roleExists)
            {
                return NotFound("Role not found.");
            }

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            if (result.Succeeded)
            {
                return Ok("Role assigned to user successfully.");
            }

            return BadRequest(result.Errors);
        }
    }
}
