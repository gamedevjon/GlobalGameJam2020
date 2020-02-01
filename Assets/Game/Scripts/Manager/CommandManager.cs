using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;
    public static CommandManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Command Manager is NULL.");

            return _instance;
        }
    }

    public static event Action onRewind;

    private bool _isRewinding;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Repair();
        }
    }

    public void Repair()
    {
        if (onRewind != null)
            onRewind();
    }

    public void Break(Decoy decoy)
    {
        decoy.Break();
    }
}
