using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour

{
    // Start is called before the first frame update
    protected Transform m_transform;
    private float zAngle=1f;
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        m_transform.Rotate(0,0,zAngle);// 旋转
        //transform.SetParent(0);//设置父对象

    }
}
