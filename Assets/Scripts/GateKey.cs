using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKey : MonoBehaviour
{
    public bool PickedUp = false;

    [SerializeField] private SpriteRenderer visual;
    [SerializeField] private SpriteRenderer circleVisual;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!PickedUp)
        {
            if(collision.CompareTag(GAMETAGS.PLAYER))
            {
                PickedUp = true;
                visual.enabled = false;
                circleVisual.enabled = false;
            }
        }
    }
}