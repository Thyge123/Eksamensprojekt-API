using Eksamensprojekt_API.DBContext;
using Eksamensprojekt_API.Manager;
using Eksamensprojekt_API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Eksamensprojekt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrashCansController : ControllerBase
    {
        private ITrashCansManager _manager;
        //private TrashCansManager _manager = new TrashCansManager();

        public TrashCansController()//(TrashCanContext context)
        {
            //DB
            // _manager = new DBTrashManager(context);

            // Non DB
            _manager = new TrashCansManager();
        }

        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<TrashCan>> Get([FromQuery] string? sort_by)
        {
            IEnumerable<TrashCan> list = _manager.GetAll(sort_by);
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        //GET api/<TrashCansController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TrashCan> GetById(int id)
        {
            TrashCan? foundTrashCan = _manager.GetById(id);
            if (foundTrashCan == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundTrashCan);
            }
        }

        //// POST api/<TrashCansController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<TrashCan> Post([FromBody] TrashCan newTrashCan)
        {
            try
            {
                TrashCan createdTrashCan = _manager.Add(newTrashCan);
                return Created("/" + createdTrashCan.Id, createdTrashCan);
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

        //// PUT api/<TrashCansController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<TrashCan> Put(int id, [FromBody] TrashCan updates)
        {
            try
            {
                TrashCan updatedTrashCan = _manager.Update(id, updates);
                if (updatedTrashCan == null)
                {
                    return NotFound();
                }
                return Ok(updatedTrashCan);
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

        //// DELETE api/<TrashCansController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<TrashCan> Delete(int id)
        {
           TrashCan TrashCan = _manager.Delete(id);

            if (id != TrashCan.Id)
            {
                return NotFound("No such item, id: " + id);
            }
            return Ok(TrashCan);
        }
    }
}