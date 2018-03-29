using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSys : MonoBehaviour {
    private GameObject girlSource;//ziyuan 
    private GameObject girlTarget;//huanzhuangmubiao
    private Transform girlSourceTransform;
    private Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>
        girlData = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();
    //字典存储信息
    Transform[] girlHips;

	// Use this for initialization
	void Start () {
        InstantiateSources();
        InstantiateTarget();
        girlHips = girlTarget.GetComponentsInChildren<Transform>();
	}

    void InstantiateSources()
    {
        girlSource = Instantiate(Resources.Load("femaleModel")) as GameObject;//加载资源
        girlSourceTransform = girlSource.transform;
        girlSource.SetActive(false);
    }
	void InstantiateTarget()
    {
        girlTarget = Instantiate(Resources.Load("femaleTarget"))as GameObject;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
