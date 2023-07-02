using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
    [HideInInspector]
    public Contador Player;

    SpawnManager spawnManager;
    public void TerminateSession()
    {
        if (spawnManager != null)
        {
            spawnManager.StopSpawning();
        }

        gameObject.SetActive(false);
    }
}