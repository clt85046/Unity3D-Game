using UnityEngine;
using System.Collections;

public class bossbullet : MonoBehaviour
{
   // public GameObject jimo;
   // public Vector3 spawnValues;
    private Done_PlayerController life;
    public GameObject explosion;
    public GameObject playerExplosion;
    //public int scoreValue;
    private GameController gameController;
    private boss boos; private int xl;
    private int l = 0; private int sadvn;
    //private int i = 0, x;
    void Start()
    {
        GameObject gameControllerObject1 = GameObject.FindGameObjectWithTag("Player");
        if (gameControllerObject1 != null)
        {
            life = gameControllerObject1.GetComponent<Done_PlayerController>();
        }
        if (gameControllerObject1 == null)
        {
            Debug.Log("Cannot find 'GameController' script1111");
        }
        GameObject gameControllerObject21 = GameObject.FindGameObjectWithTag("boss");
        if (gameControllerObject21 != null)
        {
            boos = gameControllerObject1.GetComponent<boss>();
        }
        if (gameControllerObject21 == null)
        {
            //Debug.Log("Cannot find 'GameController' script1111");
        }
        sadvn = 2;
        //gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0.8f, 1f), 0, 0);
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        
    }
    void Update()
    {
       // xl = boos.fanhui();
    }
    void OnTriggerEnter(Collider other)
    {
       // x = gameController.Health();
        //xl = boos.fanhui();
       // Debug.Log("boos.fanhui" + boos.fanhui());
        if (xl == 1)
        {
            Destroy(gameObject);
        }
        else {
            if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "asteroid" || other.tag == "Enemybullet" || other.tag == "aaa" || other.tag == "terrian" || other.tag == "Pick up" || other.tag == "PUSuoXiao")
            {
                //Debug.Log(other.tag);
            return;
        }
        else
        {
            if (other.tag == "Player")
            {
              
                life.hurt();
           
                if (life.hp() >= 0)
                {
                   
                    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                    life.test();
                    //Destroy(other.gameObject);
                    Destroy(gameObject);
                    other.gameObject.transform.position = new Vector3(0, 0, -2);
                    other.gameObject.SetActive(true);
                }
                if (life.hp() < 0)
                {
                    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                    other.gameObject.SetActive(false);
                    Destroy(gameObject); PlayerPrefs.SetFloat("scorethisgame", 0); gameController.GameOver();
                }
            }
			if (other.tag == "wudi" || other.tag == "Shield")
			{
				//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				Destroy(gameObject); 
			}
           
          //  else { i = i + 1; Destroy(other.gameObject); }
        }
       }
    }

}