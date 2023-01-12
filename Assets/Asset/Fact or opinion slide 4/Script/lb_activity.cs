using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class lb_activity : MonoBehaviour
{
    public GameObject G_Final,G_Next,G_Back;
    public GameObject[] GA_Questions;
    public int I_Qcount;
    GameObject G_Selected;
    public AudioSource AS_Correct, AS_Wrong;
    bool B_Canclick;
    public Text TXT_Max, TXT_current;

    // Start is called before the first frame update
    void Start()
    {
        G_Final.SetActive(false);
        TXT_Max.text = GA_Questions.Length.ToString();
        I_Qcount = 0;
        THI_ShowQuestion();
    }
    void THI_ShowQuestion()
    {
        int Que = I_Qcount + 1;
        TXT_current.text = Que.ToString();
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);
        //GA_Questions[I_Qcount].transform.GetChild(2).gameObject.SetActive(false);
        B_Canclick = true;
        //G_Next.GetComponent<Button>().interactable = false;
        //G_Back.GetComponent<Button>().interactable = false;
    }
    public void BUT_Next()
    {
        if (I_Qcount < GA_Questions.Length - 1)
        {
            I_Qcount++;
            THI_ShowQuestion();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }
    public void BUT_Back()
    {
        if (I_Qcount >0)
        {
            I_Qcount++;
            THI_ShowQuestion();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }
    public void BUT_Clicking()
    {
        if(B_Canclick)
        {
            B_Canclick = false;
            G_Selected = EventSystem.current.currentSelectedGameObject;
            if (G_Selected.tag == "ans")
            {
                G_Selected.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
               // GA_Questions[I_Qcount].transform.GetChild(1).gameObject.SetActive(false);
               // GA_Questions[I_Qcount].transform.GetChild(2).gameObject.SetActive(true);
                AS_Correct.Play();
               // G_Next.GetComponent<Button>().interactable = true;
               // G_Back.GetComponent<Button>().interactable = true;
            }
            else
            {
                G_Selected.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.red;
                AS_Wrong.Play();
                Invoke("THI_Offeffect", 1f);
            }
        }
       
    }
    void THI_Offeffect()
    {
        B_Canclick = true;
        G_Selected.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
    }
}
