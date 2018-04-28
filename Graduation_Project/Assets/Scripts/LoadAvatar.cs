using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAvatar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (AvatarSys._instance.nowCount == 0)
        {
            AvatarSys._instance.initGirl();
        }
        else
        {
            AvatarSys._instance.initBoy();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
