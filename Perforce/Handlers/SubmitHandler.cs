using Perforce.Exceptions;
using VersionControlSystem;

namespace Perforce.Handlers;

class SubmitHandler(Clients clients, VersionSystem versionSystem) : IHandler
{
    public Response Handle(Request request)
    {
        Client client = clients.Get(request);
        if (request.ChangeList == null || request.ChangeList.IsEmpty())
            throw new InvalidChangeListException();
        Response response = new Response();
        request.ChangeList.ApplyChanges(versionSystem, client.DepotPath);
        return response;
    }
}