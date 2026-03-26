using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : LivingEntity
{
    public float speed = 0.2f;
    public float maxHealth = 300.0f;
    private float attackRate = 10.0f;

    public GameObject Ball;
    private float timeAfterAttack;
    private DashSkill dashSkill;
    private MediSkill mediSkill;
    private ThunderSkill thundSkill;
    private Rigidbody2D bossRigidbody;
    private Animator bossAnimator;

    private AudioSource bossAudio;

    void Awake()
    {
        bossRigidbody = GetComponent<Rigidbody2D>();
        bossAnimator = GetComponent<Animator>();
        GameObject player = GameObject.FindWithTag("Player");
        bossAudio = GetComponent<AudioSource>();

        if (player != null)
        {
            dashSkill = player.GetComponent<DashSkill>();
            mediSkill = player.GetComponent<MediSkill>();
            thundSkill = player.GetComponent<ThunderSkill>();
        }

    }
    public void Setup()
    {
        startingHealth = maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterAttack += Time.deltaTime;
        bossRigidbody.velocity = Vector2.left * speed;
        if (timeAfterAttack >= attackRate)
        {
            timeAfterAttack = 0f;
            bossAnimator.SetTrigger("Attack");
            if (gameObject.CompareTag("Boss1"))
            {
                dashSkill.ApplySilence(5f);
                mediSkill.ApplySilence(5f);
                thundSkill.ApplySilence(5f);
                bossAudio.Play();
            }
            else if (gameObject.CompareTag("Boss2"))
            {
                StartCoroutine(PushBall());
                bossAudio.Play();
            }
        }
    }

    public override void OnDamage(float damge)
    {
        base.OnDamage(damge);
    }

    public override void Die()
    {
        base.Die();

        bossAnimator.SetTrigger("Die");
        Destroy(gameObject);
        GameManager.instance.StageClear();
        StageReward.GiveRandomWeaponReward();
    }
    IEnumerator PushBall()
    {
        Ball.transform.position = gameObject.transform.position + new Vector3(0f, 1f, 0f);
        Instantiate(Ball);
        yield return new WaitForSeconds(3.0f);
        Destroy(Ball);
    }
}
