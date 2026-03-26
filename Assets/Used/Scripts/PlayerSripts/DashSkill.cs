using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour
{
    private float dashSpeed = 14f;
    private bool canDash = true;
    public float damage = 300f;
    private Rigidbody2D playerRigidbody;
    private PlayerController playerController;
    private Animator animator;

    public ParticleSystem DashPart;
    public ParticleSystem BossPart;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        playerAudio = playerController.playerAudio[4];
    }

    // Update is called once per frame
    void Update()
    {
        FireDash();
    }

    public void FireDash()
    {
        if (canDash && Input.GetKeyDown(KeyCode.Alpha1))
        {
            canDash = false;
            StartCoroutine(FireDashSkillEffect());
        }
    }

    IEnumerator FireDashSkillEffect()
    {
        // 파티클 시스템으로 스킬 이펙트 넣고 0.7초 뒤에 FireDash() 이어서 실행
        playerRigidbody.AddForce(Vector2.right * dashSpeed * 2, ForceMode2D.Impulse);
        animator.SetTrigger("PressDash");
        DashPart.Play();
        playerAudio.Play();
        yield return new WaitForSeconds(0.7f);
        canDash = true;
    }

    public void ApplySilence(float duration)
    {
        StartCoroutine(SilenceCoroutine(duration));
    }

    IEnumerator SilenceCoroutine(float duration)
    {
        canDash = false;
        BossPart.Play();
        yield return new WaitForSeconds(duration);
        BossPart.Stop();
        canDash = true;
    }
}
