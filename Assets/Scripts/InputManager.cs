using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] bool _needJoystick = false;

    [SerializeField] GameObject joystick;
    [SerializeField] RectTransform stick;

    private Vector2 startStickPos;

    private float horizontal;
    private float vertical;

    private void Start()
    {
        startStickPos = stick.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_needJoystick)
        {
            //if(Input.(0))_
            horizontal = startStickPos.x - stick.position.x;
            vertical = startStickPos.y - stick.position.y;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        _movement.Move(new Vector3(horizontal, 0, vertical));
    }
}
