using Branches_BLL.DTOs.Branch;
using Branches_BLL.DTOs.BranchMember;
using Branches_BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Branches.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchesController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BranchDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<BranchDTO>>> GetAllBranches()
    {
        var branches = await _branchService.GetAllBranchesAsync();
        return Ok(branches);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BranchDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BranchDTO>> GetBranchById(int id)
    {
        var branch = await _branchService.GetBranchByIdAsync(id);
        return Ok(branch);
    }

    [HttpGet("{branchId}/moderators")]
    [ProducesResponseType(typeof(BranchMemberDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<BranchMemberDTO>>> GetModerators(int branchId)
    {
        var moderators = await _branchService.GetModeratorsByBranchIdAsync(branchId);
        return Ok(moderators);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddBranch([FromBody] CreateBranchDTO branchDto)
    {
        await _branchService.AddBranchAsync(branchDto);
        return CreatedAtAction(nameof(GetBranchById), new { id = branchDto.Name }, branchDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBranch(int id, [FromBody] CreateBranchDTO branchDto)
    {
        await _branchService.UpdateBranchAsync(id, branchDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBranch(int id)
    {
        await _branchService.DeleteBranchAsync(id);
        return NoContent();
    }
}