using Eksamensprojekt_API.DBContext;
using Eksamensprojekt_API.Manager;
using Eksamensprojekt_API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Eksamensprojekt_API.Controllers
{[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersManager _manager;
        //private UsersManager _manager = new UsersManager();

        public UsersController()//(UserContext context)
        {
            //DB
            // _manager = new DBUsersManager(context);

            // Non DB
            _manager = new UsersManager();
        }

        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery] string? sort_by)
        {
            IEnumerable<User> list = _manager.GetAll(sort_by);
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        //GET api/<UsersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetById(int id)
        {
            User? foundUser = _manager.GetById(id);
            if (foundUser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundUser);
            }
        }

        //// POST api/<UsersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<User> Post([FromBody] User newUser)
        {
            try
            {
                User createdUser = _manager.Add(newUser);
                return Created("/" + createdUser.Id, createdUser);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// PUT api/<UsersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User updates)
        {
            try
            {
                User updatedUser = _manager.Update(id, updates);
                if (updatedUser == null)
                {
                    return NotFound();
                }
                return Ok(updatedUser);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// DELETE api/<UsersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
           User User = _manager.Delete(id);

            if (id != User.Id)
            {
                return NotFound("No such item, id: " + id);
            }
            return Ok(User);
        }
    }
}