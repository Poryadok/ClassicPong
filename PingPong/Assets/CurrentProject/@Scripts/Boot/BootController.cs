using UnityEngine;
using UnityEngine.SceneManagement;

namespace PM.PingPong.Boot
{
	public class BootController : MonoBehaviour
	{
		private void Start()
		{
			SceneManager.LoadSceneAsync("MainMenu");
		}
	}
}