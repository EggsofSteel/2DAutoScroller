using UnityEngine;
using System.Collections;

public class MowingBackground : MonoBehaviour {

	public float backgroudSize;
	public float parallaxSpeed;
	public bool Moving;
	public float movingSpeed;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	public void Start()
	{
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		for(int i = 0; i < transform.childCount; i++)
			layers[i] = transform.GetChild(i);

		leftIndex = 0;
		rightIndex = layers.Length-1;
		if (Moving == true)
			parallaxSpeed = 0;
	}

	void Update()
	{
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * parallaxSpeed);
		lastCameraX = cameraTransform.position.x;

		if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone)) 
		{
			ScrollRight ();
		}
		if (Moving == true) 
			transform.Translate(Vector3.right * (Time.deltaTime * movingSpeed * -1));
	}

	void ScrollLeft()
	{
		layers [rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroudSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length-1;
	}

	void ScrollRight()
	{
		layers [leftIndex].position = Vector3.right * (layers [rightIndex].position.x + backgroudSize);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}
