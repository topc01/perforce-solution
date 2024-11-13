namespace Perforce.Exceptions;

public class InvalidPathException(string filePath) : PerforceException
{
    public override string GetErrorMessage()
        => $"Invalid file path {filePath}";
}