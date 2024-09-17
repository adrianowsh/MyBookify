using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBookify.Application.Bookings.GetBooking;
using MyBookify.Application.Bookings.ReserveBooking;
using MyBookify.Domain.Abstractions;

namespace MyBookify.Api.Controllers.Bookings;

[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/bookings")]
[ApiController]
public sealed class BookingsController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);

        Result<BookingResponse> result = await sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(
        ReserveBookingRequest request, CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(
            ApartmentId: request.ApartmentId ?? Guid.Empty,
            UserId: request.UserId ?? Guid.Empty,
            request.StartDate ?? default,
            request.EndDate ?? default
            );

        Result<Guid> result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
}
