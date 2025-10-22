using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    private Rigidbody2D _rb;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _swordRenderer;
    private float _move;
    private bool _resetJump = false;
    private bool _grounded = false;

    [SerializeField] private int _currentDiamonds = 0;
    public int CurrentGems { get { return _currentDiamonds; } set { _currentDiamonds = value; } }

    [Header("Player Settings")]
    [SerializeField] private float _speed = 5.0f;

    [Header("Jump Settings")]
    [SerializeField] private float _rayDistance = 0.65f;
    [SerializeField] private float _jumpForce;

    public int Health { get; set;}

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if(_rb == null)
        {
            Debug.LogError("RB is NULL on PLAYER");
        }

        _playerAnim = GetComponent<PlayerAnimation>();
        if(_playerAnim == null )
        {
            Debug.LogError("PlayerAnim is NULL on Player");
        }

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if(_spriteRenderer == null )
        {
            Debug.LogError("Sprite is NULL on Player");
        }

        Health = 4;
    }

    void Update()
    {
        Movement();

        if(Input.GetKeyDown(KeyCode.Mouse0) && IsGrounded())
        {
            _playerAnim.Attack();
        }
    }

    private void Movement()
    {
        _move = Input.GetAxis("Horizontal");
        _grounded = IsGrounded();

        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.linearVelocity = new Vector2(_move, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }

        _rb.linearVelocity = new Vector2(_move * _speed, _rb.linearVelocity.y);
        _playerAnim.Move(_move);

    }

    private void FlipSprite()
    {
        if (_move > 0)
        {
            _spriteRenderer.flipX = false;

            //Sword Settings
            _swordRenderer.flipX = false;
            _swordRenderer.flipY = false;

            Vector3 swordNewPos = _swordRenderer.transform.localPosition;
            swordNewPos.x = 1.01f;
            _swordRenderer.transform.localPosition = swordNewPos;
        }
        else if (_move < 0)
        {
            _spriteRenderer.flipX = true;

            //Sword Settings
            _swordRenderer.flipX = true;
            _swordRenderer.flipY = true;

            Vector3 swordNewPos = _swordRenderer.transform.localPosition;
            swordNewPos.x = -1.01f;
            _swordRenderer.transform.localPosition = swordNewPos;
        }
    }

    private bool IsGrounded()
    {
        //Raycast from position to ground and include only Ground Layer

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, (1 << 6));
        if (hit.collider != null)
        {
            if(!_resetJump)
            {
                _playerAnim.Jump(false);
                return true;
            }
        }

        return false;
    }

   private IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        Debug.Log("Damaged player");
        Health--;

        if(Health <= 0 )
        {
            _playerAnim.Death();
        }
    }

    public void AddGems(int amount)
    {
        _currentDiamonds += amount;
        UIManager.Instance.UpdateGemCount(_currentDiamonds);
    }


}
