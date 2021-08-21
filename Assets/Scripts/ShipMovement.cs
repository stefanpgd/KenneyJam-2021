using UnityEngine;

// TODO: visualize boosts in UI
// TODO: allow the player to shoot
// TODO: player dies when flying into asteroids
// TODO: player wins when reaching target
// TODO: Be able to lerp objects between two points within X time
public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float boosts;
    [SerializeField] private float startMoveSpeed;
    [SerializeField] private Transform directionVector;
    [SerializeField] private ParticleSystem lockEffect;

    private GameManager gameManager;

    private Orbit activeOrbit;
    private Vector3 velocity;
    private bool inOrbit = false;
    private bool finished = false;
    private float moveSpeed;

    #region Singleton
    public static ShipMovement Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        gameManager = GameManager.Instance;

        moveSpeed = startMoveSpeed;
        velocity = directionVector.position - transform.position;
        velocity.Normalize();
        velocity *= moveSpeed;
    }

    private void Update()
    {
        if(inOrbit)
        {
            if(boosts > 0)
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
                    boosts--;
                }
            }
            else
            {
                gameManager.ShipStranded();
            }
        }
        else
        {
            if(!finished)
            {
                transform.position += velocity * Time.deltaTime;
            }
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

        if(collision.CompareTag(GAMETAGS.SPACE_STATION))
        {
            finished = true;
            collision.gameObject.GetComponent<SpaceStation>().LockPlayerIntoOrbit(transform);
            lockEffect.Play();
        }

        if(collision.CompareTag(GAMETAGS.KILL_BORDER))
        {
            gameManager.ShipCrashed();
        }
    }
}
