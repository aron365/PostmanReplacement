using Postman.Export;
using System.Text;
using System.Text.RegularExpressions;

namespace RestClient;

public class HttpRequest
{    
    private readonly string extension = "http";
    private readonly string version = "HTTP/1.1";
    private readonly Regex regex = new Regex(@"https:\/\/(?<host>[^\/]+)(?<path>\/.+)");
   
    public string Name { get; set; }
    public string Method { get; set; }
    public string PathAndQuery { get; set; }
    public string Command => $"{Method} {PathAndQuery} {version}";
    public string Host { get; set; }    
    public int ContentLength {  get; set; }
    public string Body { get; set; }
    public Uri Uri { get; set; }
    public List<string> Headers = new List<string>()
    {
        "Content-Type: application/json"
    };

    public string HostToken => $"Host: {Host}";
    public string LengthToken => $"ContentLength: {ContentLength}";

    public bool HasBody => !string.IsNullOrWhiteSpace(Body);
    
    public HttpRequest(Item item)
    {
        Name = item.Name;
        Uri = new Uri(item.Request.Url.Raw);
        Host = $"{Uri.Host}:{Uri.Port}";
        PathAndQuery = Uri.PathAndQuery;
        Method = item.Request.Method;
        Headers.AddRange(item.Request.Header.Select(h => $"{h.Key}: {h.Value}"));
        Body = item.Request?.Body?.Raw?.Replace("\t", "    ");
        ContentLength = Body?.Length ?? 0;
        Console.WriteLine(ToString());
        ;
    }

    public HttpRequest(Postman.Backup.Request req)
    {
        Name = req.Name;
        Uri = new Uri(req.Url);
        Host = $"{Uri.Host}:{Uri.Port}";
        PathAndQuery = Uri.PathAndQuery;
        Method = req.Method;
        Headers.AddRange(req.HeaderData.Select(h => $"{h.Key}: {h.Value}"));
        Body = req.RawModeData?.Replace("\t", "    ");
        ContentLength = Body?.Length ?? 0;
        Console.WriteLine(ToString());
        ;
    }

    public void Output(string folder)
    {
        Directory.CreateDirectory(folder);        
        File.WriteAllText(getFileName(folder), ToString()); ;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Command);
        sb.AppendLine(HostToken);
        sb.AppendLine(string.Join("\n", Headers));
        if(HasBody)
        {
            sb.AppendLine(LengthToken);
            sb.AppendLine();
            sb.AppendLine(Body);
        }
        
        return sb.ToString();
    }

    private string getFileName(string folder)
    {
        var name = $"{Name.Replace("/", "-")}.{extension}";
        return Path.Combine(folder, name);
    }
}
