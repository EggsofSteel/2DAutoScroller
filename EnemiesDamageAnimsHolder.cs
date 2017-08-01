using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDamageAnimsHolder : MonoBehaviour {

	public float DamageDealt;

	public float DamageDealtHolder;

	private AnimationEventsGoHere Hero;
	private SpawnManagment Enemy;

	void Start()
	{
		DamageDealtHolder = DamageDealt;
	}

	void FixedUpdate () 
	{
		Hero = GameObject.FindWithTag ("Player").GetComponent<AnimationEventsGoHere> ();
		Enemy = GameObject.FindWithTag ("Spawner").GetComponent<SpawnManagment> ();
	}

	void OnEnemyAtk()
	{
		if (Enemy.spawnedEnemy != null) 
		{
			Hero.health = Hero.health - DamageDealt;
		}
	}
}