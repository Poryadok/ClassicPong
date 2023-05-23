using System;
using PM.PingPong.General;
using PM.UsefulThings;
using PM.UsefulThings.Extensions;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace PM.PingPong.Gameplay
{
	public class GameplayLoopController : MonoBehaviour
	{
		public event Action<Vector2Int> OnScoreChanged;
		public event Action OnGameOver;

		public Vector2Int Score;

		public Rocket RocketTop;
		public Rocket RocketBottom;
		public Goal GoalTop;
		public Goal GoalBottom;
		public Rigidbody Ball;
		public Wall[] Walls;

		private bool isInitialized;
		
		private GameModeSettings settings;

		private InputFacade inputFacade;
		private GeneralConfigHolder generalConfigHolder;
		private GameplayConfigHolder gameplayConfigHolder;
		private WindowManagerUT windowManager;
		
		[Inject]
		public void Construct(InputFacade inputFacade, GeneralConfigHolder generalConfigHolder,
			GameplayConfigHolder gameplayConfigHolder, WindowManagerUT windowManagerUt)
		{
			this.inputFacade = inputFacade;
			this.generalConfigHolder = generalConfigHolder;
			this.gameplayConfigHolder = gameplayConfigHolder;
			windowManager = windowManagerUt;
		}

		public void Init()
		{
			settings = generalConfigHolder.GameModeSettings.Find(x =>
				x.GameMode == generalConfigHolder.GameSettings.GameMode);
			
			ResetBall();

			GoalTop.OnGoal += OnTopGoalHandler;
			GoalBottom.OnGoal += OnBottomGoalHandler;

			foreach (var wall in Walls)
			{
				wall.OnHit += OnWallHitHandler;
			}

			isInitialized = true;
		}

		private void FixedUpdate()
		{
			if (!isInitialized)
				return;
			
			MoveRocket(RocketTop);
			MoveRocket(RocketBottom);
		}

		private void OnWallHitHandler()
		{
			ResetBall();
		}

		private void OnDestroy()
		{
			GoalTop.OnGoal -= OnTopGoalHandler;
			GoalBottom.OnGoal -= OnBottomGoalHandler;

			foreach (var wall in Walls)
			{
				wall.OnHit -= OnWallHitHandler;
			}
		}

		private void OnTopGoalHandler()
		{
			ResetBall();
			ChangeScore(1);
		}

		private void OnBottomGoalHandler()
		{
			ResetBall();
			ChangeScore(-1);
		}

		private void ChangeScore(int change)
		{
			Score = new Vector2Int(Score.x + (change > 0 ? 1 : 0), Score.y + (change < 0 ? 1 : 0));
			OnScoreChanged?.Invoke(Score);

			if (Score.x >= settings.ScoreToWin || Score.y >= settings.ScoreToWin)
			{
				OnGameOver?.Invoke();
				windowManager.OpenNewPanel<GameOverPanel>(WindowCloseModes.CloseEverything);
			}
		}

		private void ResetBall()
		{
			Ball.position = Vector3.zero;
			Ball.velocity = (Random.value > 0.5f ? Vector3.back : Vector3.forward) * 15f;
		}

		private void MoveRocket(Rocket rocket)
		{
			var value = rocket.Logic.GetMovement(rocket.Rigidbody, Ball);

			var targetRigidBody = rocket.Rigidbody;
			var currentVelocity = targetRigidBody.velocity;
			if (value == 0)
			{
				targetRigidBody.velocity = currentVelocity.normalized * (currentVelocity.magnitude * 0.95f);
			}
			else
			{
				targetRigidBody.velocity += value * Time.deltaTime * 50f * Vector3.right;
			}
			
			currentVelocity = targetRigidBody.velocity;

			if (currentVelocity.magnitude > 15f)
			{
				targetRigidBody.velocity = currentVelocity.normalized * 15f;
			}
		}
	}
}