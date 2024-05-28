using System;

abstract class FileSerandDes<T>
{
    public abstract void Serialize(T type, string fileName);
    public abstract T Deserialize(string fileName);
}