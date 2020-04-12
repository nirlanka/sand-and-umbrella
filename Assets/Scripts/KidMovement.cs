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
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, y);

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            var jumpVector = new Vector3(0, jump, 0);
            _rigidbody.AddForce(jumpVector, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}
