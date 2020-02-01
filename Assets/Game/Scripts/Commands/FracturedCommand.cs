using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FracturedCommand : ICommand
{
    private Vector3 _pos;
    private Quaternion _rotation;
    private Rigidbody _fragment;

    public FracturedCommand(Vector3 pos, Quaternion rotation, Rigidbody fragment)
    {
        this._pos = pos;
        this._rotation = rotation;
        this._fragment = fragment;
    }

    public void Execute()
    {
     
    }

    public void Undo()
    {
        _fragment.GetComponent<Collider>().enabled = false;
        _fragment.useGravity = false;
        _fragment.isKinematic = true;
        _fragment.position = _pos;
        _fragment.rotation = _rotation;
    }
}
