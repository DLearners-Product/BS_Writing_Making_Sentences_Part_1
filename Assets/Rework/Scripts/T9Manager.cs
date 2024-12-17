using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class T9Manager : MonoBehaviour
{
    public GameObject movingObject; // Assign the object to be moved in the Inspector
    private Vector3 targetPosition;

    // Duration of the movement
    public float moveDuration = 1f;

    // Function to move to position for the first button
    public void MoveToFirstPosition()
    {
        targetPosition = new Vector3(-2500f, movingObject.transform.localPosition.y, movingObject.transform.localPosition.z);
        MoveObject();
    }

    // Function to move to position for the second button
    public void MoveToSecondPosition()
    {
        targetPosition = new Vector3(-4365f, movingObject.transform.localPosition.y, movingObject.transform.localPosition.z);
        MoveObject();
    }

    // Function to move to position for the third button
    public void MoveToThirdPosition()
    {
        targetPosition = new Vector3(-6405f, movingObject.transform.localPosition.y, movingObject.transform.localPosition.z);
        MoveObject();
    }

      public void MoveToInitialPosition()
    {
        targetPosition = new Vector3(-622f, movingObject.transform.localPosition.y, movingObject.transform.localPosition.z);
        MoveObject();
    }


    // Generalized function to handle movement
    private void MoveObject()
    {
       movingObject.transform.DOKill();
    movingObject.transform.DOLocalMoveX(targetPosition.x, moveDuration)
        .SetEase(Ease.OutBack); // Subtle overshoot for a polished look
    }
}
