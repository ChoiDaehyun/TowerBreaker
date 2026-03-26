using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSkill : MonoBehaviour
{
    [SerializeField] private CameraShake cameraShake;
    private bool canThunder = true;
    public float damage = 300f;
    private PlayerController playerController;
    private Animator animator;
    public ParticleSystem ThundPart;
    public ParticleSystem BossPart;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        playerAudio = playerController.playerAudio[5];
    }

    // Update is called once per frame
    void Update()
    {
        Thunder();
    }

    public void Thunder()
    {
        if (canThunder && Input.GetKeyDown(KeyCode.Alpha3))
        {
            canThunder = false;
            StartCoroutine(ThunderSkillEffect());
        }
    }

    IEnumerator ThunderSkillEffect()
    {
        animator.SetTrigger("PressThunder");
        ThundPart.Play();
        playerAudio.Play();
        if (cameraShake != null)
        {
            cameraShake.Shake(1f, 0.2f);
        }
        yield return new WaitForSeconds(0.7f);
        canThunder = true;
    }
    public void ApplySilence(float duration)
    {
        StartCoroutine(SilenceCoroutine(duration));
    }

    IEnumerator SilenceCoroutine(float duration)
    {
        canThunder = false;
        BossPart.Play();
        yield return new WaitForSeconds(duration);
        BossPart.Stop();
        canThunder = true;
    }
}
