using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float boosts;
    [SerializeField] private float startMoveSpeed;
    [SerializeField] private Transform directionVector;
    [SerializeField] private ParticleSystem lockEffect;
    
    private Orbit activeOrbit;
    private Vector3 velocity;
    private bool inOrbit = false;
    private float moveSpeed;

    private void Start()
    {
        moveSpeed = startMoveSpeed;
        velocity = directionVector.position - transform.position;
        velocity.Normalize();
        velocity *= moveSpeed;
    }

    private void Update()
    {
        if(inOrbit)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                activeOrbit.UnlockPlayerFromOrbit();
                moveSpeed = activeOrbit.GetOrbitSpeed();
                activeOrbit = null;

                velocity = directionVector.position - transform.position;
                velocity.Normalize();
                velocity *= moveSpeed;

                inOrbit = false;
            }
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(GAMETAGS.ORBIT))
        {
            inOrbit = true;
            activeOrbit = collision.gameObject.GetComponent<Orbit>();
            activeOrbit.LockPlayerIntoOrbit(transform);
            lockEffect.Play();
        }
    }
}
