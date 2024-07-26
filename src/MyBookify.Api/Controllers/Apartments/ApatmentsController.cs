using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBookify.Application.Apartments.SearchApartments;
using MyBookify.Domain.Abstractions;

namespace MyBookify.Api.Controllers.Apartments;

[Route("api/apartments")]
[ApiController]
public sealed class ApatmentsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SearchApatments(DateOnly startDate, DateOnly endDate, CancellationToken cancelationToken)
    {
        var query = new SearchApartmentsQuery(startDate, endDate);

        Result<IReadOnlyList<ApartmentResponse>> result = await sender.Send(query, cancelationToken);

        return Ok(result.Value);
    }
}
