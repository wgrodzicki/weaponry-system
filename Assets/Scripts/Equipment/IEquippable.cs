using UnityEngine.AddressableAssets;

namespace WeaponrySystem.Equipment
{
    public interface IEquippable
    {
        string Name { get; }
        bool IsEquipped { get; }
        AssetReferenceTexture2D IconReference { get; }

        void Equip(bool equip);
    }
}

