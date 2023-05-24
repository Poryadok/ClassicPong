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

		[Inject(Id = "top")]
		public Rocket RocketTop;
		[Inject(Id = "bottom")]
		public Rocket RocketBottom;
		[Inject(Id = "top")]
		public Goal GoalTop;
		[Inject(Id = "bottom")]
		public Goal GoalBottom;
		[Inject]
		public Ball Ball;

		private bool isInitialized;

		private Coroutine ResetCoroutine;

		private GameModeSettings settings;

		private InputFacade inputFacade;
		private GeneralConfigHolder generalConfigHolder;
		private GameplayConfigHolder gameplayConfigHolder;
		private WindowManagerUT windowManager;

		public bool IsVictory => Score.x > Score.y;
		
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

			isInitialized = true;
			OnGameStarted?.Invoke();
		}

		private void OnDestroy()
		{
			GoalTop.OnGoal -= OnTopGoalHandler;
			GoalBottom.OnGoal -= OnBottomGoalHandler;
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
			Ball.Rigidbody.position = Vector3.zero;
			Ball.Rigidbody.velocity = Vector3.zero;

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
			Ball.Rigidbody.velocity = (Random.value > 0.5f ? Vector3.back : Vector3.forward);
			
			yield return new WaitForSeconds(0.5f);
			Ball.Rigidbody.velocity = Mathf.Clamp(Ball.Rigidbody.velocity.z, -1, 1) * 15f * Vector3.forward;
			ResetCoroutine = null;
		}

	}
}