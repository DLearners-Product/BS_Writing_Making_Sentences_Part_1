using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 mousePos;
    public Vector2 initalPos;

    bool isdrag;
    GameObject otherGameObject;

    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        //initalPos = this.GetComponent<RectTransform>().position;
        initalPos = this.transform.position;
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;

        Debug.Log("Drag");
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        if(otherGameObject!=null)
        {
            if (this.gameObject.tag == "answer")
            {
                Debug.Log("Othergameobjectans = " + otherGameObject);
               // otherGameObject.GetComponent<Image>().enabled = true;
                otherGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                this.gameObject.SetActive(false);
                dragmain.OBJ_dragmain.THI_correct();
                this.GetComponent<drag>().enabled = false;
            }
            else
            {
                dragmain.OBJ_dragmain.THI_wrg();
                this.transform.position = initalPos;
            }
        }else
        {
            this.transform.position = initalPos;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Drop")
            otherGameObject = other.gameObject;
        Debug.Log("Othergameobject = " + otherGameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Drop")
            otherGameObject = null;

    }

}
