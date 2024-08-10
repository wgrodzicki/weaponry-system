using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

namespace WeaponrySystem.Equipment.Weaponry
{
    public abstract class Weapon : MonoBehaviour, IEquippable // Add other interfaces to implement, maybe IUsable, IPickable etc.
    {
        [field: SerializeField]
        public string Name { get; protected set; }
        [field: SerializeField]
        public int Damage { get; protected set; }
        [field: SerializeField]
        public float Range { get; protected set; }
        public bool IsEquipped { get; protected set; }
        [field: SerializeField]
        public AssetReferenceTexture2D IconReference { get; protected set; }

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

        protected virtual void Start()
        {
            LoadIcon(true);
        }

        protected virtual void OnDisable()
        {
            LoadIcon(false);
        }

        private void LoadIcon(bool load)
        {
            if (IconReference == null)
                return;

            if (load)
            {
                IconReference.LoadAssetAsync();
            }
            else
            {
                if (IconReference.IsValid())
                    IconReference.ReleaseAsset();
            }
        }
    }
}