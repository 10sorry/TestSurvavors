using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _direction;
    [SerializeField] private float speed = 2;
    public Animator animator;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D> ();
    }

    private void OnMove(InputValue inputValue)
    {
        _direction = inputValue.Get<Vector2> ();
    }
    public void Update()
    {
        animator.SetFloat(Horizontal, _direction.x);
        animator.SetFloat(Vertical, _direction.y);
        animator.SetFloat(Speed, _direction.sqrMagnitude);
    }
    

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (speed * Time.fixedDeltaTime));

    }
}
