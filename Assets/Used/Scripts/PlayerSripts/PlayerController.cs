using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HitBox attackHitBox;
    [SerializeField] private HitBoxDash dashHitBox;
    [SerializeField] private HitBoxThunder thunderHitBox;
    [SerializeField] private CameraShake cameraShake;

    public float runSpeed = 8.0f;
    private bool canRun = true;
    public float jumpSpeed = 5.0f;
    private bool canJump = true;

    private bool isDead = false;
    private int heart = 2;
    private bool isTouchingEnemy = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    public ParticleSystem RunPart;
    public ParticleSystem ShieldPart;

    public AudioSource[] playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        Run();
        Attack();
        Shield();
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        isDead = true;
        GameManager.instance.OnGameOver();
        return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dead") && isTouchingEnemy && !isDead && heart <= 0)
        {
            if (cameraShake != null)
            {
                cameraShake.Shake(0.1f, 0.09f);
            }
            Die();
        }

        if (other.CompareTag("Dead") && isTouchingEnemy && !isDead)
        {
            if (cameraShake != null)
            {
                cameraShake.Shake(0.1f, 0.09f);
            }
            heart--;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isTouchingEnemy = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isTouchingEnemy = false;
        }
    }

    private void Run()
    {
        if (canRun && Input.GetKeyDown(KeyCode.Z))
        {
            canRun = false;
            playerRigidbody.AddForce(Vector2.right * runSpeed, ForceMode2D.Impulse);
            animator.SetBool("PressRun", true);
            RunPart.Play();
            playerAudio[1].Play();
            StartCoroutine(DelayRun());
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("PressAttack");
            playerAudio[0].Play();
        }
    }

    private void Shield()
    {
        if (canJump && Input.GetKeyDown(KeyCode.X))
        {
            canJump = false;
            playerRigidbody.AddForce((Vector2.left + Vector2.up) * jumpSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("PressShield");
            playerAudio[2].Play();
            ShieldPart.Play();
            StartCoroutine(DelayJump());
        }
    }

    IEnumerator DelayRun()
    {
        yield return new WaitForSeconds(1.5f);
        canRun = true;
    }

    IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(1.5f);
        ShieldPart.Stop();
        canJump = true;
    }

    public void EnableAttackHitBox()
    {
        if (attackHitBox != null)
        {
            attackHitBox.EnableHitBox();
        }
    }

    public void DisableAttackHitBox()
    {
        if (attackHitBox != null)
        {
            attackHitBox.DisableHitBox();
        }
    }

    public void EnableDashHitBox()
    {
        if (dashHitBox != null)
        {
            dashHitBox.EnableDashHitBox();
        }
    }

    public void DisableDashHitBox()
    {
        if (dashHitBox != null)
        {
            dashHitBox.DisableDashHitBox();
        }
    }

    public void EnableThunderHitBox()
    {
        if (thunderHitBox != null)
        {
            thunderHitBox.EnableThunderHitBox();
        }
    }

    public void DisableThunderHitBox()
    {
        if (thunderHitBox != null)
        {
            thunderHitBox.DisableThunderHitBox();
        }
    }
}
