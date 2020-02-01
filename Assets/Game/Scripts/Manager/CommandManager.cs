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

    public static event Action onRepair;
    public static event Action onBreak;

    private bool _isRewinding;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        var decoysInScene = GameObject.FindObjectsOfType<Decoy>();
        foreach(var decoy in decoysInScene)
        {
            decoy.Break();
        }

        Repair();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Repair();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Break(GameObject.FindObjectOfType<Decoy>());
        }
    }

    public void Repair()
    {
        if (onRepair != null)
            onRepair();

       
    }

    public void Break(Decoy decoy)
    {
        decoy.Break();
        if (onBreak != null)
            onBreak();
    }
}
