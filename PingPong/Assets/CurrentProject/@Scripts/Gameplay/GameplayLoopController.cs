using System;
using System.Collections;
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
		public event Action OnGameStarted;
		public event Action OnGameOver;

		public Vector2Int Score;

		public Rocket RocketTop;
		public Rocket RocketBottom;
		public Goal GoalTop;
		public Goal GoalBottom;
		public Rigidbody Ball;
		public Wall[] Walls;

		private bool isInitialized;

		private Coroutine ResetCoroutine;

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

			ResetCoroutine = StartCoroutine(ResetField());

			GoalTop.OnGoal += OnTopGoalHandler;
			GoalBottom.OnGoal += OnBottomGoalHandler;

			if (generalConfigHolder.GameSettings.AreWallsReset)
			{
				foreach (var wall in Walls)
				{
					wall.OnHit += OnWallHitHandler;
				}
			}

			isInitialized = true;
			OnGameStarted?.Invoke();
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
			if (ResetCoroutine == null)
				StartCoroutine(ResetField());
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
			if (ResetCoroutine == null)
				StartCoroutine(ResetField());
			ChangeScore(1);
		}

		private void OnBottomGoalHandler()
		{
			if (ResetCoroutine == null)
				StartCoroutine(ResetField());
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

		private IEnumerator ResetField()
		{
			Ball.position = Vector3.zero;
			Ball.velocity = Vector3.zero;

			var rocketBottomTransform = RocketBottom.transform;
			var position = rocketBottomTransform.position;
			position = new Vector3(0, position.y, position.z);
			rocketBottomTransform.position = position;
			RocketBottom.Rigidbody.velocity = Vector3.zero;

			var rocketTopTransform = RocketTop.transform;
			position = rocketTopTransform.position;
			position = new Vector3(0, position.y, position.z);
			rocketTopTransform.position = position;
			RocketTop.Rigidbody.velocity = Vector3.zero;
			
			yield return new WaitForSeconds(0.2f);
			// showing what side it's gonna move
			Ball.velocity = (Random.value > 0.5f ? Vector3.back : Vector3.forward);
			
			yield return new WaitForSeconds(0.5f);
			Ball.velocity = Mathf.Clamp(Ball.velocity.z, -1, 1) * 15f * Vector3.forward;
			ResetCoroutine = null;
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