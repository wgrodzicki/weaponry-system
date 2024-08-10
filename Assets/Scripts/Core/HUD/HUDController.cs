using System.Collections;
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

        private Label _equipmentName;
        private VisualElement _equipmentWindow;

        public void UpdateIconWindow(IEquippable equippable)
        {
            StartCoroutine(WaitForIcon(equippable));
        }

        private IEnumerator WaitForIcon(IEquippable equippable)
        {
            yield return new WaitUntil(() => equippable.IconReference.Asset != null);
            _equipmentName.text = equippable.Name;
            _equipmentWindow.style.backgroundImage = equippable.IconReference.Asset as Texture2D;
        }

        private void OnEnable()
        {
            _equipmentEventManager.ItemEquipEvent += UpdateIconWindow;

            _equipmentName = UIDocument.rootVisualElement.Q<Label>("EquipmentName");
            _equipmentWindow = UIDocument.rootVisualElement.Q<VisualElement>("EquipmentIconWindow");
        }

        private void OnDisable()
        {
            _equipmentEventManager.ItemEquipEvent -= UpdateIconWindow;
        }
    }
}
