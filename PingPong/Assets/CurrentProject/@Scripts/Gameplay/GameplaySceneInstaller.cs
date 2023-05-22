using PM.UsefulThings;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public WindowManagerUT WindowManager;
		
		public override void InstallBindings()
		{
			Container.Bind<WindowManagerUT>()
				.FromInstance(WindowManager)
				.AsSingle()
				.NonLazy();
		}
	}
}