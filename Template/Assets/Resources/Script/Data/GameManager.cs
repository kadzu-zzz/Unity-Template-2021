using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance()
    {
        return instance;
    }
    static GameManager instance = null;

    public SaveData data;

    private void Awake()
    {
        instance = this;
    }

    public void StopGame()
    {
        Destroy(gameObject);
        ProgramManager.Instance().GameStopped();
    }

    public void OnStart()
    {
        ProgramManager.Instance().GameStarted();
        data = SaveLoadHelper<SaveData>.Load("test_save");
        Debug.Log(data.test_data);
        data.test_data = 42;

        data.postLoad();
    }

    public void Cleanup()
    {
        SaveLoadHelper<SaveData>.Save(data);
    }

    private void Start()
    {
        OnStart();
    }

    private void OnDestroy()
    {
        Cleanup();
    }
}
