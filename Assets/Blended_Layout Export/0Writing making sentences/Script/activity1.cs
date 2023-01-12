using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class activity1 : MonoBehaviour
{
    public TextMeshProUGUI Ques_text;
    public string[] STR_Texts;
    public int I_Qcount;
    public GameObject G_tempmove;
    public GameObject G_Human,G_Final;
    public Sprite SPR_Change;
    bool B_CanClick;
    public AudioSource AS_Crt, AS_Wrg;
    public Text TXT_Max, TXT_current;
    
    // Start is called before the first frame update
    void Start()
    {
        I_Qcount = 0;
        G_Final.SetActive(false);
        TXT_Max.text = STR_Texts.Length.ToString();
        ShowQuestion();
    }
    public void ShowQuestion()
    {
        
        int Que = I_Qcount + 1;
        TXT_current.text = Que.ToString();
        Ques_text.text=STR_Texts[I_Qcount];
        B_CanClick = true;
    }
    public void BUT_Next()
    {
        if(I_Qcount< STR_Texts.Length-1)
        {
            
            I_Qcount++;
            ShowQuestion();
            if(I_Qcount==9)
            {
                G_Human.GetComponent<Image>().sprite = SPR_Change;
            }
        }else
        {
            G_Final.SetActive(true);
        }
        
    }
    public void BUT_Sentence()
    {
        if(B_CanClick)
        {
            if (I_Qcount == 0 || I_Qcount == 3 || I_Qcount == 4 || I_Qcount == 6 || I_Qcount == 9)
            {
                B_CanClick = false;
                AS_Crt.Play();
                Vector3 temp = G_tempmove.GetComponent<RectTransform>().transform.position;
                temp.x = temp.x + 1;
                G_tempmove.GetComponent<RectTransform>().transform.position = temp;
            }
            else
            {
                AS_Wrg.Play();
            }
        }
        
    }

    public void BUT_Phrase()
    {
        if (B_CanClick)
        {
            if (I_Qcount == 1 || I_Qcount == 2 || I_Qcount == 5 || I_Qcount == 7 || I_Qcount == 8)
            {
                B_CanClick = false;
                AS_Crt.Play();
                Vector3 temp = G_tempmove.GetComponent<RectTransform>().transform.position;
                temp.x = temp.x + 1;
                G_tempmove.GetComponent<RectTransform>().transform.position = temp;
            }
            else
            {
                AS_Wrg.Play();
            }
        }

    }
}
