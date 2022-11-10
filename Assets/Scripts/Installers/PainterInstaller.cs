using UnityEngine;
using Zenject;

public class PainterInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.Bind<Painter>().FromNew().AsSingle().NonLazy();
  }
}