using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplayLoopController : MonoBehaviour
	{
		public Transform RocketTop;
		public Transform RocketBottom;
		public Collider GoalTop;
		public Collider GoalBottom;
		public Rigidbody Ball;

		private InputFacade inputFacade;

		[Inject]
		public void Construct(InputFacade inputFacade)
		{
			this.inputFacade = inputFacade;
		}

		private void Start()
		{
			Init();
		}

		public void Init()
		{
			Ball.velocity = Vector3.back * 10f;
			inputFacade.OnMove += OnMoveHandler;
		}

		private void OnMoveHandler(float value)
		{
			RocketBottom.position += value * Time.deltaTime * 15f * Vector3.right;
			RocketTop.position += value * Time.deltaTime * 15f * Vector3.right;
		}


		public void Quit()
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}