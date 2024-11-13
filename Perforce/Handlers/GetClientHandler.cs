namespace Perforce.Handlers;

class GetClientHandler(Clients clients) : IHandler
{
    public Response Handle(Request request)
    {
        Client client = clients.Get(request);
        Response response = new Response();
        response.Message = client.ToString();
        return response;
    }
}