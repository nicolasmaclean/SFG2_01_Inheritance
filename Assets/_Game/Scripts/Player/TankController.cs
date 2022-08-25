using TMPro;
using UnityEngine;

public class TankController : MonoExtended
{
    public float MaxSpeed
    {
        get => _maxSpeed;
        set => _maxSpeed = value;
    }
        
    [SerializeField] float _maxSpeed = .25f;
    [SerializeField] float _turnSpeed = 2f;

    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveTank();
        TurnTank();
    }

    public void MoveTank()
    {
        float moveAmountThisFrame = Input.GetAxis("Vertical") * MaxSpeed;
        Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        
        _rb.MovePosition(_rb.position + moveOffset);
    }

    public void TurnTank()
    {
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }
}