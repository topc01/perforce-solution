using Perforce.Exceptions;
using VersionControlSystem;

namespace Perforce.Handlers;

class SyncFileHandler(Clients clients, VersionSystem versionSystem) : IHandler
{
    public Response Handle(Request request)
    {
        Client client = clients.Get(request);
        FilePath path = FilePath.Combine(client.DepotPath, request.FilePath!);
        if (!versionSystem.Exists(path))
            throw new InvalidPathException(request.FilePath);
        Response response = new Response();
        response.Files = versionSystem.Get(path, request.FilePath);
        return response;
    }
}