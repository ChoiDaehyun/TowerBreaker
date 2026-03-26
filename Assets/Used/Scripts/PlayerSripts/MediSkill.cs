using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediSkill : MonoBehaviour
{
    [SerializeField] private HitBox attackHitBox;
    [SerializeField] private float buff = 10.0f;
    private float originalDamage;
    private bool canMedi = true;
    private Rigidbody2D playerRigidbody;
    private PlayerController playerController;
    private Animator animator;
    public ParticleSystem MediPart;
    public ParticleSystem BossPart;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        playerAudio = playerController.playerAudio[3];
        if (attackHitBox != null)
        {
            originalDamage = attackHitBox.damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Meditation();
    }
    public void Meditation()
    {
        if (canMedi && Input.GetKeyDown(KeyCode.Alpha2))
        {
            canMedi = false;
            StartCoroutine(MediSkillEffect());
        }
    }

    IEnumerator MediSkillEffect()
    {
        animator.SetTrigger("PressMedi");
        MediPart.Play();
        playerAudio.Play();
        if (attackHitBox != null)
        {
            attackHitBox.damage = originalDamage * buff;
        }
        yield return new WaitForSeconds(3.0f);
        if (attackHitBox != null)
        {
            attackHitBox.damage = originalDamage;
        }
        canMedi = true;
    }
    public void ApplySilence(float duration)
    {
        StartCoroutine(SilenceCoroutine(duration));
    }

    IEnumerator SilenceCoroutine(float duration)
    {
        canMedi = false;
        BossPart.Play();
        yield return new WaitForSeconds(duration);
        BossPart.Stop();
        canMedi = true;
    }
}
