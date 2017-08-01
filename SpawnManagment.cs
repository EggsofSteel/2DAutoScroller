using UnityEngine;
using System.Collections;

public class SpawnManagment : MonoBehaviour {

	public Transform[] spawnLocation;
	public GameObject[] enemyToSpawnPrefab;
	public GameObject spawnedEnemy;
	public int maxSpawn;
	public int minSpawn;
	public int whatToSpawn;

	private int setToSpawn;

	public void EnemySpawn()
	{
		whatToSpawn = Random.Range (minSpawn, maxSpawn);
		spawnedEnemy = Instantiate (enemyToSpawnPrefab [whatToSpawn], spawnLocation [0].transform.position, Quaternion.Euler (0, 0, 0));
	}
}
