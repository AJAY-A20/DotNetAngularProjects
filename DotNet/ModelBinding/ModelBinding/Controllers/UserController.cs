using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;
namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<UserModel> Users = new List<UserModel>
        {
            new UserModel { Id = 1, Name = "Rakesh", Department = "IT", Gender = "Male", Salary = 1000 },
            new UserModel { Id = 2, Name = "Priyanka", Department = "IT", Gender = "Female", Salary = 2000  },
            new UserModel { Id = 3, Name = "Suresh", Department = "HR", Gender = "Male", Salary = 3000 },
            new UserModel { Id = 4, Name = "Hina", Department = "HR", Gender = "Female", Salary = 4000 },
            new UserModel { Id = 5, Name = "Pranaya", Department = "HR", Gender = "Male", Salary = 35000 },
            new UserModel { Id = 6, Name = "Pooja", Department = "IT", Gender = "Female", Salary = 2500 },
        };

        [HttpGet]
        public IActionResult GetUsers([FromQuery] UserSearch userSearch)
        {
            var FilteredUsers = new List<UserModel>();
            if (userSearch != null)
            {
                FilteredUsers = Users.Where(
                       emp => emp.Department.Equals(userSearch.Department, StringComparison.OrdinalIgnoreCase) ||
                       emp.Gender.Equals(userSearch.Gender, StringComparison.OrdinalIgnoreCase)
                       ).ToList();

                if (FilteredUsers.Count > 0)
                {
                    return Ok(FilteredUsers);
                }
                return NotFound($"No Users Found with Department: {userSearch?.Department} and Gender: {userSearch?.Gender}");
            }
            return BadRequest("Invalid Search Criteria");
        }
    }
}