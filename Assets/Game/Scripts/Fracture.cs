using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    private int _maxFrames = 85;
    private int _currentFrame;
    private Rigidbody _rigid;
    [SerializeField]
    private List<FracturedCommand> _commands = new List<FracturedCommand>();
    [SerializeField]
    private GameObject _decoy;
    // Start is called before the first frame update
    void OnEnable()
    {
        CommandManager.onRepair += StartRewind;
        _rigid = GetComponent<Rigidbody>();
        _rigid.isKinematic = false;
        _rigid.useGravity = true;
        _rigid.GetComponent<Collider>().enabled = true;
    }

    private void OnDisable()
    {
        CommandManager.onRepair -= StartRewind;
        _currentFrame = 0;
        _commands.Clear();
    }

    private void StartRewind()
    {
        StartCoroutine(RewindRoutine());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_currentFrame < _maxFrames)
        {
            _currentFrame++;
            FracturedCommand newCommand = new FracturedCommand(transform.localPosition, transform.rotation, _rigid);
            _commands.Add(newCommand);
        }   
    }

    IEnumerator RewindRoutine()
    {
        for(int i = _commands.Count -1; i >= 0; i--)
        {
            Debug.Log("Rewinding: " + i);
            yield return null;
            _commands[i].Undo();
        }

        if (_decoy.activeInHierarchy == false)
        {
            _decoy.SetActive(true);
            _decoy.transform.position = transform.parent.position;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
