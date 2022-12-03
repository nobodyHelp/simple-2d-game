using UnityEngine;

public class HeroAttackController : MonoBehaviour
{
    [SerializeField]
    private GameObject shellPrefab;
    [SerializeField]
    private Transform shotPoint;
    private Animator _anim;

    private float timeBetweenShots = 1;
    [SerializeField]
    private float startTimeBetweenShots;

    private enum AttackType { Shell, Melee}
    [SerializeField]
    private AttackType _attackType;

    private bool _gameIsOver = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_gameIsOver == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_attackType == AttackType.Melee)
                {
                    _attackType = AttackType.Shell;
                }
                else
                {
                    _attackType = AttackType.Melee;
                }
            }
            
            switch (_attackType)
            {
                case AttackType.Shell:
                    ShellAttack();
                    break;
                    
                case AttackType.Melee:
                    MeleeAttack();
                    break;
            }
        }        
    }

    void ShellAttack()
    {
        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _anim.SetBool("isShooting", true);
                Instantiate(shellPrefab, shotPoint.position, shotPoint.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }
        }
        else
        {
            _anim.SetBool("isShooting", false);
            timeBetweenShots -= Time.deltaTime;
        }
    }
    
    void MeleeAttack()
    {
        //logic of melee attack
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
