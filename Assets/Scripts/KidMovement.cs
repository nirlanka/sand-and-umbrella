using UnityEngine;

public class KidMovement : MonoBehaviour
{
    Rigidbody _rigidbody;

    public float speed = 10.0f;
    public float jump = 5.0f;
    public bool isOnGround = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    void Move()
    {
        // NOTE:
        // GetAxis --> smoothened
        // GetAxisRaw --> -1, 0, 1

        //var xInp = Input.GetAxisRaw("Horizontal");
        var xInp = Input.GetAxis("Horizontal");
        //var yInp = Input.GetAxisRaw("Vertical");
        var yInp = Input.GetAxis("Vertical");

        if (xInp != 0 || yInp != 0)
        {
            //var xMove = xInp * Time.deltaTime * speed;
            //var yMove = yInp * Time.deltaTime * speed;

            //var movement = new Vector3(xInp, 0, yInp);
            var movement = new Vector3(xInp, 0, yInp) * speed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            //transform.rotation = Quaternion.LookRotation(movement);

            //transform.Translate(xMove, 0, yMove);
            //transform.Translate(movement * speed * Time.deltaTime, Space.World);
            transform.Translate(movement, Space.World);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            var jumpVector = new Vector3(0, jump, 0);
            _rigidbody.AddForce(jumpVector, ForceMode.Impulse);
            isOnGround = false;
        }
    }
}
