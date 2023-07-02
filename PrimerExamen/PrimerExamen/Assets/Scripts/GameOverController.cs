using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI eliminated;

    [SerializeField]
    TextMeshProUGUI recordd;

    SessionManager _sessionManager;
    EdgeController _var;

    void Awake()
    {
        _sessionManager = SessionManager.Instance;
       
    }
    void TerminateSessionT()
    {
        _sessionManager.TerminateSession();
    }
    

    void Start()
    {
        int intentoActual = _sessionManager.Player.Puntos;
        int logrosActual = PlayerPrefs.GetInt("BestRecord", 0);

        if (intentoActual > logrosActual)
        {
            PlayerPrefs.SetInt("BestRecord", intentoActual);
        }
        eliminated.text = intentoActual.ToString();
        recordd.text = logrosActual.ToString();

        TerminateSessionT();
    }


}
