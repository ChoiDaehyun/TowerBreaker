using UnityEngine;


public static class StageReward
{
    public static void GiveRandomWeaponReward()
    {
        int randomValue = Random.Range(0, 2);

        if (randomValue == 0)
        {
            WeaponSaveData.SetHasCommonWeapon(true);
        }
        else
        {
            WeaponSaveData.SetHasLegendWeapon(true);
        }
    }
}