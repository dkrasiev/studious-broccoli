using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject objectToFollow;

    private Transform _transform;
    private Transform _objectTransform;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _objectTransform = objectToFollow.GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 objectPosition = _objectTransform.position;
        objectPosition.y = 10;
        _transform.position = objectPosition;

        _transform.LookAt(_objectTransform);
    }
}
