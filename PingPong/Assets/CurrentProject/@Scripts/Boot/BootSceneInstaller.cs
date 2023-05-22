using PM.UsefulThings;
using Zenject;

namespace PM.PingPong.Boot
{
	public class BootSceneInstaller : MonoInstaller
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