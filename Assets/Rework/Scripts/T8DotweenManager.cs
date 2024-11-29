using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class T8DotweenManager : MonoBehaviour
{
     public GameObject[] objects;
    public float scaleDuration = 0.5f; // Duration for scaling
    public float fadeDuration = 0.5f; // Fade-in duration
    public float bounceStrength = 1.5f; // How much the object bounces
    public float delayBetweenObjects = 0.2f;

    private void Start()
    {
        BounceAndFade();
    }

    private void BounceAndFade()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                Transform objTransform = objects[i].transform;
                Renderer objRenderer = objects[i].GetComponent<Renderer>();

                // Ensure object starts at zero scale and is transparent
                objTransform.localScale = Vector3.zero;
                if (objRenderer != null)
                {
                    Color originalColor = objRenderer.material.color;
                    objRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // Start transparent
                }

                // Create sequence for subtle bounce and fade
                Sequence bounceFadeSequence = DOTween.Sequence();

                // Scale with bounce effect
                bounceFadeSequence.Append(objTransform.DOScale(Vector3.one * bounceStrength, scaleDuration).SetEase(Ease.OutBack)
                    .SetDelay(i * delayBetweenObjects));

                // Fade in while scaling
                if (objRenderer != null)
                {
                    bounceFadeSequence.Join(objRenderer.material.DOColor(new Color(1, 1, 1, 1), fadeDuration));
                }

                // Final settle to normal scale
                bounceFadeSequence.Append(objTransform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutQuad));
            }
        }
    }
}
