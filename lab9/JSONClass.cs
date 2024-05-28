using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class JSONfile<T> : FileSerandDes<T>
{
    public override void Serialize(T type, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, type);
        }
    }
    public override T Deserialize(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}