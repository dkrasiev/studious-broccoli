using Zenject;

public class PlayerActionsInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    var actions = new PlayerInputActions();
    actions.Player.Enable();

    Container.Bind<PlayerInputActions>().FromInstance(actions).AsSingle().NonLazy();
  }
}