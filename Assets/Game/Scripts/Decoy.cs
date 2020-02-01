using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoy : MonoBehaviour, IMovable
{
    [SerializeField]
    private GameObject _fractured;

    public void Break()
    {
        _fractured.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
