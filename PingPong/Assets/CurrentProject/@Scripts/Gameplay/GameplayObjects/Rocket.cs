using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PM.PingPong.Gameplay
{
	[RequireComponent(typeof(Rigidbody))]
	public class Rocket : MonoBehaviour
	{
		public AbRocketMovement movement;
		public Rigidbody Rigidbody;
		private Material material;
		private float spawnTime;
		
		private static readonly int HitPosition = Shader.PropertyToID("_HitPosition");
		private static readonly int HitTime = Shader.PropertyToID("_HitTime");

		private void Awake()
		{
			Rigidbody = GetComponent<Rigidbody>();
			material = GetComponentInChildren<MeshRenderer>().material;
			spawnTime = Time.time;
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.CompareTag("Ball"))
			{
				material.SetVector(HitPosition, other.contacts[0].point - transform.position);
				material.SetFloat(HitTime, Time.time - spawnTime);
			}
		}
	}
}