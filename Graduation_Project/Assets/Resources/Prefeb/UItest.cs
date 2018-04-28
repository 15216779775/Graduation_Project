using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UItest : MonoBehaviour {
    public Button ButtonHead;
    //public PreferBinarySerialization
    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Init()
    {
        GameObject text = GameObject.Find("Text");
        Button btn1 = (Instantiate(ButtonHead) as Button);
        //btn1.transform.SetParent(text.transform,false);
        btn1.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>(),false);
        btn1.transform.position = new Vector3(100, 50, 0);
        //btn1.guiText = "haha";
    }
}
