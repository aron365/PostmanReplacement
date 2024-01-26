using Postman.Backup;
using Postman.Export;
using System.Text.Json;

namespace RestClient;

internal class Program
{
    static void Main(string[] args)
    {                
        var source = args[0];
        var targetFolder = args[1];
        var attr = File.GetAttributes(source);
        if(attr == FileAttributes.Directory)
        {
            var files = Directory.GetFiles(source).ToList();

            files.ForEach(f =>
            {
                Console.WriteLine($"Processing: {f}\n");
                var json = File.ReadAllText(f);
                var collection = JsonSerializer.Deserialize<PostmanCollection>(json);
                var requests = new HttpRequests(collection);
                requests.Output(targetFolder);
                ;
            });
        }
        else
        {            
            Console.WriteLine($"Processing: {source}\n");
            var json = File.ReadAllText(source);
            var backup = JsonSerializer.Deserialize<PostmanBackup>(json);
            ;
            backup.Collections
                .ToList()
                .ForEach(c =>
                {
                    var requests = new HttpRequests(c.Name, c);
                    requests.Output(targetFolder);
                });
            
        }
    }
}
