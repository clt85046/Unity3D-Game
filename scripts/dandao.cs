using UnityEngine;
using System.Collections;

public class dandao : MonoBehaviour
{
    private Rigidbody rb;
    private GameController gameController;
    public GameObject shot;
    public GameObject shot11;
    public int shotSpawn;
  private float timerWuDi;
    public float fireRate;
    private float nextFire;
    private bool b;
    private float x=0;
    private float angle;
    private float angle2;
    private float angle1;
    private GameObject shot1;
    private Done_Mover lol;
    private int l = 0;
    private float ts; private int i;
    private float jiou;
    private int q = 0;private float d =7.5f;
  /*  public float jimo()
    {
        return d;
    }
    public float jimo1()
    {
        if (q == 1)
        { return 1; }
        if (q == 2)
        { return 2; }
        else return 0;
    }*/
    public float ceyice()
    {
        return jiou;
    }
    private int shoot = 0;
    void Start()
    {
        i = 0;
        ts = 0;
        timerWuDi = 5;
        b = true;
        
//       
       
    }
    void Update()
    {
        rb = GetComponent<Rigidbody>(); //Debug.Log(lol.xiba());
        ts = ts + 1; float k = 360 / shotSpawn;
        if (ts > 0 && ts<=2*shotSpawn)
        {
            i = i + 1;
            if (i % 2 == 0)
            {
                Vector3 sa = new Vector3(1, 0, 0);
                //Debug.Log("sa=" + sa);
                shot1 = Instantiate(shot, rb.position + sa, Quaternion.Euler(0,k * (i / 2 - 1), 0)) as GameObject; l = l + 1; jiou =1;
            }
            else
            {
                shot1 = Instantiate(shot, rb.position, Quaternion.Euler(0, k* (i - 1) / 2, 0)) as GameObject; l = l + 1; jiou = 0;
            }
        }
        if(ts>100)
        {
            ts = 0; i = 0;
        }
      //  d = d + lol.xiba();
//if (Time.time > timerWuDi && Time.time - timerWuDi <= 5)
//{ 
        

    }
}