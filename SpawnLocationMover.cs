using UnityEngine;
using System.Collections;

public class SpawnLocationMover : MonoBehaviour {

	public GameObject[] SpawnManagmentPrefabs;
	public int maximumSpawnRange;
	public int minimumSpawnRange;

	private Transform gameObjectTransform;
	private SpawnManagment spawnManagmentScriptHolder;
	private float cameraTransformPosition;
	private float randomSpawnRange;
	private int GameObjectNuber;

	void Start () 
	{
		spawnManagmentScriptHolder = GetComponent<SpawnManagment>();
		gameObjectTransform = this.gameObject.transform;
		randomSpawnRange = Random.Range (maximumSpawnRange, minimumSpawnRange);
	}
	

	void Update () 
	{
		GameObjectNuber = spawnManagmentScriptHolder.whatToSpawn;
		cameraTransformPosition = Camera.main.transform.position.x;
		randomSpawnRange = Random.Range (maximumSpawnRange, minimumSpawnRange);
		if ((cameraTransformPosition - 4) >= gameObjectTransform.position.x) 
		{
			gameObjectTransform.position = new Vector3 ((gameObjectTransform.position.x + randomSpawnRange), SpawnManagmentPrefabs [GameObjectNuber].transform.position.y, 0f);
			gameObjectTransform.position = new Vector3 (this.transform.position.x, SpawnManagmentPrefabs [GameObjectNuber].transform.position.y, 0f);
			spawnManagmentScriptHolder.EnemySpawn ();
		}
	}
}