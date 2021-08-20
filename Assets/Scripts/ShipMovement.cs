using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float boosts;
    [SerializeField] private float moveSpeed;

    private Vector3 velocity;

    private void Start()
    {
        velocity = Vector3.zero;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            velocity.x = Mathf.Cos(transform.rotation.z);
            velocity.y = Mathf.Sin(transform.rotation.z);
            velocity *= moveSpeed;
        }

        transform.position += velocity * Time.deltaTime;
    }
}
