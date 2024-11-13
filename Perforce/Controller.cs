using Perforce.Exceptions;
using Perforce.Handlers;

namespace Perforce;

public class Controller
{
    private readonly HandlerFactory _factory;
    private readonly Clients _clients = new ();

    public Controller(string rootPath)
    {
        VersionSystem versionSystem = new VersionSystem(rootPath);
        _factory = new HandlerFactory(_clients, versionSystem);
    }
    
    public Response Handle(Request request)
    {
        try
        {
            return TryToHandle(request);
        }
        catch (PerforceException e)
        {
            string errorMessage = e.GetErrorMessage();
            return Response.BuildUnsuccessfulResponse(errorMessage);
        }
    }
    
    private Response TryToHandle(Request request)
    {
        IHandler handler = _factory.Create(request);
        return handler.Handle(request);
    }
}