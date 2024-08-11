using UnityEngine;
using UnityEngine.AddressableAssets;

namespace WeaponrySystem.Items.Weapons
{
    /// <summary>
    /// A base class that represents traits and functionalities common for all weapons.
    /// </summary>
    public abstract class Weapon : MonoBehaviour, IUsable, IEquippable
    {
        [Tooltip("Name of the weapon.")]
        [field: SerializeField]
        public string Name { get; protected set; }
        [Tooltip("Damage dealt by the weapon.")]
        [field: SerializeField]
        public int Damage { get; protected set; }
        [Tooltip("Range of the weapon within which it can reach the target.")]
        [field: SerializeField]
        public float Range { get; protected set; }
        [Tooltip("Reference to the icon asset of the weapon.")]
        [field: SerializeField]
        public AssetReferenceTexture2D IconReference { get; protected set; }

        [Tooltip("Whether the weapon requires one or two hands to be held.")]
        [SerializeField]
        protected HoldingType _weaponHolding;

        protected enum HoldingType
        {
            OneHanded,
            TwoHanded
        }

        /// <summary>
        /// Uses the weapon.
        /// </summary>
        public virtual void Use()
        {
            // To be implemented depending on weapon type...
        }

        /// <summary>
        /// Indicates what weapon has been used for attack. For showcase purposes.
        /// </summary>
        /// <param name="weaponType"></param>
        protected void WeaponUseDebug(string weaponType)
        {
            Debug.Log($"Player used {Name} of type {weaponType}.");
        }

        protected virtual void OnEnable()
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