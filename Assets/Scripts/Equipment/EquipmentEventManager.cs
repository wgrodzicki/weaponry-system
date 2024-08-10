using UnityEngine;
using UnityEngine.Events;
using WeaponrySystem.Equipment.Weaponry;

namespace WeaponrySystem.Equipment
{
    [CreateAssetMenu(fileName = "EquipmentEventManager", menuName = "Scriptable Objects/Equipment Event Manager")]
    public class EquipmentEventManager : ScriptableObject
    {
        public event UnityAction<Weapon> WeaponEquipEvent;

        public void OnWeaponEquip(Weapon weapon)
        {
            WeaponEquipEvent?.Invoke(weapon);
        }
    }
}
