using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpHeight = 10.0f;
    private float _gravity = 1.0f;
    private float _yVelocity;
    [SerializeField]
    private float _strength = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(h, 0, 0);
        Vector3 velocity = direction * _speed;

        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded == true)
        {
            _yVelocity = _jumpHeight;
        }

        _yVelocity -= _gravity;

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var movable = hit.collider.GetComponent<IMovable>();
        
        if (movable != null)
        {
            hit.collider.GetComponent<Rigidbody>().AddForce(hit.moveDirection * _strength);
            CommandManager.Instance.Break(hit.collider.GetComponent<Decoy>());
        }
    }
}
