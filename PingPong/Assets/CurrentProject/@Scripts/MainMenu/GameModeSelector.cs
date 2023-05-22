using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class GameModeSelector : MonoBehaviour
	{
		[Inject]
		public void Construct()
		{
			
		}

		public void PlaySolo()
		{
			LoadGameplayScene();
		}

		public void PlayWithBot()
		{
			LoadGameplayScene();
		}

		private void LoadGameplayScene()
		{
			SceneManager.LoadScene("Gameplay");
		}
	}
}