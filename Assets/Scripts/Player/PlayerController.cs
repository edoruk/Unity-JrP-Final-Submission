using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotationSpeed = 2.0f;
    public float _jumpForce = 4.0f;
    public float distanceToAttack;
    
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
        FindAndKillEnemiesInRange(0.3f);
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

    
    private void FindAndKillEnemiesInRange(float attackValue)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceToAttack);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Enemy" && Input.GetKeyDown(KeyCode.X))
            {
                _enemyInfo = collider.gameObject.GetComponentInChildren<EnemyInfo>();
                _canvas = collider.gameObject.GetComponentInChildren<CanvasGroup>();
                _enemyInfo.UpdateHealthBar(attackValue);
                _canvas.alpha = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StoneCircle"))
        {
            _uiControllerScript.SetUsageText(other);
            Debug.Log(other.gameObject.name + " triggered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StoneCircle"))
        {
            _uiControllerScript.ResetUsageText();
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
