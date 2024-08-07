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

        [SerializeField]
        protected HoldingType _weaponHolding;

        // To be used by other systems in the game
        public UnityEvent OnEquipped;
        public UnityEvent OnUnequipped;
        public UnityEvent OnAttackPerformed;

        protected enum HoldingType
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

        /// <summary>
        /// Indicates what weapon has been used for attack. For showcase purposes.
        /// </summary>
        /// <param name="weaponType"></param>
        protected void AttackDebug(string weaponType)
        {
            Debug.Log($"Player attacked with {Name} of type {weaponType}.");
        }
    }
}
