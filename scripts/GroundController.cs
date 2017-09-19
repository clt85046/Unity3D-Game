using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour
{

	public GameObject ground;
	public GameObject groundPos;

	//	public Vector3 spawnValues;
	//	public int hazardCount;
	//	public float spawnWait;
	//	public float startWait;
	//	public float waveWait;

	//	public float treeWaveWait;
	public float groundStartWait;
	public float groundSpawnWait;

	void Start ()
	{
		StartCoroutine (GenerateGround ());
	}

	IEnumerator GenerateGround ()
	{
		yield return new WaitForSeconds (groundStartWait);
		while (true)
		{	
			//			GameObject rightTree = trees[Random.Range (0, trees.Length)];
			//			Instantiate (rightTree, rightTreePos.transform.position, rightTreePos.transform.rotation);
			//			GameObject leftTree = trees[Random.Range (0, trees.Length)];
			//			Instantiate (leftTree, leftTreePos.transform.position, leftTreePos.transform.rotation);


			Instantiate (ground, groundPos.transform.position, groundPos.transform.rotation);
			yield return new WaitForSeconds (groundSpawnWait);
		}


	}
}