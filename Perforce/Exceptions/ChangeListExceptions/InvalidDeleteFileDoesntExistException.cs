namespace Perforce.Exceptions.ChangeListExceptions;

public class InvalidDeleteFileDoesntExistException(string file) : PerforceException
{
    public override string GetErrorMessage()
        => $"Invalid delete change: File {file} doesn't exists";
}