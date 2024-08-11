using UnityEngine;
using UnityEngine.Events;
using WeaponrySystem.Items.Weapons;

namespace WeaponrySystem.Items
{
    /// <summary>
    /// A ScriptableObject that serves as an intermediary between classes
    /// that should be notified of item-related events.
    /// </summary>
    [CreateAssetMenu(fileName = "ItemEventManager", menuName = "Scriptable Objects/Item Event Manager")]
    public class ItemEventManager : ScriptableObject
    {
        public event UnityAction<Weapon> WeaponEquipEvent;

        /// <summary>
        /// Call to raise the WeaponEquipEvent when the given weapon was equipped.
        /// </summary>
        /// <param name="weapon"></param>
        public void OnWeaponEquip(Weapon weapon)
        {
            WeaponEquipEvent?.Invoke(weapon);
        }

        // Add more events if necessary...
    }
}
