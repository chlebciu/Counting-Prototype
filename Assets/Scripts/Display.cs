using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Main script, gets the pocket with most balls, counts total balls, 
public class Display : MonoBehaviour
{
    public int j;
    private int sum;
    private int bigNumber = 0;
    private GameObject[] counters;
    public Button resetbutton;


    private void Start()
    {
       if(counters ==null)
       counters = GameObject.FindGameObjectsWithTag("accountant"); //gets all counters from the scene

    }

    private void Update()
    {
        if (j >= 1)            // this is so all 0%'s at the start doesn't flare up green
           BiggestNumber(); 
        if(j >=100)
        {
            resetbutton.gameObject.SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            j++; // this tally the TOTAL amount of balls 
    }

    private void BiggestNumber()
    {
        List<int> bigNumbersClub = new List<int>(); // This list stores all positions of pockets with the most amount of balls
        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i].GetComponent<Counter>().amount > bigNumber)
            {
                for (int l = 0; l < counters.Length; l++) // Makes all text black
                {
                    counters[l].GetComponent<Counter>().clr = false;
                }
                bigNumber = counters[i].GetComponent<Counter>().amount; // sets new biggest amount in this iteration to compare others to

                bigNumbersClub.Clear(); // clears lis, to store new biggest one
                bigNumbersClub.Add(i); // adds to the list

            
            }else if(bigNumber == counters[i].GetComponent<Counter>().amount)
            {
                bigNumbersClub.Add(i); // in case there are 2 or more pockets with the same amount, adds it to the list not removing others
            }
            else { }

            
     
        }
        for (int j = 0; j < bigNumbersClub.Count; j++)
        {
            counters[bigNumbersClub[j]].GetComponent<Counter>().clr = true; // changes the color to green for pockets with most balls
        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}   
