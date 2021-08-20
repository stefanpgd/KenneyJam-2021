using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private int starAmount;
    [SerializeField] private int starOffset;
    [SerializeField] private Vector2 minMaxSize;
    [SerializeField] private Vector2 boundaries;

    private void Start()
    {
        for(int i = 0; i < starAmount; i++)
        {

        }
    }
}
