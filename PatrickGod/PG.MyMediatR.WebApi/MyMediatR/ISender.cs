namespace PG.MyMediatR.WebApi.MyMediatR;

public interface ISender
{
    Task<TResponse> Send<TResponse>(
        IRequest<TResponse> request, 
        CancellationToken cancellationToken = default);
}


// Reference Video: https://www.youtube.com/watch?v=k62-sq35no8&list=WL&index=14&ab_channel=PatrickGod