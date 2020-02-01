﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureExplosion : MonoBehaviour
{
    [SerializeField]
    Rigidbody[] fragments;
    [SerializeField]
    float _power;
    bool _init;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _init = true;        
    }

    private void FixedUpdate()
    {
        if (_init == true)
        {
            foreach (var fragment in fragments)
            {
                fragment.AddExplosionForce(_power, fragment.transform.position, 1);
            }

            _init = false;
        }
        
    }
}