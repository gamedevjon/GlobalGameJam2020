using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    private int maxFrames = 85;
    private int currentFrame;
    private Rigidbody _rigid;
    [SerializeField]
    private List<FracturedCommand> _commands = new List<FracturedCommand>();
    [SerializeField]
    private GameObject _decoy;
    // Start is called before the first frame update
    void OnEnable()
    {
        CommandManager.onRewind += StartRewind;
        _rigid = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        CommandManager.onRewind -= StartRewind;
    }

    private void StartRewind()
    {
        StartCoroutine(RewindRoutine());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentFrame < maxFrames)
        {
            currentFrame++;
            FracturedCommand newCommand = new FracturedCommand(transform.position, transform.rotation, _rigid);
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
            transform.parent.gameObject.SetActive(false);
        }
    }
}
