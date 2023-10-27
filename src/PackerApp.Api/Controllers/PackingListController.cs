using Microsoft.AspNetCore.Mvc;
using PackerApp.Application.Commands;
using PackerApp.Application.Dtos;
using PackerApp.Application.Queries;
using PackerApp.Shared.Abstractions.Commands;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Api.Controllers;

public class PackingListController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public PackingListController(
        IQueryDispatcher queryDispatcher,
        ICommandDispatcher commandDispatcher
    )
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingListQuery query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackingListDto>>> Search(
        [FromQuery] SearchPackingListQuery query
    )
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePackingListWithItemsCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> RemoveList([FromBody] RemovePackingListCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpPut("{packingListId:Guid}/items")]
    public async Task<IActionResult> AddItem([FromBody] AddPackingItemCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpPut("{packingListId:Guid}/items/{name}/pack")]
    public async Task<IActionResult> AddItem([FromBody] PackItemCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{packingListId:Guid}/items/{name}")]
    public async Task<IActionResult> RemoveItem([FromBody] RemovePackingItemCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}
