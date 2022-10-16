using UnityEngine;

class Rotate : MonoBehaviour
{
    public float rotationSpeed;
    public float scaledSpeed => rotationSpeed * Time.deltaTime;
    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
