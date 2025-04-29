using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    [SerializeField] GameObject eyesLeft;
    [SerializeField] GameObject eyesRight;

    Vector2 initialLeftScale;
    Vector2 initialRightScale;

    void Awake()
    {
        initialLeftScale = eyesLeft.transform.localScale;
        initialRightScale = eyesRight.transform.localScale;
    }

    public void Stretch(float scaleX)
    {
        eyesLeft.transform.localScale = new Vector2(initialLeftScale.x * scaleX, initialLeftScale.y);
        eyesRight.transform.localScale = new Vector2(initialRightScale.x * scaleX, initialRightScale.y);
    }

    public void Reset()
    {
        eyesLeft.transform.localScale = initialLeftScale;
        eyesRight.transform.localScale = initialRightScale;
    }
}
