using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boss : MonoBehaviour {

   // public GameObject jimo;
   // public Vector3 spawnValues;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValueeee;
    private GameController gameController;
    public GUIText BossHPText;

    public GUIText storyText;
    private int j = 0;
    public float x;
    private float k=0;private int op;
	public Slider healthBar;
    public GameObject canvas;
    public float lhp()
    {
        return (x - j);
    }

    public int fanhui()
    {
        return op;
    }
    public  float wait()
    {
        return k;
    }
    void Start()
    {
        canvas.SetActive(true);
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        storyText.text = null;
    }
    void Update()
    {
        BossHPText.text = "hp"+(x - j);
        //Debug.Log("kk=" + k);
		healthBar.value = (x-j)/x;
      
    }
    void OnTriggerEnter(Collider other)
    {  
       // x = gameController.Health();

        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Enemybullet" || other.tag == "asteroid" || other.tag == "Shield" || other.tag == "terrian")
        {
            return;
        }
        else
        {
            gameController.AddScore(scoreValueeee);
            /*if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

                Destroy(other.gameObject);
                Destroy(gameObject); gameController.GameOver();
            }*/
           //else {
             
            // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            if (other.tag == "Laser")
            { j = j + 1; }
            else { 
            Destroy(other.gameObject);
            j = j + 1; }//Debug.Log(j);
            //}
        }

        if (j >= x)
       { 
            if (explosion != null)
            {
              Instantiate(explosion, transform.position, transform.rotation);
           }



            
           Destroy(other.gameObject);
           Destroy(gameObject);
           k = Time.time;
           Debug.Log("k=" + k);
           storyText.text = "stage clear!";
           op=1;
           // gameController.Destory(gameObject);

        }
    }

}
