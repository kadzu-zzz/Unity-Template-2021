using System;
using UnityEngine;

[Serializable]
public class ProgramData : AbstractDataFile, INamedDefault<ProgramData>
{
    //More serialzied stuff goes here
    [SerializeField] public int example_program_setting;
    
    public ProgramData Default(string input)
    {
        ProgramData data = new();

        data.example_program_setting = -1;

        return data;
    }

    public ProgramData()
    {
        file_name = "application_settings";
    }

    public override string GetFileExtension()
    {
        return ".dat";
    }
}
