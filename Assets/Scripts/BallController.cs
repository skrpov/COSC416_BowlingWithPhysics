using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1.0f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    private Rigidbody rigidBody;
    private bool isBallLaunched = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        ResetBall();
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        rigidBody.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;

    }

    private void LaunchBall()
    {
        if (isBallLaunched)
            return;

        isBallLaunched = true;
        transform.parent = null;

        rigidBody.isKinematic = false;
        rigidBody.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    void Update()
    {
    }
}
