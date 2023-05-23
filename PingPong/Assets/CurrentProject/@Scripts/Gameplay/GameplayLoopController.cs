using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplayLoopController : MonoBehaviour
	{
		public event Action<Vector2Int> OnScoreChanged;

		public Vector2Int Score;
		
		public Rigidbody RocketTop;
		public Rigidbody RocketBottom;
		public Goal GoalTop;
		public Goal GoalBottom;
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
			
			GoalTop.OnGoal += OnTopGoalHandler;
			GoalBottom.OnGoal += OnBottomGoalHandler;
		}

		private void OnDestroy()
		{
			inputFacade.OnMove -= OnMoveHandler;
			GoalTop.OnGoal -= OnTopGoalHandler;
			GoalBottom.OnGoal -= OnBottomGoalHandler;
		}

		private void OnTopGoalHandler()
		{
			ChangeScore(1);
		}
		private void OnBottomGoalHandler()
		{
			ChangeScore(-1);
		}

		private void ChangeScore(int change)
		{
			Score = new Vector2Int(Score.x + (change > 0 ? 1 : 0), Score.y + (change < 0 ? 1 : 0));
			OnScoreChanged?.Invoke(Score);
		}

		private void OnMoveHandler(float value)
		{
			if (value == 0)
			{
				RocketBottom.velocity = RocketBottom.velocity.normalized * (RocketBottom.velocity.magnitude * 0.95f);
				RocketTop.velocity = RocketTop.velocity.normalized * (RocketTop.velocity.magnitude * 0.95f);
			}
			else
			{
				RocketBottom.velocity += value * Time.deltaTime * 50f * Vector3.right;
				RocketTop.velocity += value * Time.deltaTime * 50f * Vector3.right;
			}
			
			if (RocketBottom.velocity.magnitude > 15f)
			{
				RocketBottom.velocity = RocketBottom.velocity.normalized * 15f;
			} 
			if (RocketTop.velocity.magnitude > 15f)
			{
				RocketTop.velocity = RocketTop.velocity.normalized * 15f;
			} 
		}


		public void Quit()
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}