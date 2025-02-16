using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1.0f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;

    private Rigidbody rigidBody;
    private bool isBallLaunched = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        rigidBody.isKinematic = true;
    }

    private void LaunchBall() 
    {
        if (isBallLaunched)
            return;

        isBallLaunched = true;
        transform.parent = null;

        rigidBody.isKinematic = false;
        rigidBody.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    void Update()
    {
    }
}
