using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISerialize<Concrete, Data> where Data : IDefault<Data>
{
    public Concrete Deserialize(Data data, Transform parent);
    public Data Serialize(Concrete conc);
}
