﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storynext : MonoBehaviour
{
    public GameObject[] GA_objects;
    public int I_count;
    public GameObject G_final;
    public Button nextButton;
    public Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        I_count = 0;
        showobject();
        G_final.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
    public void BUT_Clicking()
    {

    }
    public void showobject()
    {
        for (int i = 0; i < GA_objects.Length; i++)
        {
            GA_objects[i].SetActive(false);
        }
        GA_objects[I_count].SetActive(true);
        
    }
    // Update is called once per frame
    public void BUT_Next()
    {
        if (I_count < GA_objects.Length-1)
        {
            I_count++;
            showobject();
            BUT_Enabler();
        }
        else
        {
            G_final.SetActive(true);
        }
    }
    public void BUT_Back()
    {
        if (I_count >0 )
        {
            I_count--;
            showobject();
            BUT_Enabler();
        }
        else
        {
            G_final.SetActive(true);
        }
    }

    public void BUT_Enabler()
    {
        if (I_count == 0)
        {
            backButton.gameObject.SetActive(false);
        }
        else if (I_count == GA_objects.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            backButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }
}
