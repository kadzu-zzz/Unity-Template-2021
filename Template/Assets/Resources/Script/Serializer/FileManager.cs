using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public static class FileManager<T> where T : AbstractDataFile, INamedDefault<T>, IFileSaveLoad
{
    public static void New(ref T fresh_file)
    {
        Write(ref fresh_file);
    }

    public static void Load(ref T file_pointer)
    {
        Read(ref file_pointer);
        file_pointer.Load();
    }

    public static void Save(T data_file)
    {
        data_file.Save();
        Write(ref data_file);
    }

    public static bool Has(T file_pointer)
    {
        string path = Application.persistentDataPath + file_pointer.GetFilePathAddition() + file_pointer.GetFileName() + file_pointer.GetFileExtension();
        return File.Exists(path);
    }

    static void Write(ref T data)
    {
        string path = Application.persistentDataPath + data.GetFilePathAddition();
        string file_name = data.GetFileName() + data.GetFileExtension();
        Directory.CreateDirectory(path);
        file_name = path + file_name;
        if (File.Exists(file_name))
        {
            File.Delete(file_name);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(file_name, FileMode.CreateNew);
        bf.Serialize(file, data);
        file.Close();
    }

    static void Read(ref T data)
    {
        string path = Application.persistentDataPath + data.GetFilePathAddition();
        string file_name = data.GetFileName() + data.GetFileExtension();
        Directory.CreateDirectory(path);
        file_name = path + file_name;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(file_name, FileMode.Open);
        data = (T)bf.Deserialize(file);
        file.Close();
    }
}

