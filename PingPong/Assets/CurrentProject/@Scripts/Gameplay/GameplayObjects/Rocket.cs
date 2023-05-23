using System;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	[RequireComponent(typeof(Rigidbody))]
	public class Rocket : MonoBehaviour
	{
		public AbRocketLogic Logic;
		public Rigidbody Rigidbody;

		private void Awake()
		{
			Rigidbody = GetComponent<Rigidbody>();
		}
	}
}