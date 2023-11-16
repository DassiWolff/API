using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

   
    public class UsersController : ControllerBase
    {
      
        // GET api/<ValuesController>
        [HttpGet]
        //Async await!!
        public ActionResult Get(
            [FromQuery] string userName="", [FromQuery] string password="")
        {
            // Consider using a meaningful variable name like userFound (Do you mean userExists? ) 
            User userAgsist = userService.getUser(userName, password);
            if(userAgsist ==null)
            {
                return NoContent();
            }
            return Ok(userAgsist);

        }

        //DI? Dependency injection?
        UserService userService = new UserService();
        //Async await!!
        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            //Async Await?return user?-- Task<IActionResult<user>>
            User newUser = userService.addUser(user);
            if (newUser == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);

        }
        //suggestion for shorter and nicer code- == null ? BadRequest("Password isn't strong") : CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);



        [HttpPost("check")]
        //meaningfull function name: CheckPasswordStrength
        public int Check([FromBody] string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
            }
            return -1;

        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        //Function should return Task<ActionResult<User>
        //Return the updatedUser 
        //Check : if updatrdUser==null return BadRequesst() else OK(user) 
        //Async await!!
        public void Put(int id, [FromBody] User userToUpdate)
        {
            User newUser = userService.editUser(userToUpdate);

        }

        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
