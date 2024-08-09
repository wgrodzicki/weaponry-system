using System.Collections.Generic;
using UnityEngine;
using WeaponrySystem.Equipment;
using WeaponrySystem.Equipment.Weaponry;

namespace WeaponrySystem.Core
{
    public class PlayerController : MonoBehaviour
    {
        public List<Weapon> PlayerWeapons;

        [SerializeField]
        private int _defaultWeaponIndex = 0;
        [SerializeField]
        private InputEventManager _inputEventManager;
        [SerializeField]
        private EquipmentEventManager _equipmentEventManager;

        private int _currentWeapon = -1;

        public void Attack()
        {
            if (PlayerWeapons.Count == 0 || _currentWeapon < 0)
                return;

            PlayerWeapons[_currentWeapon].Attack();
        }

        public void SwapWeapon()
        {
            int nextWeapon = _currentWeapon + 1;

            if (nextWeapon > PlayerWeapons.Count - 1)
                nextWeapon = 0;

            EquipWeapon(_currentWeapon, false);
            _currentWeapon = nextWeapon;
            EquipWeapon(_currentWeapon, true);

            Debug.Log($"Current weapon: {PlayerWeapons[nextWeapon].Name}");
        }

        public void EquipWeapon(int weaponIndex, bool equip)
        {
            if (PlayerWeapons.Count == 0)
                return;

            PlayerWeapons[weaponIndex].Equip(equip);

            if (equip)
            {
                _currentWeapon = weaponIndex;
                _equipmentEventManager.OnWeaponEquip(PlayerWeapons[_currentWeapon].Name, PlayerWeapons[_currentWeapon].Icon);
            }
            else
            {
                _currentWeapon = -1;
            }
        }

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
