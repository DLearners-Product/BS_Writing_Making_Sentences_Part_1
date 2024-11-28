using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
public class T7Drop :  MonoBehaviour, IDropHandler
{
    private T7Manager REF_DragnDrop_V1;
    private Vector3 initialPosition, currentPosition;
    private float elapsedTime, desiredDuration = 0.2f;
   
    public AudioSource source;
    public AudioClip correctAnswer;

    public AudioClip wrongAnswer;

    // public GameObject text;

    // public GameObject[] OneObj;


    //  public Text counter;

    // private int oneObjIndex = 0; // Track the current index for OneObj array
    // private int twoObjIndex = 0; // Track the current index for TwoObj array


    void Start()
    {
        REF_DragnDrop_V1 = FindObjectOfType<T7Manager>();
        initialPosition = transform.position;
    }


    public void OnDrop(PointerEventData eventData)
    {
        Drag_V1 drag = eventData.pointerDrag.GetComponent<Drag_V1>();

        //MATCHING USING THE DRAG AND DROP GAMEOBJECT NAME
        //*correct answer
        if (drag.name == gameObject.name)
        {
            drag.isDropped = true;
            StartCoroutine(IENUM_LerpTransform(drag.rectTransform, drag.rectTransform.anchoredPosition, GetComponent<RectTransform>().anchoredPosition));

            REF_DragnDrop_V1.CorrectAnswer(drag.name, transform.position);
            Debug.Log("correctAnswer");
            T7Manager.instance.ReportCorrectAnswer(drag.name);

            source.clip = correctAnswer;
            source.Play();




        }
        //!wrong answer
        else
        {
            REF_DragnDrop_V1.WrongAnswer(drag.name);
            T7Manager.instance.ReportWrongAnswer(drag.name);

            source.clip = wrongAnswer;
            source.Play();
            

           //  StartCoroutine(WrongAnswerColor());
        }

    }


    IEnumerator IENUM_LerpTransform(RectTransform obj, Vector3 currentPosition, Vector3 targetPosition)
    {
        while (elapsedTime < desiredDuration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            //  obj.anchoredPosition = Vector3.Lerp(currentPosition, targetPosition, percentageComplete);
            yield return null;
        }

        //setting parent
        // obj.transform.SetParent(transform);
        // this.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
        obj.gameObject.SetActive(false);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1f);
      
        // obj.transform.localPosition = Vector2.zero;

        //resetting elapsed time back to zero
        elapsedTime = 0f;
    }

    // IEnumerator CorrectAnswerColor()
    // {
    //     Text textComponent = gameObject.transform.GetChild(1).GetComponent<Text>();
    //     Color originalColor = textComponent.color;
    //     int currentCounterValue = int.Parse(counter.text);
    //     if (currentCounterValue < 12)
    //     {
    //         currentCounterValue++;
    //         counter.text = currentCounterValue.ToString();
    //     }


    //     textComponent.color = Color.green;
    //     yield return new WaitForSeconds(1f);
    //     textComponent.color = originalColor;

    // }

    // IEnumerator WrongAnswerColor()
    // {
    //     Text textComponent = text.gameObject.transform.GetChild(0).GetComponent<Text>();
        

    //     Color originalColor = textComponent.color;


    //     textComponent.color = Color.red;
    //     yield return new WaitForSeconds(1f);
    //     textComponent.color = originalColor;

    // }
}
