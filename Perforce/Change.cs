namespace Perforce;

class Change(string changeType, string path, string? content)
{
    public string ChangeType { get; } = changeType;
    public string Path { get; } = path;
    public string? Content { get; } = content;
}