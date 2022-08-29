using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteCommand;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.WebApi.Models;

namespace Notes.WebApi.Controllers
{
    /// <summary>
    /// Controller to work with notes
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class NoteController : BaseController
    {
        /// <summary>
        /// Contract mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes class instance
        /// </summary>
        /// <param name="mapper">Contract mapper</param>
        public NoteController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of notes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Return NoteListVM</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get not by id
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <remarks>
        /// Sample request:
        /// GET /note/31047B23-3958-49EC-9324-BB4491471159
        /// </remarks>
        /// <returns>Note</returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates note
        /// </summary>
        /// <param name="createNoteDto">Note to create</param>
        /// <remarks>
        /// Sample request:
        /// POST /note
        /// {
        ///     title: "title",
        ///     details: "details"
        /// }
        /// </remarks>
        /// <returns>Created note id</returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteDto, CreateNoteCommand>(createNoteDto);
            command.UserId = UserId;

            var noteId = await Mediator.Send(command);

            return Ok(noteId);
        }

        /// <summary>
        /// Creates note
        /// </summary>
        /// <param name="updateNoteDto">Note to update</param>
        /// <remarks>
        /// Sample request:
        /// PUT /note
        /// {
        ///     Id: "id"
        ///     title: "title",
        ///     details: "details"
        /// }
        /// </remarks>
        /// <returns>Return NoContent</returns>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteDto, UpdateNoteCommand>(updateNoteDto);
            command.UserId = UserId;

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Removes note
        /// </summary>
        /// <param name="id">Note id</param>
        /// <remarks>
        /// Sample request:
        /// DELETE /note/31047B23-3958-49EC-9324-BB4491471159
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
