using VersionControlSystem;

namespace Perforce;

public class VersionSystem
{
    private IComponent _root;
    
    public VersionSystem(string rootPath)
    {
        _root = new VersionControlSystem.Directory();
        string[] paths = System.IO.Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
        foreach (var path in paths)
            AddFileToRoot(rootPath, path);
    }

    private void AddFileToRoot(string rootPath, string path)
    {
        IEnumerable<string> lines = File.ReadLines(path);
        string content = string.Join("\n", lines);
        _root.Add(FilePath.RemovePrefix(path, rootPath), content);
    }

    public void Add(FilePath filePath, string? content)
        => _root.Add(filePath, content);

    public bool Exists(FilePath path)
        => _root.Exists(path);

    public Files Get(FilePath path, string pathToFile)
        => _root.Get(path, pathToFile);

}