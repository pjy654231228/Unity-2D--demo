using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject knife;

    private float mix_x = -2.81f;
    private float max_x = 2.81f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartSpawn() {
        yield return new WaitForSeconds(Random.Range(0.5f,1f));
        GameObject k = Instantiate(knife);

        float x = Random.Range(mix_x,max_x);
        k.transform.position = new Vector2(x, transform.position.y);
        StartCoroutine(StartSpawn());
    }
}
