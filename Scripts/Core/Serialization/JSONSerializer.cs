namespace HoodedCrow.uCore.Core
{
    using Newtonsoft.Json;

    public class JSONSerializer: ISerializer
    {
        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
