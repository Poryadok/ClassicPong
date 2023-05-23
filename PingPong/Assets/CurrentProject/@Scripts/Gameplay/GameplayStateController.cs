using PM.UsefulThings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplayStateController : MonoBehaviour
	{
		private PausePanel pausePanel;
		
		private WindowManagerUT windowManager;
		private GameplayLoopController gameplayLoopController;
		
		[Inject]
		public void Construct(GameplayLoopController gameplayLoopController, WindowManagerUT windowManagerUt)
		{
			this.gameplayLoopController = gameplayLoopController;
			windowManager = windowManagerUt;
		}

		public void Pause()
		{
			Time.timeScale = 0f;
			pausePanel = windowManager.OpenNewPanel<PausePanel>();
		}

		public void Unpause()
		{
			Time.timeScale = 1f;
		}

		public void StartGame()
		{
			gameplayLoopController.Init();
			gameplayLoopController.OnGameOver += OnGameOverHandler;
		}

		private void OnGameOverHandler()
		{
			Time.timeScale = 0f;
		}

		private void OnDisable()
		{
			Time.timeScale = 1f;
		}

		public void GoToMenu()
		{
			SceneManager.LoadScene("MainMenu");
		}

		public void Restart()
		{
			SceneManager.LoadScene("Gameplay");
		}
	}
}