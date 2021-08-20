using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float boosts;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform directionVector;
    
    private Orbit activeOrbit;
    private Vector3 velocity;
    private bool inOrbit = false;

    private void Start()
    {
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
                activeOrbit = null;

                velocity = directionVector.position - transform.position;
                velocity.Normalize();
                velocity *= moveSpeed;

                inOrbit = false;
            }
        }

        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(GAMETAGS.ORBIT))
        {
            inOrbit = true;
            activeOrbit = collision.gameObject.GetComponent<Orbit>();
            activeOrbit.LockPlayerIntoOrbit(transform);
        }
    }
}
