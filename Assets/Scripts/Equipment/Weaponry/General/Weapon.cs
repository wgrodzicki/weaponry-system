using UnityEngine;
using UnityEngine.Events;

namespace WeaponrySystem
{
    public abstract class Weapon : MonoBehaviour, IEquippable // Add other interfaces to implement, maybe IUsable, etc.
    {
        [field: SerializeField]
        public string Name { get; protected set; }
        [field: SerializeField]
        public int Damage { get; protected set; }
        [field: SerializeField]
        public float Range { get; protected set; }
        [field: SerializeField]
        public bool IsEquipped { get; protected set; }
        [field: SerializeField]
        public HoldingType WeaponHolding { get; protected set; }

        // To be used by other systems in the game
        public UnityEvent OnEquipped;
        public UnityEvent OnUnequipped;
        public UnityEvent OnAttackPerformed;

        public enum HoldingType
        {
            OneHanded,
            TwoHanded
        }

        public virtual void Equip(bool equip)
        {
            IsEquipped = equip;

            if (equip)
                OnEquipped.Invoke();
            else
                OnUnequipped.Invoke();
        }

        public virtual void Attack()
        {
            OnAttackPerformed.Invoke();
            // To be implemented depending on weapon type
        }

        protected void AttackDebug(string weaponType)
        {
            Debug.Log($"Player attacked with {Name} of type {weaponType}");
        }
    }
}
