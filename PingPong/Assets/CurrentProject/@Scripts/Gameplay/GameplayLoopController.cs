using UnityEngine;
using UnityEngine.SceneManagement;

namespace PM.PingPong.Gameplay
{
	public class GameplayLoopController : MonoBehaviour
	{
		public void RegisterBall()
		{
			
		}

		public void Quit()
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}