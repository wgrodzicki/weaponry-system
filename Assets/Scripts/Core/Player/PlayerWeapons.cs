using System.Collections.Generic;
using UnityEngine;
using WeaponrySystem.Equipment.Weaponry;

namespace WeaponrySystem.Core
{
    public partial class PlayerController
    {
        public List<Weapon> PlayerWeapons;

        [SerializeField]
        private int _defaultWeaponIndex = 0;

        private int _currentWeapon = -1;

        public void SwapWeapon()
        {
            int nextWeapon = _currentWeapon + 1;

            if (nextWeapon > PlayerWeapons.Count - 1)
                nextWeapon = 0;

            EquipWeapon(_currentWeapon, false);
            _currentWeapon = nextWeapon;
            EquipWeapon(_currentWeapon, true);
        }

        public void EquipWeapon(int weaponIndex, bool equip)
        {
            if (PlayerWeapons.Count == 0)
                return;

            PlayerWeapons[weaponIndex].Equip(equip);

            if (equip)
            {
                _currentWeapon = weaponIndex;
                _equipmentEventManager.OnWeaponEquip(PlayerWeapons[_currentWeapon]);
            }
            else
            {
                _currentWeapon = -1;
            }
        }

        public void Attack()
        {
            if (PlayerWeapons.Count == 0 || _currentWeapon < 0)
                return;

            PlayerWeapons[_currentWeapon].Attack();
        }
    }
}
