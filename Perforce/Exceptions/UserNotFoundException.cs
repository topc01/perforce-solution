namespace Perforce.Exceptions;

public class UserNotFoundException(string userName) : PerforceException
{
    public override string GetErrorMessage()
        => $"User {userName} not found";
}