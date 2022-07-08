using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 5 spawners each initializing 20 ball each in a random place as much as a platform allows
public class Spawner : MonoBehaviour
{
    public GameObject ball;
    private int a = 8;
    void Start()
    {
        StartCoroutine(Boop());
    }
    

     IEnumerator Boop()
    {
        for (int i = 0; i < 20; i++)
        {
            float r = Random.Range(-a, a);        // randomized force for x axis 
            float w = Random.Range(-a, a);        // randomized force for z axis 
            var instance = Instantiate(ball, gameObject.transform.position, ball.transform.rotation); // spawn ball 
            instance.GetComponent<Rigidbody>().AddForce(r, 0, w, ForceMode.Impulse); // gets instanced ball to add force to it
            yield return new WaitForSeconds(1);   //this helps balls not spawning on each other, very cool
        }
    }
}
