using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class TestType : ISaveLoad<TestType, SaveData>
{

    [SerializeField] public int test_data;

    public TestType Default()
    {
        TestType def = new();

        def.test_data = 42;

        return def;
    }

    public void Load(SaveData data)
    {
        data.test_type = this;
    }

    public void postLoad(SaveData data)
    {
        Debug.Log(data.test_type.test_data);
    }

    public void Save(SaveData data)
    {
        test_data = data.test_type.test_data;
    }
}
