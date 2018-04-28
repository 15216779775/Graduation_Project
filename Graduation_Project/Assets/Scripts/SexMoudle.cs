using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SexMoudle : MonoBehaviour {
    public void changeSex(bool isOn)
    {

        if (!isOn) return;
        
        int isMale = AvatarSys._instance.nowCount;
        if (gameObject.name == "boy" && (isMale >0))
        {
            return;
        }
        if (gameObject.name == "girl" && (isMale ==0))
        {
            return;
        }
        if (isMale == 0)
        {
            AvatarSys._instance.clearGirl();
            //AvatarSys._instance.initBoy();
        }
        else
        {
            AvatarSys._instance.clearBoy();
            //AvatarSys._instance.initGirl();
        }
        AvatarSys._instance.nowCount = 1 - isMale;
    }
}
