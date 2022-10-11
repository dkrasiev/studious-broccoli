using UnityEngine;

public class AutoTiler : MonoBehaviour
{
    public float xScaleMultiplier = 1;
    public float yScaleMultiplier = 1;
    private Material _material;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterial.mainTextureScale = new Vector2(Mathf.Max(transform.localScale.x, transform.localScale.z) * xScaleMultiplier, transform.localScale.y * yScaleMultiplier);
    }
}