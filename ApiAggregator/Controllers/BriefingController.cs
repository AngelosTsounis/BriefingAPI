using ApiAggregator.Contracts.Request;
using ApiAggregator.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ApiAggregator.Controllers;

[ApiController]
[Route("/api/briefing")]
public class BriefingController : ControllerBase
{
    private readonly IValidator<BriefingRequest> _validator;
    private readonly IBriefingService _briefingService;

    public BriefingController(IValidator<BriefingRequest> validator, IBriefingService briefingService)
    {
        _validator = validator;
        _briefingService = briefingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBriefing([FromQuery] BriefingRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new
            {
                e.PropertyName,
                e.ErrorMessage
            }));
        }

        var briefing = await _briefingService.GetBriefing(request);

        return Ok(briefing);
    }
}
