using UnityEngine;

public class FindEntity : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _gunTransform;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            _transform.LookAt(entity.transform);
            _gunTransform.LookAt(entity.transform);
        }
    }

}
