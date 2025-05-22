using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using UserIdentityApi.Data;
using UserIdentityApi.Dto;
using UserIdentityApi.Models;

namespace UserIdentityApi.Controllers
{
    [Route("api/identities")]
    [ApiController]
    public class UserIdentitiesController : ControllerBase
    {
        private readonly UserIdentityContext _context;

        public UserIdentitiesController(UserIdentityContext context)
        {
            _context = context;
        }


        #region
        [HttpGet("{id}")]
        public async Task<ActionResult<UserIdentity>> GetUserIdentity(int id)
        {
            var userIdentity = await _context.UserIdentities.FindAsync(id);
            if (userIdentity == null)
            {
                return NotFound();
            }
            return userIdentity;
        }
        #endregion

        #region
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserIdentity(int id, UserIdentityUpdateDto updateDto)
        {
            if (id != updateDto.Id)
            {
                return BadRequest();
            }

            var userIdentity = await _context.UserIdentities.FindAsync(id);
            if (userIdentity == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(updateDto.FullName))
            {
                userIdentity.FullName = updateDto.FullName;
            }

            if (!string.IsNullOrWhiteSpace(updateDto.Email))
            {
                var emailAttr = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                if (!emailAttr.IsValid(updateDto.Email))
                {
                    return BadRequest("Invalid email format.");
                }
                userIdentity.Email = updateDto.Email;
            }

            userIdentity.LastUpdated = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }

    //public class UserIdentityUpdateDto
    //{
    //    public int Id { get; set; } 
    //    public string? FullName { get; set; }
    //    public string? Email { get; set; }
    //}
}
