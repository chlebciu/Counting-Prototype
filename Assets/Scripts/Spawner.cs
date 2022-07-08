using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ball;
    private int a = 8;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Boop());
    }
    

     IEnumerator Boop()
    {
        for (int i = 0; i < 20; i++)
        {
            float r = Random.Range(-a, a);
            float w = Random.Range(-a, a);
           var instance = Instantiate(ball, gameObject.transform.position, ball.transform.rotation);
            instance.GetComponent<Rigidbody>().AddForce(r, 0, w, ForceMode.Impulse);
            yield return new WaitForSeconds(1);
        }
    }
}
