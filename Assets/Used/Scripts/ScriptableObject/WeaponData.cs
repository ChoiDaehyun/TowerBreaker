using UnityEngine;

public enum WeaponGrade
{
    Common,
    Legend
}


[CreateAssetMenu(fileName = "WeaponData", menuName = "Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponGrade weaponGrade;
    public float attackBonus;
}