using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public GameObject bb;
    public bool clr;

    public int amount = 0;
    private int total;
    private int percent;

    private void Start()    
    {

        bb = GameObject.Find("BIGBOY");

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        amount += 1;
        other.gameObject.tag = "counted";
    }

    private void Update()
    {
        Display ds = bb.GetComponent<Display>();
        total = ds.j;
        if (total > 0)
        {
            percent = (int)(0.5f + ((100f * amount) / total));

            CounterText.text = percent + "%";
        }

        if (clr == true)
        {
            CounterText.color = Color.green;
        }
        else
        {
            CounterText.color = Color.black;
        }
    }




}
    