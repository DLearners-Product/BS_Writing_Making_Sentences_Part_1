using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class T7DotweenManager : MonoBehaviour
{

    public GameObject[] objects;
    


    void Start()
    {
        foreach (GameObject obj in objects)
        {
            CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                // Add a CanvasGroup if it doesn't already exist
                canvasGroup = obj.AddComponent<CanvasGroup>();
            }

            // Set initial alpha to 0
            canvasGroup.alpha = 0;

            // Fade in to alpha 1 over 1 second
            canvasGroup.DOFade(1, 1f).SetEase(Ease.InOutSine);
        }
    }

    public void DeactivateObjects()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.2f);
        foreach (var obj in objects)
        {
            // Punch scale for a quick bounce effect before shrinking
            obj.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 5, 1)
                .OnComplete(() =>
                {
                    // After punch, scale down to zero with elastic effect
                    obj.transform.DOScale(Vector3.zero, 0.7f)
                        .SetEase(Ease.InElastic); // Stretchy shrink
                });
        }
    }
}
