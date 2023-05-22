using PM.UsefulThings;
using Zenject;

namespace PM.PingPong.General
{
	public class ProjectInstaller : MonoInstaller
	{
		public SoundManager SoundManagerPrefab;
		
		public override void InstallBindings()
		{
			// sound manager is a singleton, it doesn't like being a child
			var soundManagerInstance = Instantiate(SoundManagerPrefab);
			Container.Bind<SoundManager>()
				.FromInstance(soundManagerInstance)
				.AsSingle()
				.NonLazy();
		}
	}
}