using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float orbitSize;
    [SerializeField] private bool TurnsLeft;

    public float degrees;

    private bool playerInOrbit;
    private Transform playerTransform;
    private float angle;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void LockPlayerIntoOrbit(Transform pt)
    {
        playerTransform = pt;
        playerInOrbit = true;

        Vector2 contactVector = pt.position - transform.position;
        float startAngle = Mathf.Atan2(contactVector.y, contactVector.x);
        angle = startAngle;
        Debug.Log(startAngle);
    }

    public void UnlockPlayerFromOrbit()
    {
        angle = 0;
        playerTransform = null;
        playerInOrbit = false;
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

            float x = orbitSize * Mathf.Cos(angle);
            float y = orbitSize * Mathf.Sin(angle);
            Vector2 polarCoords = new Vector2(x, y);
            Vector2 destination = polarCoords + startPosition;
            playerTransform.position = destination;

            if(TurnsLeft)
            {
                float degrees = angle * Mathf.Rad2Deg;
                playerTransform.rotation = Quaternion.Euler(0f, 0f, degrees);
            }
            else
            {
                float degrees = angle * Mathf.Rad2Deg;
                playerTransform.rotation = Quaternion.Euler(0f, 0f, degrees + 180);
            }
        }
    }
}
