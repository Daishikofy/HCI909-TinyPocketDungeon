using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour
{
    static GlobalGameState _instance;
    public static GlobalGameState Instance { get => _instance; }

    public GlobalGameData config;

    private void Awake()
    {
        if (_instance != null)
            Destroy(this);
        else
            _instance = this;
    }
}
