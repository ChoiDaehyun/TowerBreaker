using UnityEngine;

public class AnimationEventRelay : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    public void EnableAttackHitBox()
    {
        if (playerController != null)
        {
            playerController.EnableAttackHitBox();
        }
    }

    public void DisableAttackHitBox()
    {
        if (playerController != null)
        {
            playerController.DisableAttackHitBox();
        }
    }

    public void EnableDashHitBox()
    {
        if (playerController != null)
        {
            playerController.EnableDashHitBox();
        }
    }

    public void DisableDashHitBox()
    {
        if (playerController != null)
        {
            playerController.DisableDashHitBox();
        }
    }

    public void EnableThunderkHitBox()
    {
        if (playerController != null)
        {
            playerController.EnableThunderHitBox();
        }
    }

    public void DisableThunderHitBox()
    {
        if (playerController != null)
        {
            playerController.DisableThunderHitBox();
        }
    }
}