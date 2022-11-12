using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindEntity : MonoBehaviour
{
  [SerializeField] private Transform _transform;
  [SerializeField] private Transform _gunTransform;
  [SerializeField] private PlayerMovement _playerMovement;
  private List<Entity> _entityList = new();
  private Entity _closestEntity;

  public UnityEvent<Entity> ClosestEntityChanged;

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
    Entity closestEntity = null;
    float minDistance = float.PositiveInfinity;

    foreach (Entity entity in _entityList)
    {
      float distance = Vector3.Distance(_transform.position, entity.transform.position);
      minDistance = Mathf.Min(minDistance, distance);

      if (distance == minDistance)
        closestEntity = entity;
    }

    if (closestEntity && _closestEntity != closestEntity)
    {
      Debug.Log(closestEntity);
      ClosestEntityChanged.Invoke(closestEntity);
    }
  }

  private void OnClosestEntityChange(Entity entity)
  {
    _closestEntity = entity;
  }

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.TryGetComponent<Entity>(out Entity entity))
    {
      _entityList.Add(entity);
    }
  }

  private void OnTriggerExit(Collider collider)
  {
    if (collider.TryGetComponent<Entity>(out Entity entity))
    {
      _entityList.Remove(entity);
    }
  }
}
