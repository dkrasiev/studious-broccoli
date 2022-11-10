using UnityEngine;

public class Painter
{
  public Color Color = Color.red;

  private Renderer _lastPaintedRenderer;
  private Color _lastPaintedRendererColor;

  public void Paint(GameObject gameObject, Color color)
  {
    if (gameObject == null)
    {
      if (_lastPaintedRenderer)
      {
        _lastPaintedRenderer.material.color = _lastPaintedRendererColor;
      }

      return;
    }

    Renderer renderer = gameObject.GetComponentInChildren<Renderer>();

    if (renderer)
    {
      if (_lastPaintedRenderer)
      {
        _lastPaintedRenderer.material.color = _lastPaintedRendererColor;
      }

      _lastPaintedRendererColor = renderer.material.color;
      renderer.material.color = Color;
      _lastPaintedRenderer = renderer;

    }
  }

  public void Paint(GameObject gameObject)
  {
    Paint(gameObject, Color);
  }
}
