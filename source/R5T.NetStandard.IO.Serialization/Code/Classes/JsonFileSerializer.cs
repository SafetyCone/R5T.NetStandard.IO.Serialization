using System;


namespace R5T.NetStandard.IO.Serialization
{
    public static class JsonFileSerializer
    {
        public static T Deserialize<T>(string jsonFilePath)
        {
            using (var fileStream = FileStreamHelper.NewRead(jsonFilePath))
            {
                var output = JsonStreamSerializer.Deserialize<T>(fileStream);
                return output;
            }
        }

        public static void Serialize<T>(string jsonFilePath, T obj, bool overwrite = true)
        {
            using (var fileStream = FileStreamHelper.NewWrite(jsonFilePath, overwrite))
            {
                JsonStreamSerializer.Serialize(fileStream, obj);
            }
        }
    }

    public class JsonFileSerializer<T> : FileSerializer<T>
    {
        public JsonFileSerializer()
            : base(new JsonStreamSerializer<T>())
        {
        }
    }
}
