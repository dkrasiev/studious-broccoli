using UnityEngine;
using Zenject;

public class EntityPainter : MonoBehaviour
{
  public FindEntity entityFinder;

  [Inject]
  private Painter painter;

  public void PaintEntity(Entity entity)
  {
    painter.Paint(entity.gameObject);
  }

  private void OnEnable()
  {
    entityFinder.ClosestEntityChanged.AddListener(PaintEntity);

  }

  private void OnDisable()
  {
    entityFinder.ClosestEntityChanged.RemoveListener(PaintEntity);
  }
}
