using AutoMapper;
using Flashcards.Application.Features.Themes.Commands.CreateTheme;
using Flashcards.Application.Features.Themes.Commands.UpdateTheme;
using Flashcards.Application.Features.Themes.Queries.GetThemeDetails;
using Flashcards.Application.Features.Themes.Queries.GetThemesList;
using Flashcards.Domain;
using Flashcards.WebApi.Models.Themes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class ThemeController: BaseController
    {
        private readonly IMapper _mapper;
        public ThemeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all themes from a specific user with pagination.
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// GET /theme
        /// </remarks>
        /// <returns>Returns ThemeListVm</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllThemes(CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int limit = 15)
        {
            var query = new GetThemesListQuery
            {
                UserId = UserId,
                Page = page,
                Limit = limit
            };

            var result = await Mediator.Send(query, cancellationToken);
               
            return Ok(result);
        }

        /// <summary>
        /// Gets all details from a specific theme.
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// GET /theme/1D1D9771-1367-48A5-9255-19A6FD9E8D2F
        /// </remarks>
        /// <returns>Returns ThemeDetailsVm</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetThemeDetails(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetThemeDetailsQuery
            {
                Id = Id,
                UserId =UserId
            };
            var result = await Mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Create new theme. 
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// POST /theme
        /// {
        ///     "Title": "Title1"
        /// }
        /// </remarks>
        /// <param name="createThemeDto">CreateThemeDto object</param>
        /// <returns>Returns new theme Id</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateDefaultThemes([FromBody] CreateThemeDto createThemeDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateThemeCommand>(createThemeDto);
            command.UserId =UserId;
            var themeId = await Mediator.Send(command, cancellationToken);
            return Ok(themeId);
        }

        /// <summary>
        /// Update specific theme. 
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// PUT /theme
        /// {
        ///     "Id": "1D1D9771-1367-48A5-9255-19A6FD9E8D2F",
        ///     "Title": "Title11"
        /// }
        /// </remarks>
        /// <param name="updateThemeDto">UpdateThemeDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateTheme([FromBody]UpdateThemeDto updateThemeDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateThemeCommand>(updateThemeDto);

            await Mediator.Send(command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Delete specific theme. 
        /// </summary>
        /// <remarks>
        /// Example of request:
        /// DELETE /theme/1D1D9771-1367-48A5-9255-19A6FD9E8D2F
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User is anauthorize</response>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteTheme(Guid Id, CancellationToken cancellationToken)
        {
            var command = new Flashcards.Application.Features.Themes.Commands.DeleteTheme.DeleteThemeCommand
            {
                Id = Id,
                UserId = UserId
            };
            await Mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
