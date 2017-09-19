using UnityEngine;
using System.Collections;

public class bossmove : MonoBehaviour {

   // public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(2.0f, 0.0f, 0.0f);
    }
}
