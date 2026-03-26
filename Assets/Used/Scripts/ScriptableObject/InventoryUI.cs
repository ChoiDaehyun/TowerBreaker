using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{

    public GameObject ECommonUI;
    public GameObject ELegendUI;

    [Header("UI Text")]
    [SerializeField] private Text commonWeaponText;
    [SerializeField] private Text legendWeaponText;
    [SerializeField] private Text equippedWeaponText;

    private void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        bool hasCommonWeapon = WeaponSaveData.GetHasCommonWeapon();
        bool hasLegendWeapon = WeaponSaveData.GetHasLegendWeapon();
        string equippedWeapon = WeaponSaveData.GetEquippedWeapon();

        if (commonWeaponText != null)
        {
            commonWeaponText.text = hasCommonWeapon
                ? "Common : Owned"
                : "Common : Locked";
        }

        if (legendWeaponText != null)
        {
            legendWeaponText.text = hasLegendWeapon
                ? "Legend : Owned"
                : "Legend : Locked";
        }

        if (equippedWeaponText != null)
        {
            equippedWeaponText.text = "Equipped : " + equippedWeapon;
        }
    }

    public void EquipCommonWeapon()
    {
        if (!WeaponSaveData.GetHasCommonWeapon())
            return;

        WeaponSaveData.SetEquippedWeapon("Common");
        ELegendUI.SetActive(false);
        ECommonUI.SetActive(true);
        RefreshUI();
    }

    public void EquipLegendWeapon()
    {
        if (!WeaponSaveData.GetHasLegendWeapon())
            return;

        WeaponSaveData.SetEquippedWeapon("Legend");
        ECommonUI.SetActive(false);
        ELegendUI.SetActive(true);
        RefreshUI();
    }
    public void UnequipWeapon()
    {
        WeaponSaveData.SetEquippedWeapon("None");
        ECommonUI.SetActive(false);
        ELegendUI.SetActive(false);
        RefreshUI();
    }

    public void OnHomeBtnClicked()
    {
        SceneManager.LoadScene("Loby");
    }
}