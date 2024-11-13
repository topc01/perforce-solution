using VersionControlSystem;

namespace Perforce.Handlers;

class HandlerFactory(Clients clients, VersionSystem versionSystem)
{
    public IHandler Create(Request request)
    {
        if (request.Type == "client" && request.DepotPath == null)
            return new GetClientHandler(clients);
        if (request.Type == "client" && request.DepotPath != null)
            return new CreateClientHandler(clients, versionSystem);
        if (request.Type == "sync" && request.FilePath == null)
            return new SyncAllHandler(clients, versionSystem);
        if (request.Type == "sync" && request.FilePath != null)
            return new SyncFileHandler(clients, versionSystem);
        if (request.Type == "submit")
            return new SubmitHandler(clients, versionSystem);
        throw new NotImplementedException();
    }
}