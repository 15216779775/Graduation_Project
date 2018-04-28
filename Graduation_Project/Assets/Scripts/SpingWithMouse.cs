using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpingWithMouse : MonoBehaviour {
    private bool isClicking;
    private Vector3 nowPos;
    private Vector3 oldPos;
    public float length = 5;
    public Vector3 from;//起始方位
    public float eagle = 1;
    public Vector3 to;//终止方位

    public float factor = 0.1f;//可以把这个值理解为旋转速度 取值范围0～1
    void OnMouseUp()
    {
        isClicking = false;
    }
    void OnMouseDown()
    {
        isClicking = true;
    }
    private void Update()
    {
        nowPos = Input.mousePosition;
        if (isClicking)
        {
            Vector3 offset = nowPos - oldPos;
            if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y) && Mathf.Abs(offset.x) > length)
            {
                transform.Rotate(Vector3.up, -offset.x);
            }
        }
        oldPos = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3 newVector3 = Quaternion.AngleAxis(90,Vector3.up);
            transform.rotation = Quaternion.AngleAxis(90, Vector3.up) * transform.rotation;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.AngleAxis(eagle, Vector3.up) * transform.rotation;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.AngleAxis(-eagle, Vector3.up) * transform.rotation;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (eagle < 90)
                eagle++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (eagle >1)
                eagle--;
        }

    }
    
}
