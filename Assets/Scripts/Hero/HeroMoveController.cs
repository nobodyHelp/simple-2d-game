using UnityEngine;

public class HeroMoveController : MonoBehaviour
{
    [SerializeField]
    private float speed = 250.0f;
    [SerializeField]
    private float jumpForce = 12.0f;

    private Rigidbody2D _rb;
    private BoxCollider2D _box;
    private Animator _anim;

    private bool isGrounded = false;

    private enum ControlType { PC, JoyStick, GamePad}
    [SerializeField]
    private ControlType _controlType;

    private bool seeRight = true;

    private bool _gameIsOver = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_gameIsOver == false)
        {
            switch (_controlType)
            {
                case ControlType.PC:
                    PCInput();
                    break;
                case ControlType.JoyStick:
                    JoyStickInput();
                    break;
                case ControlType.GamePad:
                    GamepadInput();
                    break;
                default:
                    break;
            }
        }        
    }

    void PCInput()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 move = new Vector2(deltaX, _rb.velocity.y);
        _rb.velocity = move;
        if (seeRight == false && deltaX > 0)
        {
            Flip();
        }
        else if (seeRight == true && deltaX < 0)
        {
            Flip();
        }
        if (deltaX == 0)
        {
            _anim.SetBool("isRunning", false);
        }
        else
        {
            _anim.SetBool("isRunning", true);
        }

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        isGrounded = false;

        if (hit != null && hit.tag == "Ground")
        {
            isGrounded = true;
        }

        _rb.gravityScale = isGrounded && deltaX == 0 ? 0 : 1;
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _anim.SetBool("isJump", true);
        }

        if (isGrounded == true)
        {
            _anim.SetBool("isJump", false);
        }
        else
        {
            _anim.SetBool("isJump", true);
        }
    }

    void JoyStickInput()
    {
        //logic of Joystick input
    }

    void GamepadInput()
    {
        //logic of Gamepad Input
    }
    void Flip()
    {
        seeRight = !seeRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void GameIsOver()
    {
        _gameIsOver = true;
    }

    private void OnEnable()
    {
        EventManager.GameOver += GameIsOver;
    }
    private void OnDisable()
    {
        EventManager.GameOver -= GameIsOver;
    }
}
