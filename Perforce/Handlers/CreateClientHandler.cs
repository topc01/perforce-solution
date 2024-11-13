using Perforce.Exceptions;
using VersionControlSystem;

namespace Perforce.Handlers;

class CreateClientHandler(Clients clients, VersionSystem versionSystem) : IHandler
{
    public Response Handle(Request request)
    {
        if (!versionSystem.Exists(new FilePath(request.DepotPath)))
            throw new InvalidDepotException();
        Response response = new Response();
        clients.Add(request);
        return response;
    }
}