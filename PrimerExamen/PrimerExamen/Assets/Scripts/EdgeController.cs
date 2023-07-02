using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI eliminated;

    SessionManager _sessionManager;

    void Awake()
    {
        _sessionManager = SessionManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisiono");
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

            _sessionManager = SessionManager.Instance;
            _sessionManager.Player.Incrementar();
        }
    }


}
