using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindEntity : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private PlayerMovement _playerMovement;
    private List<GameObject> _entityList = new List<GameObject>();
    private GameObject _closestEntity;

    public UnityEvent<GameObject> ClosestEntityChanged;

    private void Awake()
    {
        ClosestEntityChanged.AddListener(OnClosestEntityChange);
    }

    private void OnDestroy()
    {
        ClosestEntityChanged.RemoveListener(OnClosestEntityChange);
    }

    private void FixedUpdate()
    {
        updateClosestEntity();

        if (_closestEntity)
        {
            Vector3 direction = _closestEntity.transform.position - _transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            if (_playerMovement)
                _playerMovement.TargetRotation = targetRotation;
        }
    }

    private void updateClosestEntity()
    {
        GameObject closestEntity = null;
        float minDistance = float.PositiveInfinity;

        foreach (GameObject entity in _entityList)
        {
            float distance = Vector3.Distance(_transform.position, entity.transform.position);
            minDistance = Mathf.Min(minDistance, distance);

            if (distance == minDistance)
                closestEntity = entity;
        }

        if (_closestEntity != closestEntity)
            ClosestEntityChanged.Invoke(closestEntity);
    }

    private void OnClosestEntityChange(GameObject entity)
    {
        _closestEntity = entity;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Entity>(out Entity entity))
        {
            _entityList.Add(entity.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Entity>(out Entity entity))
        {
            _entityList.Remove(entity.gameObject);
        }
    }
}
