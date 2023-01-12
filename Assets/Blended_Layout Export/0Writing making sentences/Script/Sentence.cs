using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Sentence : MonoBehaviour
{
    public GameObject[] GA_Sentences,GA_Buttons;
    public Image IMG_example;
    public bool B_CanClick;
    GameObject Buttonon;
    // Start is called before the first frame update
    void Start()
    {
        Offtext();
    }

    public void Ontext(int index)
    {
        if(B_CanClick)
        {
            Buttonon = EventSystem.current.currentSelectedGameObject;
            Buttonon.transform.GetChild(0).gameObject.SetActive(true);
            B_CanClick = false;
            IMG_example.enabled = false;
            GA_Sentences[index].SetActive(true);
            Invoke("Offtext", 5f);
        }
        
    }
    public void Offtext()
    {
        if(Buttonon!=null)
        {
            Buttonon.transform.GetChild(0).gameObject.SetActive(false);
        }
        IMG_example.enabled = true;
        for (int i=0;i<GA_Sentences.Length;i++)
        {
            GA_Sentences[i].SetActive(false);
            GA_Buttons[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        B_CanClick = true;
    }
}
