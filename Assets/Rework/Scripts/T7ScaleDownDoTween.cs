using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class T7ScaleDownDoTween : MonoBehaviour
{
    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.2f); // Wait for 1.2 seconds

        foreach (var obj in objects)
        {
            // Fade out smoothly using scale down
            obj.transform.DOScale(Vector3.zero, 1f) // Smooth scale down to zero over 1 second
                .SetEase(Ease.OutQuad); // Smooth easing for natural scale down
        }
    }
}
