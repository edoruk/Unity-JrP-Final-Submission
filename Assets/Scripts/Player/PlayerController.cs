using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotationSpeed = 2.0f;
    public float _jumpForce = 4.0f;
    public float distanceToAttack = 1.5f;
    
    private Animator _animator;
    private UIController _uiControllerScript;
    private Rigidbody _playerRb;
    private EnemyInfo _enemyInfo;
    private CanvasGroup _canvas;

    public Quest quest;



    private bool isOnGround = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _uiControllerScript = GameObject.Find("UIManager").GetComponent<UIController>();
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        RunMovementAnimations();
        FindAndKillEnemiesInRange();
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? 4.0f : 2.0f;
        
        transform.Translate(Vector3.forward * verticalInput * movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed);
    }

    private void RunMovementAnimations()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetFloat("movementSpeed", Input.GetKey(KeyCode.LeftShift) ? 0.6f : 0.3f);
        }
        else
        {
            _animator.SetFloat("movementSpeed",0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("jumpTrigger");
        }
    }

    
    private void FindAndKillEnemiesInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceToAttack);
        foreach (var collider in colliders)
        {
            if (collider.tag == "EnemyTurtle" || collider.tag == "EnemySlime")
            {
                _enemyInfo = collider.gameObject.GetComponentInChildren<EnemyInfo>();
                _canvas = collider.gameObject.GetComponentInChildren<CanvasGroup>();
                
                float distanceToEnemy = Vector3.Distance(transform.position, collider.transform.position);

                
                if (Input.GetKeyDown(KeyCode.X) && distanceToEnemy <= distanceToAttack)
                {
                    _enemyInfo.Attack();
                }
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "StoneCircle":
                _uiControllerScript.SetUsageText("use", other);
                break;
            case "QuestGiver":
                _uiControllerScript.SetUsageText("interact", other);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "StoneCircle":
                _uiControllerScript.ResetUsageText();
                break;
            case "QuestGiver":
                _uiControllerScript.ResetUsageText();
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                isOnGround = true;
                break;
        }
    }
}
