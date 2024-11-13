using Perforce.Exceptions.ChangeListExceptions;
using VersionControlSystem;

namespace Perforce.Validators;

class AddValidator(VersionSystem versionSystem, string depot) : IValidator
{
    public void Validate(Change change)
    {
        FilePath path = FilePath.Combine(depot, change.Path);
        if (versionSystem.Exists(path))
            throw new InvalidAddFileExistsException(change.Path);
        if (change.Content == null)
            throw new InvalidAddFileIsEmptyException(change.Path);
    }
}