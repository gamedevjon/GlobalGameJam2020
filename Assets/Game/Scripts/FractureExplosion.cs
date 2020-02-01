using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureExplosion : MonoBehaviour
{
    [SerializeField]
    Rigidbody[] fragments;
    [SerializeField]
    float _power;
    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (var fragment in fragments)
        {
            fragment.AddExplosionForce(_power, fragment.transform.position, 1);
        }
    }
    

}
