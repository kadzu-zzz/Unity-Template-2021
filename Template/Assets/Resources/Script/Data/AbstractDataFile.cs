using System;

public abstract class AbstractDataFile
{
    [NonSerialized] protected string file_name = "";

    public string GetFileName()
    {
        return file_name;
    }

    public abstract string GetFileExtension();
}
