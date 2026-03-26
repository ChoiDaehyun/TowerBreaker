using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private HitBox attackHitBox;
    [SerializeField] private float baseAttackDamage = 5f;

    [Header("Weapon Data")]
    [SerializeField] private WeaponData commonWeapon;
    [SerializeField] private WeaponData legendWeapon;

    private void Start()
    {
        ApplyEquippedWeaponDamage();
    }

    public void ApplyEquippedWeaponDamage()
    {
        if (attackHitBox == null)
            return;

        string equippedWeapon = WeaponSaveData.GetEquippedWeapon();

        float bonusDamage = 0f;

        if (equippedWeapon == "Common" && commonWeapon != null)
        {
            bonusDamage = commonWeapon.attackBonus;
        }
        else if (equippedWeapon == "Legend" && legendWeapon != null)
        {
            bonusDamage = legendWeapon.attackBonus;
        }

        attackHitBox.damage = baseAttackDamage + bonusDamage;
    }
}