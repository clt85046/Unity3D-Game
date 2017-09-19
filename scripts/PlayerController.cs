using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public GameObject playerExplosion;
	public GameObject Shield;

	private float nextFire;
	private Rigidbody rb;

	private int isWuDi;
	private int isSuoXiao;
	private float timerWuDi;
	private float timerSuoXiao;

	void Start()
	{

		rb = GetComponent<Rigidbody> ();
		isWuDi = 0;
		isSuoXiao = 0;


	}

	void Update ()
	{
		if (Input.GetKeyDown( KeyCode.Space ) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);


		//PowerUP
		//无敌计时
		if (isWuDi == 1 && Time.realtimeSinceStartup - timerWuDi >= 5) 
		{

			isWuDi = 0;
			Shield.gameObject.SetActive (false);
		}
		//缩小计时
		if (isSuoXiao == 1 && Time.realtimeSinceStartup - timerSuoXiao >= 5) 
		{

			isSuoXiao = 0;
			rb.transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
		}


	}

	void OnTriggerEnter(Collider other)
	{
		//无敌
		if (other.gameObject.CompareTag ("PUWuDi")) {
			Destroy (other.gameObject);
			isWuDi = 1;
			Shield.gameObject.SetActive (true);
			timerWuDi = Time.realtimeSinceStartup;

		}

		//缩小
		if (other.gameObject.CompareTag ("PUSuoXiao")) {
			Destroy (other.gameObject);
			isSuoXiao = 1;
			rb.transform.localScale -= new Vector3(0.5F, 0.5F, 0.5F);
			timerSuoXiao =  Time.realtimeSinceStartup;

		}


			
	}
}