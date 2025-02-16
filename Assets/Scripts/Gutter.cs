using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody ballRigidBody = other.GetComponent<Rigidbody>();
        float speed = ballRigidBody.linearVelocity.magnitude;
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}
