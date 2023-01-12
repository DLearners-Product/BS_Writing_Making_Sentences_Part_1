using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class dragmain : MonoBehaviour
{
    public static dragmain OBJ_dragmain;
    public GameObject[] GA_Questions;
    public int I_Qcount;
    public GameObject G_final;
    public AudioSource AS_crt, AS_wrg;
    GameObject drop;
    public Text TXT_Max, TXT_current;
    public GameObject G_Next;
    public void Start()
    {
        OBJ_dragmain = this;
        I_Qcount = -1;
        G_final.SetActive(false);
        TXT_Max.text = GA_Questions.Length.ToString();
        showquestion();
    }
    public void showquestion()
    {
        I_Qcount++;
        
        int Que = I_Qcount + 1;
        TXT_current.text = Que.ToString();
        if (I_Qcount<GA_Questions.Length)
        {
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[I_Qcount].SetActive(true);
            GA_Questions[I_Qcount].transform.GetChild(1).gameObject.SetActive(false);
            drop = GA_Questions[I_Qcount].transform.GetChild(0).transform.GetChild(0).gameObject;
            drop.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = null;
        }
        else
        {
            I_Qcount--;
            TXT_current.text = Que.ToString();
            G_final.SetActive(true);
        }
        
    }

    public void BUT_next()
    {
        showquestion();
    }
    public void THI_correct()
    {
        drop.GetComponent<Animator>().enabled = true;
        GA_Questions[I_Qcount].transform.GetChild(0).gameObject.SetActive(true);
        AS_crt.Play();
        Invoke("THI_Offanim", 2.5f);
        G_Next.GetComponent<Button>().interactable = false;
    }

    public void THI_Offanim()
    {
        drop.GetComponent<Animator>().enabled = false;

        GA_Questions[I_Qcount].transform.GetChild(0).gameObject.SetActive(false);
        GA_Questions[I_Qcount].transform.GetChild(1).gameObject.SetActive(true);
        G_Next.GetComponent<Button>().interactable = true;
    }
    public void THI_wrg()
    {
        AS_wrg.Play();
    }
    
}
