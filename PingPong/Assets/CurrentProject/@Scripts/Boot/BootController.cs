using PM.UsefulThings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PM.PingPong.Boot
{
	public class BootController : MonoBehaviour
	{
		private WindowManagerUT windowManager;

		[Inject]
		public void Construct(WindowManagerUT windowManager)
		{
			this.windowManager = windowManager;
		}

		private void Start()
		{
			windowManager.OpenNewPanel<BootPanel>();
			SceneManager.LoadSceneAsync("MainMenu");
		}
	}
}