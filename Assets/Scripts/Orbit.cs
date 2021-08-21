using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float PlayerOrbitExitSpeed = 3f;
    [SerializeField] private float orbitSize;
    [SerializeField] private bool TurnsLeft;
    [SerializeField] private Transform orbitRing;
    [SerializeField] private Transform orbitVisuals;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private float baseArtRotationSpeed;
    [SerializeField] private float artRotationSpeedOffset;

    private bool playerInOrbit;
    private Transform playerTransform;
    private float angle;

    private float artAngle;
    private float artRotationSpeed;

    private void Start()
    {
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
    }

    public void UnlockPlayerFromOrbit()
    {
        angle = 0;
        playerTransform = null;
        playerInOrbit = false;
    }

    public float GetOrbitSpeed()
    {
        return PlayerOrbitExitSpeed;
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
