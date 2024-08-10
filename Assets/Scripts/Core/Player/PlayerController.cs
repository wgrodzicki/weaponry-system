using UnityEngine;
using WeaponrySystem.Equipment;

namespace WeaponrySystem.Core
{
    public partial class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private InputEventManager _inputEventManager;
        [SerializeField]
        private EquipmentEventManager _equipmentEventManager;

        private void OnEnable()
        {
            _inputEventManager.AttackEvent += Attack;
            _inputEventManager.SwapWeaponEvent += SwapWeapon;
        }

        private void Start()
        {
            EquipWeapon(_defaultWeaponIndex, true);
        }

        private void OnDisable()
        {
            _inputEventManager.AttackEvent -= Attack;
            _inputEventManager.SwapWeaponEvent -= SwapWeapon;
        }
    }
}
