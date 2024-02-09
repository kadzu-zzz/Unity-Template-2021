using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public static class FileManager<T> where T : AbstractDataFile, INamedDefault<T>
{
    public static T New(T fresh_file)
    {
        Write(fresh_file);
        return fresh_file;
    }

    public static T Load(T file_pointer)
    {
        return Read(file_pointer);
    }

    public static void Save(T data_file)
    {
        Write(data_file);
    }

    public static bool Has(T file_pointer)
    {
        return File.Exists(Application.persistentDataPath + file_pointer.GetFileName() + file_pointer.GetFileExtension());
    }

    static void Write(T data)
    {
        string file_name = Application.persistentDataPath + data.GetFileName() + data.GetFileExtension();
        if (File.Exists(file_name))
        {
            File.Delete(file_name);
        }

        XmlSerializer bf = new XmlSerializer(typeof(T));
        FileStream file = File.Open(file_name, FileMode.CreateNew);
        bf.Serialize(file, data);
        file.Close();
    }

    static T Read(T data)
    {
        string file_name = Application.persistentDataPath + data.GetFileName() + data.GetFileExtension();

        XmlSerializer bf = new XmlSerializer(typeof(T));
        FileStream file = File.Open(file_name, FileMode.Open);
        data = (T)bf.Deserialize(file);
        file.Close();
        return data;
    }
}

