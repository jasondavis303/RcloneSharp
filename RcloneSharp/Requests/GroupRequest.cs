using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class GroupRequest : Base
{
    public required string RequestGroup { get; set; }
}
