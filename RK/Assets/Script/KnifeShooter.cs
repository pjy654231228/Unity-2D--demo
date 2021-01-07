using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeShooter : MonoBehaviour
{
    // Start is called before the first frame update
    protected Transform m_transform;
    //子弹对象
    public Transform m_knife; 
    //子弹间隔频率
    float m_knifeRate = 0f;
    private int a = 0;

    public Text point_Text;

    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //发射子弹间隔频率
        m_knifeRate -= Time.deltaTime;

        if (m_knifeRate <= 0)
        {
            m_knifeRate = 0.3f;
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                //动态创建子弹，和主角相同坐标，相同角度
                Instantiate(m_knife, m_transform.position, m_transform.rotation);
                a++;
             
                if (point_Text != null)
                {
                    point_Text.text = "Point : " + a;
                }
            }

        }

    }
}
