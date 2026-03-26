using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : LivingEntity
{
    public float speed = 0.3f;
    public float maxHealth = 50.0f;
    private EnemySpawner enemSpawn;

    private Rigidbody2D enemyRigidbody;
    private Animator enemyAnimator;

    private AudioSource enemyAudio;

    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        GameObject spawner = GameObject.FindWithTag("Respawn");
        enemyAudio = GetComponent<AudioSource>();

        if (spawner != null)
        {
            enemSpawn = spawner.GetComponent<EnemySpawner>();
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
        enemyRigidbody.velocity = Vector2.left * speed;
    }

    public override void OnDamage(float damge)
    {
        base.OnDamage(damge);
    }

    public override void Die()
    {
        enemyAnimator.SetTrigger("Die");
        gameObject.transform.position = enemSpawn.transform.position;

        base.Die();

        gameObject.SetActive(false);
    }
}
