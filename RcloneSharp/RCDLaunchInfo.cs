namespace RcloneSharp;

/// <summary>
/// Useful for launching rclone rcd. This is NOT an exhaustive list of options, just a helper
/// </summary>
public class RCDLaunchInfo
{
    public string RcloneExe { get; set; } = "rclone" + (Environment.OSVersion.Platform == PlatformID.Win32NT ? ".exe" : string.Empty);

    public string Host { get; set; } = "localhost";

    public int Port { get; set; } = 5572;

    /// <summary>
    /// By default rclone will require authorisation to have been set up on the 
    /// rc interface in order to use any methods which access any rclone remotes
    /// </summary>
    public bool NoAuth { get; set; }

    public string? User { get; set; }

    public string? Password { get; set; }

    /// <summary>
    /// Enable the serving of remote objects via the HTTP interface. 
    /// This means objects will be accessible at http://127.0.0.1:5572/ by default, 
    /// so you can browse to http://127.0.0.1:5572/ or http://127.0.0.1:5572/* to 
    /// see a listing of the remotes. Objects may be requested from remotes using 
    /// this syntax http://127.0.0.1:5572/[remote:path]/path/to/object
    /// </summary>
    public bool Serve { get; set; }


    public string BuildArgs()
    {
        string ret = string.Empty;

        string hp = $"{Host}:{Port}";
        if (hp != "localhost:5572")
            ret += $" --rc-addr {hp}";


        if (NoAuth)
        {
            ret += " --rc-no-auth";
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(User))
                if (!string.IsNullOrWhiteSpace(Password))
                    ret += $" --user \"{User}\" --pass \"{Password}\"";
        }

        if (Serve)
            ret += " --rc-serve";

        return " rcd " + ret.Trim();
    }


    public override string ToString() => BuildArgs();
}
