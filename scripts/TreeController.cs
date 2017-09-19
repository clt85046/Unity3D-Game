using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour
{
	public GameObject[] trees;
	public GameObject rightTree;
	public GameObject leftTree;
	public GameObject rightTrees;
	public GameObject leftTrees;
	public GameObject leftTreePos;
	public GameObject rightTreePos;

//	public Vector3 spawnValues;
//	public int hazardCount;
//	public float spawnWait;
//	public float startWait;
//	public float waveWait;

//	public float treeWaveWait;
	public float treeStartWait;
	public float treeSpawnWait;

	void Start ()
	{
		StartCoroutine (GenerateTrees ());
	}

	IEnumerator GenerateTrees ()
	{
		yield return new WaitForSeconds (treeStartWait);
		while (true)
		{	
//			GameObject rightTree = trees[Random.Range (0, trees.Length)];
//			Instantiate (rightTree, rightTreePos.transform.position, rightTreePos.transform.rotation);
//			GameObject leftTree = trees[Random.Range (0, trees.Length)];
//			Instantiate (leftTree, leftTreePos.transform.position, leftTreePos.transform.rotation);

			Instantiate (rightTrees, rightTreePos.transform.position, rightTreePos.transform.rotation);

			Instantiate (leftTrees, leftTreePos.transform.position, leftTreePos.transform.rotation);
			yield return new WaitForSeconds (treeSpawnWait);
		}
			

	}
}