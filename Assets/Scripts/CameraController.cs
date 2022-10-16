using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _transformToFollow;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private int _height;
    [SerializeField] private float _lerpSpeed = 1f;
    [SerializeField] private bool _useLookAt = false;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;

        _transform.position = getTargetPosition();
        _transform.LookAt(_transformToFollow);
    }

    private void LateUpdate()
    {
        moveTo(getTargetPosition());

        if (_useLookAt)
            _transform.LookAt(_transformToFollow);
    }

    private Vector3 getTargetPosition()
    {
        Vector3 targetPosition = _transformToFollow.position;
        targetPosition.y = _height;
        targetPosition += _offset;

        return targetPosition;
    }

    private void moveTo(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(targetPosition, _transform.position);

        targetPosition.x = Mathf.Lerp(_transform.position.x, targetPosition.x, Time.deltaTime * _lerpSpeed);
        targetPosition.z = Mathf.Lerp(_transform.position.z, targetPosition.z, Time.deltaTime * _lerpSpeed);

        _transform.position = targetPosition;
    }
}
