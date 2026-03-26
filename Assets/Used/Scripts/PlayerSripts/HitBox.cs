using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private CameraShake cameraShake;
    public float damage = 5f;

    private BoxCollider2D hitCollider;
    public ParticleSystem attackPart;

    private void Awake()
    {
        hitCollider = GetComponent<BoxCollider2D>();
        hitCollider.enabled = false;
    }

    public void EnableHitBox()
    {
        hitCollider.enabled = true;
        attackPart.Play();
    }

    public void DisableHitBox()
    {
        hitCollider.enabled = false;
        attackPart.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LivingEntity target = other.GetComponent<LivingEntity>();

        if (target != null)
        {
            target.OnDamage(damage);
            if (cameraShake != null)
            {
                cameraShake.Shake(0.08f, 0.1f);
            }
        }
    }
}
