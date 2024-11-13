namespace Perforce.Exceptions.ChangeListExceptions;

public class InvalidEditFileDoesntExistException(string file) : PerforceException
{
    public override string GetErrorMessage()
        => $"Invalid edit change: File {file} doesn't exists";
}