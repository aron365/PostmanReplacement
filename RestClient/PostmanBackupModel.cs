using System.Text.Json.Serialization;

namespace Postman.Backup;

public class PostmanBackup
{
    public int version { get; set; }
    [JsonPropertyName("collections")]
    public Collection[] Collections { get; set; }
    public Environment[] environments { get; set; }
    public object[] headerPresets { get; set; }
    public object[] globals { get; set; }
}

public class Collection
{
    public string id { get; set; }
    public string uid { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    public string description { get; set; }
    public object auth { get; set; }
    public Event[] events { get; set; }
    public Variable[] variables { get; set; }
    public string[] order { get; set; }
    public object[] folders_order { get; set; }
    public Protocolprofilebehavior protocolProfileBehavior { get; set; }
    public DateTime createdAt { get; set; }
    public object[] folders { get; set; }
    [JsonPropertyName("requests")]
    public Request[] Requests { get; set; }
}

public class Protocolprofilebehavior
{
}

public class Event
{
    public string listen { get; set; }
    public Script script { get; set; }
}

public class Script
{
    public string type { get; set; }
    public string[] exec { get; set; }
    public string id { get; set; }
}

public class Variable
{
    public string key { get; set; }
    public string value { get; set; }
    public string type { get; set; }
    public bool disabled { get; set; }
}

public class Request
{
    public string id { get; set; }
    public string uid { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }    
    public string description { get; set; }
    public object[] data { get; set; }
    public Dataoptions dataOptions { get; set; }
    public string dataMode { get; set; }
    [JsonPropertyName("headerData")]
    public Headerdata[] HeaderData { get; set; }
    [JsonPropertyName("method")]
    public string Method { get; set; }
    public object[] pathVariableData { get; set; }
    public Queryparam[] queryParams { get; set; }
    public Auth auth { get; set; }
    public object events { get; set; }
    public object folder { get; set; }
    public object[] responses_order { get; set; }
    public string currentHelper { get; set; }
    public Helperattributes helperAttributes { get; set; }
    public string collectionId { get; set; }
    public string headers { get; set; }
    public Pathvariables pathVariables { get; set; }
    [JsonPropertyName("rawModeData")]
    public string RawModeData { get; set; }

    public bool HasUrl => !string.IsNullOrWhiteSpace(Url);
}

public class Dataoptions
{
    public Raw raw { get; set; }
}

public class Raw
{
    public string language { get; set; }
}

public class Auth
{
    public string type { get; set; }
    public Basic[] basic { get; set; }
    public Oauth2[] oauth2 { get; set; }
}

public class Basic
{
    public string key { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Oauth2
{
    public string key { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Helperattributes
{
    public string id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string accessToken { get; set; }
    public string addTokenTo { get; set; }
    public string tokenType { get; set; }
}

public class Pathvariables
{
}

public class Headerdata
{
    [JsonPropertyName("key")]
    public string Key { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public bool enabled { get; set; }
}

public class Queryparam
{
    public string key { get; set; }
    public string value { get; set; }
    public bool equals { get; set; }
    public string description { get; set; }
    public bool enabled { get; set; }
}

public class Environment
{
    public string id { get; set; }
    public string name { get; set; }
    public object[] values { get; set; }
}
