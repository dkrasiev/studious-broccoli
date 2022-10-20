using UnityEngine;

public class Painter : MonoBehaviour
{
    public Color Color = Color.red;

    private Renderer _lastPaintedRenderer;
    private Color _lastPaintedRendererColor;

    public void Paint(GameObject gameObj)
    {
        if (gameObj == null)
        {
            if (_lastPaintedRenderer)
            {
                _lastPaintedRenderer.material.color = _lastPaintedRendererColor;
            }

            return;
        }

        Renderer renderer = gameObj.GetComponentInChildren<Renderer>();

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
}
