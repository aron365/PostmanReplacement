using System.Text.Json.Serialization;

namespace Postman.Export;

public class PostmanCollection
{
    [JsonPropertyName("info")]
    public Info Info { get; set; }
    [JsonPropertyName("item")]
    public Item[] Item { get; set; }
}

public class Info
{
    [JsonPropertyName("_postman_id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("schema")]
    public string Schema { get; set; }
}

public class Item
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("request")]
    public Request Request { get; set; }
    [JsonPropertyName("response")]
    public object[] Response { get; set; }

    public bool HasUrl => !string.IsNullOrWhiteSpace(Request.Url?.Raw);
}

public class Request
{
    [JsonPropertyName("method")]
    public string Method { get; set; }
    [JsonPropertyName("header")]
    public Header[] Header { get; set; }
    [JsonPropertyName("body")]
    public Body Body { get; set; }
    [JsonPropertyName("url")]
    public Url Url { get; set; }
}

public class Body
{
    [JsonPropertyName("mode")]
    public string Mode { get; set; }
    [JsonPropertyName("raw")]
    public string Raw { get; set; }
}

public class Url
{
    [JsonPropertyName("raw")]
    public string Raw { get; set; }
    [JsonPropertyName("protocol")]
    public string Protocol { get; set; }
    [JsonPropertyName("host")]
    public string[] Host { get; set; }
    [JsonPropertyName("port")]
    public string Port { get; set; }
    [JsonPropertyName("path")]
    public string[] Path { get; set; }
    [JsonPropertyName("query")]
    public Query[] Query { get; set; }
}

public class Query
{
    [JsonPropertyName("key")]
    public string Key { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Header
{
    [JsonPropertyName("key")]
    public string Key { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
}
