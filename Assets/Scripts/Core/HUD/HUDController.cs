using UnityEngine;
using UnityEngine.UIElements;
using WeaponrySystem.Equipment;

namespace WeaponrySystem.Core
{
    public class HUDController : MonoBehaviour
    {
        public UIDocument UIDocument;

        [SerializeField]
        private EquipmentEventManager _equipmentEventManager;

        private Label _weaponName;
        private VisualElement _weaponWindow;

        public void UpdateWeaponWindow(string name, Texture2D icon)
        {
            _weaponName.text = name;
            _weaponWindow.style.backgroundImage = icon;
        }

        private void OnEnable()
        {
            _equipmentEventManager.WeaponSwapEvent += UpdateWeaponWindow;

            _weaponName = UIDocument.rootVisualElement.Q<Label>("WeaponName");
            _weaponWindow = UIDocument.rootVisualElement.Q<VisualElement>("WeaponWindow");
        }

        private void OnDisable()
        {
            _equipmentEventManager.WeaponSwapEvent -= UpdateWeaponWindow;
        }
    }
}
