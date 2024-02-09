using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramManager : MonoBehaviour
{
    public static ProgramManager Instance()
    {
        return instance;
    }
    static ProgramManager instance = null;

    public ProgramData data;

    private void Awake()
    {
        instance = this;        
    }

    public void OnStart()
    {
        data = SaveLoadHelper<ProgramData>.Load("");
        Debug.Log(data.example_program_setting);
        data.example_program_setting = 42;

        data.postLoad();
        Instantiate<GameObject>(Resources.Load<GameObject>("Prefab/Management/GameManager"));
    }

    public void Cleanup()
    {
        SaveLoadHelper<ProgramData>.Save(data);
    }

    public void GameStarted()
    {

    }

    public void GameStopped()
    {

    }

    private void Start()
    {
        OnStart();
    }

    private void OnApplicationQuit()
    {
        Cleanup();
    }
}
