using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public FixedJoystick fixedJoystick;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(fixedJoystick.Horizontal, 0, fixedJoystick.Vertical);
        _rigidbody.velocity = direction * speed;
    }
}