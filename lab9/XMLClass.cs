using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

class XMLfile<T> : FileSerandDes<T>
{
    public override void Serialize(T t, string filePath)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, t);
        }
    }
    public override T Deserialize(string filePath)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            T t = (T)xmlSerializer.Deserialize(fs);
            return t;
        }
    }
}