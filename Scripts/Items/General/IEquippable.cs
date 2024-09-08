using UnityEngine.AddressableAssets;

namespace WeaponrySystem.Items
{
    public interface IEquippable
    {
        string Name { get; }
        AssetReferenceTexture2D IconReference { get; }

        // Add more properties and methods if necessary...
    }
}

