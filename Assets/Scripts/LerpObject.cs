using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObject : MonoBehaviour
{
    [SerializeField] private Transform ObjectToLerp;
    [SerializeField] private Transform TargetA;
    [SerializeField] private Transform TargetB;
    [SerializeField] private float timeForSingleLerp;
    [SerializeField] private bool LerpToB;

    private float timer;

    private void Update()
    {
        timer += 1f * Time.deltaTime;

        if(LerpToB)
        {
            ObjectToLerp.position = Vector2.Lerp(TargetA.position, TargetB.position, timer / timeForSingleLerp);

            if(timer / timeForSingleLerp >= 1)
            {
                LerpToB = false;
                timer = 0;
            }
        }
        else
        {
            ObjectToLerp.position = Vector2.Lerp(TargetB.position, TargetA.position, timer / timeForSingleLerp);

            if(timer / timeForSingleLerp >= 1)
            {
                LerpToB = true;
                timer = 0;
            }
        }
    }
}
