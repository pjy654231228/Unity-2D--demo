using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private float speed = 3f;
    private SpriteRenderer sr;

    private Animator anim;

    public Text timer_Text;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        Time.timeScale = 1f;
        timer = 0;

        StartCoroutine(CountTimer());
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 temp = transform.position;
        if (h > 0) {
            temp.x += speed * Time.deltaTime;
            if (temp.x > 2.41) {
                temp.x = 2.41f;
            }
            sr.flipX = false;
            anim.SetBool("Walk", true);
        
        }else if (h<0) {
            temp.x -= speed * Time.deltaTime;
            if (temp.x < -2.41)
            {
                temp.x = -2.41f;
            }
            sr.flipX = true;
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
            //
        }
        transform.position = temp;
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    { if (target.tag == "Knife") {
            Time.timeScale = 0f;

            StartCoroutine(RestartGame());
        }
        
    }
    IEnumerator RestartGame() {
        yield return new WaitForSecondsRealtime(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    IEnumerator CountTimer() {
        yield return new WaitForSecondsRealtime(1f);
        timer++;

        if (timer_Text!=null) {
            timer_Text.text = "timer is : " + timer;
        }
        StartCoroutine(CountTimer());
    }
}
