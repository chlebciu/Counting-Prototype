using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Counts amount of balls in one pocket, and calculates percetage of total amount of balls
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

        bb = GameObject.Find("BIGBOY"); // finds object that count TOTAL amount of balls to calculate percatage from

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        amount += 1;
        other.gameObject.tag = "counted";   // ensures no ball gets counted twice
    }

    private void Update()
    {
        Display ds = bb.GetComponent<Display>();
        total = ds.j;
        if (total > 0)
        {
            percent = (int)(0.5f + ((100f * amount) / total)); // calculates percantage with roundup 

            CounterText.text = percent + "%";  
            // calculates percatage, and shows it 
        }

        if (clr == true)
        {
            CounterText.color = Color.green;
        }
        else
        {
            CounterText.color = Color.black;
            // changes color of text to show which one has the most balls, brains in Display.cs
        }
    }




}
    