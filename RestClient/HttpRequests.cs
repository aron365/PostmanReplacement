using Postman.Backup;
using Postman.Export;

namespace RestClient;

public class HttpRequests
{
    private string folder;
    public List<HttpRequest> List { get; private set; }

    public HttpRequests(PostmanCollection collection)
    {
        folder = collection.Info.Name;
        List = collection.Item.Where(i => i.HasUrl).Select(i => new HttpRequest(i)).ToList();
    }

    public HttpRequests(string name, Collection backup)
    {
        folder = name;
        List = backup.Requests.Where(r => r.HasUrl).Select(r => new HttpRequest(r)).ToList();
    }

    public void Output(string rootFolder)
    {
        var target = Path.Combine(rootFolder, folder);
        List.ForEach(r => r.Output(target));
    }
}
