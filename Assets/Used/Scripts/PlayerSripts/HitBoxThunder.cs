using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxThunder : MonoBehaviour
{
    public float damage = 200f;

    private BoxCollider2D hitCollider;
    public ParticleSystem ThunderPart;
    // Start is called before the first frame update
    void Awake()
    {
        hitCollider = GetComponent<BoxCollider2D>();
        hitCollider.enabled = false;
    }

    public void EnableThunderHitBox()
    {
        hitCollider.enabled = true;
        ThunderPart.Play();
    }

    public void DisableThunderHitBox()
    {
        hitCollider.enabled = false;
        ThunderPart.Stop();
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
