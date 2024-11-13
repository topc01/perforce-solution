using VersionControlSystem;

namespace Perforce.Handlers;

class SyncAllHandler(Clients clients, VersionSystem versionSystem) : IHandler
{
    public Response Handle(Request request)
    {
        Client client = clients.Get(request);
        FilePath path = new FilePath(client.DepotPath);
        Response response = new Response();
        response.Files = versionSystem.Get(path, ""); 
        return response;
    }
}