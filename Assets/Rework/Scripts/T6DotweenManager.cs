using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class T6DotweenManager : MonoBehaviour
{
    public GameObject frame;

    void Start()
    {
        // Ensure the frame starts at scale 1
        frame.transform.localScale = Vector3.one;

        // Scale up to 1.2 over 1 second and back to 1
        frame.transform.DOScale(new Vector3(1.2f, 1.2f, 1), 1f) // Scale up over 1 second
            .SetEase(Ease.InOutSine) // Smooth ease for scaling
            .OnComplete(() =>
            {
                // Scale back to original
                frame.transform.DOScale(Vector3.one, 1f)
                    .SetEase(Ease.InOutSine); // Smooth ease for returning to normal scale
            });
    }
}
