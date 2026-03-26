using UnityEngine;


public static class WeaponSaveData
{
    private const string HasCommonWeaponKey = "HasCommonWeapon";
    private const string HasLegendWeaponKey = "HasLegendWeapon";
    private const string EquippedWeaponKey = "EquippedWeapon";

    public static void SetHasCommonWeapon(bool value)
    {
        PlayerPrefs.SetInt(HasCommonWeaponKey, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool GetHasCommonWeapon()
    {
        return PlayerPrefs.GetInt(HasCommonWeaponKey, 0) == 1;
    }

    public static void SetHasLegendWeapon(bool value)
    {
        PlayerPrefs.SetInt(HasLegendWeaponKey, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool GetHasLegendWeapon()
    {
        return PlayerPrefs.GetInt(HasLegendWeaponKey, 0) == 1;
    }

    public static void SetEquippedWeapon(string weaponName)
    {
        PlayerPrefs.SetString(EquippedWeaponKey, weaponName);
        PlayerPrefs.Save();
    }

    public static string GetEquippedWeapon()
    {
        return PlayerPrefs.GetString(EquippedWeaponKey, "None");
    }

    public static void ResetWeaponData()
    {
        PlayerPrefs.SetInt(HasCommonWeaponKey, 0);
        PlayerPrefs.SetInt(HasLegendWeaponKey, 0);
        PlayerPrefs.SetString(EquippedWeaponKey, "None");
        PlayerPrefs.Save();
    }
}