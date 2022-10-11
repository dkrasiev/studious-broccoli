using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _transformToFollow;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private int _height;
    [SerializeField] private float _lerpValue = .1f;
    [SerializeField] private float _minLerpDistance = 1f;
    [SerializeField] private bool _useLookAt = false;

    private Transform _transform;
    private Vector3 _targetPosition
    {
        get
        {
            Vector3 targetPosition = _transformToFollow.position;
            targetPosition.y = _height;
            targetPosition += _offset;

            return targetPosition;
        }
    }

    public void Start()
    {
        _transform = GetComponent<Transform>();

        _transform.position = _targetPosition;
        _transform.LookAt(_transformToFollow);
    }

    public void LateUpdate()
    {
        moveTo(_targetPosition);

        if (_useLookAt)
        {
            _transform.LookAt(_transformToFollow);
        }
    }

    private void moveTo(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(targetPosition, _transform.position);
        
        if (distance > _minLerpDistance) {
            targetPosition.x = Mathf.Lerp(_transform.position.x, targetPosition.x, _lerpValue);
            targetPosition.z = Mathf.Lerp(_transform.position.z, targetPosition.z, _lerpValue);
        }

        _transform.position = targetPosition;
    }
}
