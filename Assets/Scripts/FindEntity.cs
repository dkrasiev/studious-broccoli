using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEntity : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _gunTransform;
    private List<Entity> _entityList = new List<Entity>();
    private Entity _closestEntity;

    private void FixedUpdate()
    {
        updateClosestEntity();

        if (_closestEntity && _transform.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            Vector3 direction = _closestEntity.transform.position - _transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            playerMovement.SetTargetRotation(targetRotation);

            Debug.DrawRay(_transform.position, direction);
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
            {
                closestEntity = entity;
            }
        }

        if (_closestEntity != null && _closestEntity != closestEntity)
            _closestEntity.GetComponent<Renderer>().material.color = Color.white;


        _closestEntity = closestEntity;
        if (closestEntity)
            _closestEntity.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            _entityList.Add(entity);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            _entityList.Remove(entity);
        }
    }
}
