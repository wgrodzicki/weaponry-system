using UnityEngine;

namespace WeaponrySystem.Equipment
{
    public interface IEquippable
    {
        bool IsEquipped { get; }
        Texture2D Icon { get; }

        void Equip(bool equip);
    }
}

