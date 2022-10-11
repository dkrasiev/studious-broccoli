using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _transformToMove;
    private Transform _transform;
    private Vector3 _startPosition;
    private Vector3 _difference;

    public void Start()
    {
        _transform = GetComponent<Transform>();
        _startPosition = _transform.position;
        _difference = _transform.position - _transformToMove.position;
    }

    public void Update()
    {
        _transform.position = _transformToMove.position;
        _transform.position += _difference;
        _transform.position = new Vector3(_transform.position.x, _startPosition.y, _transform.position.z);
    }
}
