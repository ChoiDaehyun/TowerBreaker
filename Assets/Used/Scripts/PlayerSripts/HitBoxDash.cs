using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDash : MonoBehaviour
{
    public float damage = 500f;

    private BoxCollider2D hitCollider;
    public ParticleSystem DashHitPart;

    private void Awake()
    {
        hitCollider = GetComponent<BoxCollider2D>();
        hitCollider.enabled = false;
    }

    public void EnableDashHitBox()
    {
        hitCollider.enabled = true;
        DashHitPart.Play();
    }

    public void DisableDashHitBox()
    {
        hitCollider.enabled = false;
        DashHitPart.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LivingEntity target = other.GetComponent<LivingEntity>();

        if (target != null)
        {
            target.OnDamage(damage);
        }
    }
}
