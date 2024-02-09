
//Serialization for Non Monobehaviours.
public interface ISaveLoad : IDefault<ISaveLoad>
{
    public void Save(ref AbstractDataFile data);
    public void Load(AbstractDataFile data);

    public void postLoad(AbstractDataFile data);

}
