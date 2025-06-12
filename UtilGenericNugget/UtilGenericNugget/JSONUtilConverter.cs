using Newtonsoft.Json;

namespace UtilGenericNugget;

public static class JSONUtilConverter
{

    public static string GetJsonRepresentation(object obj)
    {

        return JsonConvert.SerializeObject(obj, Formatting.Indented);

    }

}
