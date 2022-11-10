using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
class AutoTiler : MonoBehaviour
{
  public float xScaleMultiplier = 1;
  public float yScaleMultiplier = 1;

  public void Update()
  {
    MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
    meshRenderer.material.mainTextureScale = new Vector2(Mathf.Max(transform.localScale.x, transform.localScale.z) * xScaleMultiplier, transform.localScale.y * yScaleMultiplier);
  }
}