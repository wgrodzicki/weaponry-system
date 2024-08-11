using System.Collections.Generic;
using UnityEngine;
using WeaponrySystem.Items;
using WeaponrySystem.Items.Weapons;

namespace WeaponrySystem.Core
{
    /// <summary>
    /// A class that controls the player.
    /// </summary>
    public partial class PlayerController : MonoBehaviour
    {
        [Tooltip("List of weapons currently available for the player.")]
        public List<Weapon> PlayerWeapons;

        [Tooltip("Which weapon should be equipped by default.")]
        [SerializeField]
        private int _defaultWeaponIndex = 0;
        [Tooltip("InputEventManager to receive info about input actions.")]
        [SerializeField]
        private InputEventManager _inputEventManager;
        [Tooltip("ItemEventManager to send info about item-related events.")]
        [SerializeField]
        private ItemEventManager _itemEventManager;

        private int _currentWeapon = -1;

        /// <summary>
        /// Swaps the weapon, equipping the next one available.
        /// </summary>
        public void SwapWeapon()
        {
            int nextWeapon = _currentWeapon + 1;

            if (nextWeapon > PlayerWeapons.Count - 1)
                nextWeapon = 0;

            EquipWeapon(_currentWeapon, false);
            _currentWeapon = nextWeapon;
            EquipWeapon(_currentWeapon, true);
        }

        /// <summary>
        /// Equips/unequips the weapon at the given index.
        /// </summary>
        /// <param name="weaponIndex"></param>
        /// <param name="equip"></param>
        public void EquipWeapon(int weaponIndex, bool equip)
        {
            if (PlayerWeapons.Count == 0)
                return;

            if (equip)
            {
                _currentWeapon = weaponIndex;
                _itemEventManager.OnWeaponEquip(PlayerWeapons[_currentWeapon]);
            }
            else
            {
                _currentWeapon = -1;
            }
        }

        /// <summary>
        /// Performs an attack with the currently equipped weapon. Has no effect if no weapon is equipped.
        /// </summary>
        public void Attack()
        {
            if (PlayerWeapons.Count == 0 || _currentWeapon < 0)
                return;

            PlayerWeapons[_currentWeapon].Use();
        }

        private void OnEnable()
        {
            if (_inputEventManager == null)
                Debug.LogError("InputEventManager on PlayerController is missing. Input will not be detected!");

            if (_itemEventManager == null)
                Debug.LogError("ItemEventManager on PlayerController is missing. HUD will not work correctly!");

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
