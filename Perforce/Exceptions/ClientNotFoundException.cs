namespace Perforce.Exceptions;

public class ClientNotFoundException(string userName, string clientName) : PerforceException
{
    public override string GetErrorMessage()
        => $"User {userName} doesn't have client {clientName}";
}