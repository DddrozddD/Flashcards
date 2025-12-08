using AutoMapper;
using Flashcards.Application.Features.Flashcards.Commands.CreateFlashcard;
using Flashcards.Application.Features.Flashcards.Commands.DeleteFlashcard;
using Flashcards.Application.Features.Flashcards.Commands.UpdateFlashcard;
using Flashcards.Application.Features.Flashcards.Queries.GetFlashcardDetails;
using Flashcards.Application.Features.Flashcards.Queries.GetFlashcardsList;
using Flashcards.WebApi.Models.Flashcards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Flashcards.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class FlashcardController : BaseController
    {
        private readonly IMapper _mapper;

        public FlashcardController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all flashcards from a specific theme.
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// GET /note/1D1D9771-1367-48A5-9255-19A6FD9E8D2F
        /// {
        ///     "ThemeId": "0tdcv..."
        /// }
        /// </remarks>
        /// <returns>Returns FlashcardsListVm</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpGet("{ThemeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllFlashcardsFromTheme(Guid ThemeId, CancellationToken cancellationToken)
        {
            var query = new GetFlashcardsListQuery
            {
                ThemeId = ThemeId
            };
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);
        }

        /// <summary>
        /// Gets all details from a specific flashcard.
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// GET /note/details/1D1D9771-1367-48A5-9255-19A6FD9E8D2F
        /// </remarks>
        /// <returns>Returns FlashcardDetailsVm</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpGet("details/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetFlashcardDetailsQuery
            {
                Id = Id,
            };
            var vm = await Mediator.Send(query, cancellationToken);
            return Ok(vm);

        }


        /// <summary>
        /// Create new flashcard. 
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// POST /note
        /// {
        ///     "FirstValue": "Some1",
        ///     "SecondValue": "Some2"
        /// }
        /// </remarks>
        /// <param name="createFlashcardDto">CreateFlashcardDto object</param>
        /// <returns>Returns new flashcards Id</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] CreateFlashcardDto createFlashcardDto, CancellationToken cancellationToken)
        {
            if (createFlashcardDto.FirstDescription == null)
            {
                createFlashcardDto.FirstDescription = "Empty description1/.";
            }
            if (createFlashcardDto.SecondDescription == null)
            {
                createFlashcardDto.SecondDescription = "Empty description2/.";
            }

            var command = _mapper.Map<CreateFlashcardCommand>(createFlashcardDto);
            var flashcardId = await Mediator.Send(command, cancellationToken);
            return Ok(flashcardId);
        }

        /// <summary>
        /// Update specific flashcard. 
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// PUT /note
        /// {
        ///     "Id": "1D1D9771-1367-48A5-9255-19A6FD9E8D2F",
        ///     "FirstValue": "Some1",
        ///     "SecondValue": "Some2"
        /// }
        /// </remarks>
        /// <param name="updateFlashcardDto">UpdateFlashcardDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateFlashcardDto updateFlashcardDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateFlashcardCommand>(updateFlashcardDto);
            await Mediator.Send(command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Delete specific flashcard. 
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// DELETE /note/1D1D9771-1367-48A5-9255-19A6FD9E8D2F
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid Id, CancellationToken cancellationToken)
        {
            var command = new DeleteFlashcardCommand
            {
                Id = Id
            };
            await Mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}