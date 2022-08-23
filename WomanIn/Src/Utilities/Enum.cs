using System.Text.Json.Serialization;
namespace WomanInAPI.Src.Utilities
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        NORMAL,
        ADMIN,
        COMPANY
    }
}
