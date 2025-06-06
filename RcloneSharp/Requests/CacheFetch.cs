using System.Text.Json;

namespace RcloneSharp.Requests;

//TO DO!!
public class CacheFetch : Base
{

    public required List<string> Files { get; set; } = [];

    /// <summary>
    /// specifies the file chunks to check. It takes a comma separated list of array slice indices. The slice indices are similar to Python slices: start[:end]
    /// </summary>
    public required List<string> Chunks { get; set; } = [];

    public string ToJson()
    {
        Dictionary<string, string> dict = new()
        {
            { "chunks", string.Join(',', Chunks) }
        };

        for(int i =0; i < Files.Count; i++)
            dict.Add($"file{i}", Files[i]);

        return JsonSerializer.Serialize(dict);    
    }
}
