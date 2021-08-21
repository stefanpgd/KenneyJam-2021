using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private List<GateKey> keys;
    [SerializeField] private Animator gateAnimator;

    private bool isGateOpen = false;

    private void Update()
    {
        if(!isGateOpen)
        {
            bool keysCollected = true;
            foreach(GateKey key in keys)
            {
                if(!key.PickedUp)
                {
                    keysCollected = false;
                }
            }

            if(keysCollected)
            {
                isGateOpen = true;
                gateAnimator.SetTrigger("Open");
            }
        }
    }
}
