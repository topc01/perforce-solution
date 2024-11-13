using Perforce.Validators;
using VersionControlSystem;

namespace Perforce;

public class ChangeList
{
    private readonly ValidatorFactory _factory = new();
    private readonly List<Change> _changes = new();

    public ChangeList(string type, string[] filePaths)
    {
        for (int i = 0; i < filePaths.Length; i++)
            _changes.Add(new Change(type, filePaths[i], null));
    }

    public ChangeList(string type, string[] filePaths, string[] contents)
    {
        for (int i = 0; i < filePaths.Length; i++)
            _changes.Add(new Change(type, filePaths[i], contents[i]));
    }

    public ChangeList() {

    }

    public object GetPathByIndex(int index)
        => _changes[index].Path;

    public bool IsEmpty()
        => _changes.Count == 0;
    
    public void ApplyChanges(VersionSystem versionSystem, string depot)
    {
        Validate(versionSystem, depot);
        foreach (var change in _changes)
        {
            FilePath path = FilePath.Combine(depot, change.Path);
            versionSystem.Add(path, change.Content);
        }
    }
    
    private void Validate(VersionSystem versionSystem, string depot)
    {
        foreach (var change in _changes)
        {
            IValidator validator = _factory.Create(versionSystem, depot, change.ChangeType);
            validator.Validate(change);
        }
    }

}