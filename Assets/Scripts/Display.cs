using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public int j;
    private int sum;
    private int bigNumber = 0;
    private GameObject[] counters;


    private void Start()
    {
       if(counters ==null)
       counters = GameObject.FindGameObjectsWithTag("accountant");
    }

    private void Update()
    {
        if (j >= 1)
           BiggestNumber();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            j++; 
    }

    private void BiggestNumber()
    {
        List<int> bigNumbersClub = new List<int>();
        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i].GetComponent<Counter>().amount > bigNumber)
            {
                for (int l = 0; l < counters.Length; l++)
                {
                    counters[l].GetComponent<Counter>().clr = false;
                }
                bigNumber = counters[i].GetComponent<Counter>().amount;

                bigNumbersClub.Clear();
                bigNumbersClub.Add(i);

            
            }else if(bigNumber == counters[i].GetComponent<Counter>().amount)
            {
                bigNumbersClub.Add(i);
            }
            else { }

            
     
        }
        for (int j = 0; j < bigNumbersClub.Count; j++)
        {
            counters[bigNumbersClub[j]].GetComponent<Counter>().clr = true;
        }
    }
}   
