using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using WeaponrySystem.Items;
using WeaponrySystem.Items.Weapons;

namespace WeaponrySystem.Core
{
    /// <summary>
    /// A class that controls the behaviour and display of the game's HUD.
    /// </summary>
    public class HUDController : MonoBehaviour
    {
        [Tooltip("UIDocument associated with this HUD.")]
        public UIDocument UIDocument;
        [Tooltip("ItemEventManager to receive info about item-related events.")]
        [SerializeField]
        private ItemEventManager _itemEventManager;

        private Label _weaponName;
        private VisualElement _weaponIcon;

        /// <summary>
        /// Displays icon and name of the given weapon in the HUD.
        /// </summary>
        /// <param name="weapon"></param>
        public void DisplayWeaponIcon(Weapon weapon)
        {
            StartCoroutine(WaitForIcon(weapon, _weaponName, _weaponIcon));
        }

        private IEnumerator WaitForIcon(IEquippable equippable, Label itemName, VisualElement itemIcon)
        {
            yield return new WaitUntil(() => equippable.IconReference.Asset != null);

            itemName.text = equippable.Name;
            itemIcon.style.backgroundImage = equippable.IconReference.Asset as Texture2D;
        }

        private void OnEnable()
        {
            if (_itemEventManager == null)
                Debug.LogError("ItemEventManager on HUDController is missing. HUD will not work correctly!");

            _itemEventManager.WeaponEquipEvent += DisplayWeaponIcon;

            _weaponName = UIDocument.rootVisualElement.Q<Label>("WeaponNameLabel");
            _weaponIcon = UIDocument.rootVisualElement.Q<VisualElement>("WeaponIconElement");
        }

        private void OnDisable()
        {
            _itemEventManager.WeaponEquipEvent -= DisplayWeaponIcon;
        }
    }
}
