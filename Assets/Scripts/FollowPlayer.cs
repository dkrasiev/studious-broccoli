using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    [SerializeField] private int height;
    [SerializeField] private float lerpValue = .1f;
    [SerializeField] private bool useLookAt = false;

    private Transform _transform;

    public void Start() {
        _transform = GetComponent<Transform>();
    }

    public void LateUpdate() {
        Vector3 targetPosition = transformToFollow.position;
        targetPosition.y = height;

        MoveTo(targetPosition);

        if (useLookAt) {
            _transform.LookAt(transformToFollow);
        }
    }

    private void MoveTo(Vector3 targetPosition) {
        targetPosition.x = Mathf.Lerp(_transform.position.x, targetPosition.x, lerpValue);
        targetPosition.z = Mathf.Lerp(_transform.position.z, targetPosition.z, lerpValue);

        _transform.position = targetPosition;
    }
}
