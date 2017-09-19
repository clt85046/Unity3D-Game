//这段代码是上Video Gaming 课程时制作的游戏的boss控制代码。也是我第一次接触unity3D，完全由自己制作一款游戏给了我很多的帮助。
using UnityEngine;
using System.Collections;

[System.Serializable]


public class bosscontrol : MonoBehaviour
{
    private float s = 0;
    public float bossspeed;
    public GameObject shot11;
    private GameObject shot1;
    private float angle;
    private float angle2;
    private float angle1;
    private int l = 0;
    private int jiou = 0;
    private Rigidbody rb;
    private GameController gameController;
    public GameObject[] shot;
    public int shotSpawn;
    public Transform[] shotSpawn1;
    public float fireRate;
    private float nextFire;
    private bool b;
    private int special1;
    private int special2;
    private int special3;
    private int q = 0; private float d = 5f; private float timerWuDi; 
    public float jimo() {
        return d;
    }
    public float jimo1() {
        if (q == 1) { return 1; }
        if (q == 2) { return 2; }
        else return 0;
    }
    void Start() {   
    	timerWuDi = 5;
        b = true;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
	rb.transform.position= new Vector3 (0, 0, transform.position.z+60);
    }
    //boss的阶段设定
    void Update() {
        rb = GetComponent<Rigidbody>();
	//boss子弹的射击规律以及子弹类型设定
        if (s > 200) { 
        if (special1 >= 5 && rb.position.x <= 1 && rb.position.x >= -1) {
                   if (Time.time > nextFire) {
            		nextFire = Time.time + fireRate;
           	 	for (int i = 1; i <= shotSpawn; i++) {
               		float k = 360 / shotSpawn;
                	if (l < 24*shotSpawn) {
                    		if (l %shotSpawn == 0) { d = d -0.3f; Debug.Log(l); }
                   		angle2 = Mathf.Atan(shot11.GetComponent<Rigidbody>().position.x / (rb.position.z - shot11.GetComponent<Rigidbody>().position.z));	    
                    		angle = angle2 * 180 / Mathf.PI;
                    		angle1 = -45 + k * (i - 1) + angle;
                    		shot1 = Instantiate(shot[2], rb.position, Quaternion.Euler(0, k * (i - 1), 0)) as GameObject; //Debug.Log("wa");                   
                    		l = l + 1;  timerWuDi = Time.time; 
                        }
                	if (l >= 24*shotSpawn) {
				if (Time.time > timerWuDi && Time.time - timerWuDi >=3) { q = 1; }
                    		if (Time.time - timerWuDi >= 10) { q = 2; Debug.Log("ha"); }
                    		if (Time.time - timerWuDi >= 15) {special1 = 0; s = 200; d = 5f; q = 0; }
                        }  
                       }
                //GetComponent<AudioSource>().Play();
            	  }
         }
        if (special1 < 5 && special3==0) {
            if (Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                for (int i = 1; i <= 4; i++) {
                    float k =30;
                    if (l < 6 * 4) {
                        angle2 = Mathf.Atan(shot11.GetComponent<Rigidbody>().position.x / (rb.position.z - shot11.GetComponent<Rigidbody>().position.z));
                        // Vector3 movement = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0.0f, Mathf.Cos(angle * Mathf.PI / 180));
                        angle = angle2 * 180 / Mathf.PI;
                        angle1 = -45 + k * (i - 1) + angle;
                        if (jiou% 2 == 0) { 
                            shot1 = Instantiate(shot[1], rb.position, Quaternion.Euler(0, -45 + k * (i - 1), 0)) as GameObject; 
			}
                        if (jiou % 2 != 0) {
                          //  Debug.Log("nani2"); 
                        shot1 = Instantiate(shot[1], rb.position, Quaternion.Euler(0, -45 + k * (i - 1) - angle, 0)) as GameObject;
			}
                        // Instantiate(shot[2], rb.position, Quaternion.Euler(0, k * i, 0)); 
                        l = l + 1; timerWuDi = Time.time;
                        shot1.GetComponent<Rigidbody>().velocity = shot1.transform.forward * -10;
                    }



                    if (l >= 6 * 4) {
                        if (Time.time - timerWuDi >=1) { 
				l = 0; jiou = jiou + 1; 
			}    
                    }
                }
                //GetComponent<AudioSource>().Play();
            }
        }
        if (special1 % 3 == 0 && rb.position.x <= 1 && rb.position.x >= -1) {
            jiou = 0;
            if (Time.time > nextFire) {
                nextFire = Time.time + fireRate + 0.5f;
                for (int i = 0; i <= 10; i++) {
                    Vector3 lol=new Vector3((i-5)*2.5f,0.0f,0.0f);
                    Vector3 lol1 = new Vector3((i - 5) * 2.5f+1, 0.0f, 0.0f);
                    if (l < 6 * 4) {
                        if (l % 2 == 0) {  shot1 = Instantiate(shot[1], shotSpawn1[0].position + lol, shotSpawn1[0].rotation) as GameObject; Debug.Log("asd");shot1.GetComponent<Rigidbody>().velocity = shot1.transform.forward * -12; l = l + 1; }
                        if (l % 2 != 0) { shot1 = Instantiate(shot[1], shotSpawn1[0].position + lol1, shotSpawn1[0].rotation) as GameObject; shot1.GetComponent<Rigidbody>().velocity = shot1.transform.forward * -5f; l = l + 1; }
                        timerWuDi = Time.time;
                      //  shot1.GetComponent<Rigidbody>().velocity = shot1.transform.forward * -5;
                    }
                    if (l >= 6 * 4) {
                        if (Time.time - timerWuDi >= 1) { 
			special2 = special2 + 1; 
			Debug.Log(special2);  
			l = 0;
		    }
   		    if (special2== 3) {
       			special1 = special1 + 1; 
     			special2 = 0; 
      			special3 = 0;
   		    }
                 }
             }
            }
        }
    }
    }
    void FixedUpdate() {
    //boss不同战斗阶段的移动模式设定
        s = s + 1;
        if (s <= 200) {
            //rb.transform.position = new Vector3(0, transform.position.y - 0.03f,0);
            rb.position = rb.position - new Vector3(0, 0.03f, 0);
        }
        if (s > 200) { 
        if(special1>=5) {
            if (rb.position.x >= 1) {
                rb.velocity = transform.right * -bossspeed;
            }
            else {  
	    	if (rb.position.x <= -1) {
                rb.velocity = transform.right * bossspeed;
            }
            else {
                rb.velocity = transform.right * 0;
            }
            }
        }
        if (special1%3==0) {
                if (rb.position.x >= 1) {
                    rb.velocity = transform.right * -bossspeed;
                }
                else {
                    if (rb.position.x <= -1) {
                        rb.velocity = transform.right * bossspeed;
                    }
                    else {
                        rb.velocity = transform.right * 0; special3 = 1;
                    }
                }
            }
        if (special1 < 5 && special1 %3 != 0) {
        if (b) {
            rb.velocity = transform.right * bossspeed;
            if (rb.position.x >= 10) {
                b = false;special1 = special1 + 1;
            }
        }
        else {

            rb.velocity = transform.right * -bossspeed;
            if (rb.position.x <= -10)
            {
                b = true;special1 = special1 + 1;
            }
      
          
        } 
	}
        }
    }
    }

   

