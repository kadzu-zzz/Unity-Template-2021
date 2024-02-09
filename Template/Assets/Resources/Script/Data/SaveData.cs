using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData : AbstractDataFile, INamedDefault<SaveData>
{
    //More serialzied stuff goes here
    [SerializeField] public int test_data;
        
    public SaveData Default(string input)
    {
        SaveData data = new(input);

        data.test_data = -1;

        return data;
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
}
