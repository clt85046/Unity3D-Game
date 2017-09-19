using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour {
    public Text name1Text;
    public float highscore1;
    private string name11;
    private float score;
    public Text highscore1Text;
    public Text name11Text;
    public GameObject name;
    public GameObject botton;
    public Text entername1;
	// Use this for initialization
    //public void entername()
  //  {
        //if (entername1.text != string.Empty)
       // {
       //     Debug.Log("aaaaa");
      //      name11Text.text = entername1.text; PlayerPrefs.SetString("naaaame", name11Text.text);
      //  }
  //  }
	void Start () {
       // if (score < PlayerPrefs.GetFloat("HighScore"))
      //  {
         //   name.SetActive(true);
         //   botton.SetActive(true);
       // }
       
        name11Text.text = PlayerPrefs.GetString("naaaame");
        highscore1 = PlayerPrefs.GetFloat("HighScore");
        highscore1Text.text += highscore1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void entername()
    {
        
            Application.LoadLevel("menu");

        
    }
}
