using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _force = 1.0f;
    [SerializeField] private InputManager _inputManager;

    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall() 
    {
        _rigidBody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    void Update()
    {
    }
}
