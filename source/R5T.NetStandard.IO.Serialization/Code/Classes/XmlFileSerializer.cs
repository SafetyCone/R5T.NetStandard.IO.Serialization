using System;


namespace R5T.NetStandard.IO.Serialization
{
    public static class XmlFileSerializer
    {
        public static T Deserialize<T>(string xmlFilePath)
        {
            using (var fileStream = FileStreamHelper.NewRead(xmlFilePath))
            {
                var output = XmlStreamSerializer.Deserialize<T>(fileStream);
                return output;
            }
        }

        public static void Serialize<T>(string xmlFilePath, T obj, bool overwrite = true)
        {
            using (var fileStream = FileStreamHelper.NewWrite(xmlFilePath, overwrite))
            {
                XmlStreamSerializer.Serialize(fileStream, obj);
            }
        }
    }


    public class XmlFileSerializer<T> : FileSerializer<T>
    {
        public XmlFileSerializer()
            : base(new XmlStreamSerializer<T>())
        {
        }
    }
}
