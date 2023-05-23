using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PM.PingPong.Gameplay
{
	public class InputFacade : MonoBehaviour
	{
		public event Action<float> OnMove;

		private DefaultInput input;

		private void Start()
		{
			input = new DefaultInput();
			input.Player.Enable();
		}

		private void Update()
		{
			OnMove?.Invoke(input.Player.Move.ReadValue<Vector2>().x);
		}
	}
}