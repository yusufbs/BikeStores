using Microsoft.AspNetCore.Mvc;
using PG.MyMediatR.WebApi.MyMediatR;

namespace PG.MyMediatR.WebApi.Features;

public class GetAllGames
{
    public record Query : IRequest<List<string>>;

    public class Handler : IRequestHandler<Query, List<string>>
    {
        public Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
        {
            var games = new List<string> {
                "The legend of Blazor",
                "Entity framework odyssey",
                "Clean architecture 3D",
                "Vertical Slice: Origins"
            };

            return Task.FromResult(games);
        }
    }
}

[ApiController]
[Route("api/[controller]")]
public class GamesController (ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllGames(CancellationToken cancellationToken)
    {
        var games = await sender.Send(new GetAllGames.Query(), cancellationToken);

        return Ok(games);
    }
}
