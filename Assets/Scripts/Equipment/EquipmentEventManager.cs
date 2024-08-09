using UnityEngine;
using UnityEngine.Events;

namespace WeaponrySystem.Equipment
{
    [CreateAssetMenu(fileName = "EquipmentEventManager", menuName = "Scriptable Objects/Equipment Event Manager")]
    public class EquipmentEventManager : ScriptableObject
    {
        public event UnityAction<string, Texture2D> WeaponEquipEvent;

        public void OnWeaponEquip(string name, Texture2D icon)
        {
            WeaponEquipEvent?.Invoke(name, icon);
        }
    }
}
