#region

using Eos.Gameplay.Context.Scene;
using Eos.Gameplay.Player.Handler;
using Eos.Utils.Debug;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Main
{
    public class PlayerInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<APlayer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ACharacter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ACameraPitchYaw>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesTo<MessageDisplay>().FromComponentInHierarchy().AsSingle();
            Container.Bind<InputState>().AsSingle();
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<CameraHandler>().AsSingle();
            Container.BindInterfacesTo<CharacterHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerInputDebugger>().AsSingle();
        }

        #endregion
    }
}