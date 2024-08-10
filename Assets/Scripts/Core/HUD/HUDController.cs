using UnityEngine;
using UnityEngine.UIElements;
using WeaponrySystem.Equipment;
using WeaponrySystem.Equipment.Weaponry;

namespace WeaponrySystem.Core
{
    public class HUDController : MonoBehaviour
    {
        public UIDocument UIDocument;

        [SerializeField]
        private EquipmentEventManager _equipmentEventManager;

        private Label _weaponName;
        private VisualElement _weaponWindow;

        public void UpdateWeaponWindow(Weapon weapon)
        {
            _weaponName.text = weapon.Name;
            _weaponWindow.style.backgroundImage = weapon.Icon;
        }

        private void OnEnable()
        {
            _equipmentEventManager.WeaponEquipEvent += UpdateWeaponWindow;

            _weaponName = UIDocument.rootVisualElement.Q<Label>("WeaponName");
            _weaponWindow = UIDocument.rootVisualElement.Q<VisualElement>("WeaponWindow");
        }

        private void OnDisable()
        {
            _equipmentEventManager.WeaponEquipEvent -= UpdateWeaponWindow;
        }
    }
}
