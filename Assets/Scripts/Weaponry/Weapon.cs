using System;
using UnityEngine;

namespace WeaponrySystem
{
    public abstract class Weapon : MonoBehaviour, IEquippable
    {
        // To be used by other systems in the game
        public Action OnEquipped;
        public Action OnUnequipped;
        public Action OnAttackPerformed;

        public enum HoldingMode
        {
            OneHanded,
            TwoHanded
        }

        public HoldingMode Holding;

        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public float Range { get; protected set; }
        public bool IsEquipped { get; protected set; }

        public virtual void Equip(bool equip)
        {
            IsEquipped = equip;

            if (equip)
                OnEquipped?.Invoke();
            else
                OnUnequipped?.Invoke();
        }

        public virtual void Attack()
        {
            // To be implemented depending on weapon type
            Debug.Log($"Player attacked with {Name}");
            OnAttackPerformed?.Invoke();
        }
    }
}
