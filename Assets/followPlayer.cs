using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    [SerializeField] private int height;

    private Transform _transform;

    void Start() {
        _transform = GetComponent<Transform>();
    }

    void Update() {
        Vector3 targetPosition = transformToFollow.position;
        targetPosition.y = height;

        _transform.position = targetPosition;

        _transform.LookAt(transformToFollow);
    }
}
