using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnifeShoot : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_speed = 6f;
    private float m_A = 0.5f;
    protected Transform m_trasform;
    void Start()
    {
        m_trasform = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        m_trasform.Translate(new Vector3(-m_speed * Time.deltaTime, 0, 0));
        m_speed += m_A;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "watermelon")
        {
            transform.SetParent(target.gameObject.transform);//设置父对象
            m_speed = 0;
            m_A = 0;
        }
        if (target.tag == "Knife")
        {
            StartCoroutine(RestartGame());
        }

    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
