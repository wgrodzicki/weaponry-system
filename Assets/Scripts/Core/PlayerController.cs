using Equipment.Weaponry;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerController : MonoBehaviour
    {
        public List<Weapon> PlayerWeapons;

        [SerializeField]
        private int _defaultWeaponIndex = 0;
        [SerializeField]
        private InputController _inputController;

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

            PlayerWeapons[_currentWeapon].Equip(false);
            PlayerWeapons[nextWeapon].Equip(true);
            _currentWeapon = nextWeapon;

            Debug.Log($"Current weapon: {PlayerWeapons[nextWeapon].Name}");
        }

        public void EquipWeapon(int weaponIndex, bool equip)
        {
            if (weaponIndex < 0 || PlayerWeapons.Count == 0)
                return;

            PlayerWeapons[weaponIndex].Equip(equip);
            _currentWeapon = equip == true ? weaponIndex : -1;
        }

        private void OnEnable()
        {
            if (_inputController == null)
            {
                Debug.LogError("PlayerController lacks InputController reference. Input will not be read.");
                return;
            }

            _inputController.AttackEvent += Attack;
            _inputController.SwapWeaponEvent += SwapWeapon;
        }

        private void Start()
        {
            if (PlayerWeapons.Count > 0)
            {
                PlayerWeapons[_defaultWeaponIndex].Equip(true);
                _currentWeapon = _defaultWeaponIndex;
            }
        }

        private void OnDisable()
        {
            if (_inputController != null)
            {
                _inputController.AttackEvent -= Attack;
                _inputController.SwapWeaponEvent -= SwapWeapon;
            }
        }
    }
}
