using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private int starAmount;
    [SerializeField] private int starOffset;
    [SerializeField] private Vector2 minMaxBoundariesX;
    [SerializeField] private Vector2 minMaxBoundariesY;
    [SerializeField] private Vector2 minMaxSize;

    private void Start()
    {
        for(int i = 0; i < starAmount; i++)
        {
            int randomStar = Random.Range(0, stars.Count);
            float randomRotation = Random.Range(-180, 180);
            float randomSize = Random.Range(minMaxSize.x, minMaxSize.y);
            Vector2 randomPos = new Vector2(Random.Range(minMaxBoundariesX.x, minMaxBoundariesX.y), Random.Range(minMaxBoundariesY.x, minMaxBoundariesY.y));

            GameObject star = Instantiate(stars[randomStar]);
            star.transform.position = randomPos;
            star.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
            star.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            star.transform.parent = gameObject.transform;
        }
    }
}
