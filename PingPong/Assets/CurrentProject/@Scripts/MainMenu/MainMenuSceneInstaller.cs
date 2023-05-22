using PM.UsefulThings;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class MainMenuSceneInstaller : MonoInstaller
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