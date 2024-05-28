using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinaryFile<T> : FileSerandDes<T>
{
    public override void Serialize(T type, string fileName)
    {
        using (FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            Serializer.Serialize(writer, type);
        }
    }
    public override T Deserialize(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            return Serializer.Deserialize<T>(fs);
        }
    }
}