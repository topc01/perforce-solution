using Perforce.Exceptions;

namespace Perforce;

public class Clients
{
    private readonly Dictionary<string, Dictionary<string, Client>> _clients = new ();

    public void Add(Request request)
    {
        if (!_clients.ContainsKey(request.Username)) 
            _clients[request.Username] = new Dictionary<string, Client>();
        _clients[request.Username][request.ClientName] = new Client(request.ClientName, request.DepotPath);
    }

    public Client Get(Request request)
    {
        if (!_clients.ContainsKey(request.Username))
            throw new UserNotFoundException(request.Username);
        if (!_clients[request.Username].ContainsKey(request.ClientName))
            throw new ClientNotFoundException(request.Username, request.ClientName);
        return _clients[request.Username][request.ClientName];
    }
}