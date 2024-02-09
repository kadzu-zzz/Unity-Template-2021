using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData : AbstractDataFile, INamedDefault<SaveData>, IFileSaveLoad
{
    //More serialzied stuff goes here
    [SerializeField] public int test_data;

    [SerializeField] public TestType test_type;
        
    public SaveData Default(string input)
    {
        SaveData data = new(input);

        data.test_data = -1;
        data.test_type = new TestType().Default();

        return data;
    }

    public void Save()
    {
        test_type.Save(this);
    }

    public void Load()
    {
        test_type.Load(this);
    }

    public void postLoad()
    {
        test_type.postLoad(this);
    }

    public SaveData() { }
    public SaveData(string input)
    {
        file_name = input;
    }

    public override string GetFileExtension()
    {
        return ".sav";
    }
    public override string GetFilePathAddition()
    {
        return "/" + file_name + "/";
    }
}
