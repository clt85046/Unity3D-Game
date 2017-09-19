using UnityEngine;
using System.Collections;

public class rota : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(0, 0.0f, 5.0f);
        transform.RotateAround(movement, Vector3.up, 180 * Time.deltaTime);
	}
}
