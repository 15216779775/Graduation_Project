using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManage : MonoBehaviour {
    public static UIManage _instance;
    public Button pic1;
    public GameObject prefab1;
    //public GUILayer
    public UIManage getInstance()
    {
        return _instance;
    }
    private void Awake()
    {
        _instance = this;
        prefab1 = Resources.Load("Prefeb/UITrogleModel") as GameObject;
        //Wprefab1.transform.parent = this.transform;
        Vector3 TempPos = new Vector3(0f, -0f, -5f);
        Vector3 TempRot = new Vector3(0f, 1f, 0f);
        Instantiate(prefab1,TempPos,Quaternion.AngleAxis(0,TempRot));
        //Vector3 TempPos = new Vector3(0f, 0f, 0f);
        //Text tempText = Instantiate(Tip_Text, TempPos, Quaternion.identity) as Text;
        //tempText.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
        //tempText.text = "aaa";

    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
