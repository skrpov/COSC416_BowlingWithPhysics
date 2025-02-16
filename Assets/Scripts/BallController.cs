using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _force = 1.0f;
    [SerializeField] private InputManager _inputManager;

    private Rigidbody _rigidBody;
    private bool _isBallLaunched = false;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall() 
    {
        if (_isBallLaunched)
            return;

        _isBallLaunched = true;

        _rigidBody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    void Update()
    {
    }
}
