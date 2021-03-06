using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float orbitSize;
    [SerializeField] private bool TurnsLeft;
    [SerializeField] private Transform orbitRing;
    [SerializeField] private Transform orbitVisuals;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private float baseArtRotationSpeed;
    [SerializeField] private float artRotationSpeedOffset;

    private GameManager gameManager;

    private bool playerInOrbit;
    private Transform playerTransform;
    private float angle;

    private float artAngle;
    private float artRotationSpeed;

    private void Start()
    {
        gameManager = GameManager.Instance;

        orbitRing.localScale = new Vector3(orbitSize, orbitSize, orbitSize);
        circleCollider.radius *= orbitSize;

        artAngle = Random.Range(-180f, 180);
        artRotationSpeed = Random.Range(baseArtRotationSpeed - artRotationSpeedOffset, baseArtRotationSpeed + artRotationSpeedOffset);
    }

    public void LockPlayerIntoOrbit(Transform pt)
    {
        playerTransform = pt;
        playerInOrbit = true;

        Vector2 contactVector = pt.position - transform.position;
        float startAngle = Mathf.Atan2(contactVector.y, contactVector.x);
        angle = startAngle;

        gameManager.ShipReachedStation();
    }

    public float GetOrbitSpeed()
    {
        return rotationSpeed;
    }

    private void Update()
    {
        if(playerInOrbit)
        {
            if(TurnsLeft)
            {
                angle += rotationSpeed * Time.deltaTime;
            }
            else
            {
                angle -= rotationSpeed * Time.deltaTime;
            }

            float x = circleCollider.radius * Mathf.Cos(angle);
            float y = circleCollider.radius * Mathf.Sin(angle);
            Vector2 polarCoords = new Vector2(x, y);
            Vector2 pos = transform.position;
            Vector2 destination = polarCoords + pos;
            playerTransform.position = destination;

            float degrees = angle * Mathf.Rad2Deg;

            if(TurnsLeft)
            {
                playerTransform.rotation = Quaternion.Euler(0f, 0f, degrees);
            }
            else
            {
                playerTransform.rotation = Quaternion.Euler(0f, 0f, degrees + 180);
            }
        }

        if(TurnsLeft)
        {
            artAngle += artRotationSpeed * Time.deltaTime;
            orbitVisuals.transform.rotation = Quaternion.Euler(0f, 0f, artAngle);
        }
        else
        {
            artAngle -= artRotationSpeed * Time.deltaTime;
            orbitVisuals.transform.rotation = Quaternion.Euler(0f, 0f, artAngle);
        }
    }
}
