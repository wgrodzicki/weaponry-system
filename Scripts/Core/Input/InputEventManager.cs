using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace WeaponrySystem.Core
{
    /// <summary>
    /// A ScriptableObject that serves as an intermediary between the Unity's InputSystem
    /// and other classes that should be aware of player's input.
    /// </summary>
    [CreateAssetMenu(fileName = "InputEventManager", menuName = "Scriptable Objects/Input Event Manager")]
    public class InputEventManager : ScriptableObject
    {
        public event UnityAction AttackEvent;
        public event UnityAction SwapWeaponEvent;

        private InputAction _attackAction;
        private InputAction _swapWeaponAction;

        /// <summary>
        /// Call to raise the AttackEvent when the Attack action was performed.
        /// </summary>
        /// <param name="context"></param>
        public void OnAttack(InputAction.CallbackContext context)
        {
            if (AttackEvent == null)
                return;

            if (context.phase == InputActionPhase.Performed)
                AttackEvent.Invoke();
        }

        /// <summary>
        /// Call to raise the SwapWeaponEvent when the SwapWeapon action was performed.
        /// </summary>
        /// <param name="context"></param>
        public void OnSwapWeapon(InputAction.CallbackContext context)
        {
            if (SwapWeaponEvent == null)
                return;

            if (context.phase == InputActionPhase.Performed)
                SwapWeaponEvent.Invoke();
        }

        private void OnEnable()
        {
            if (InputSystem.actions == null) // Avoid null refs on first loads in the Editor
                return;

            // Attack
            _attackAction = InputSystem.actions.FindAction("Attack");

            if (_attackAction != null)
                _attackAction.performed += context => OnAttack(context);

            // Swap Weapon
            _swapWeaponAction = InputSystem.actions.FindAction("SwapWeapon");

            if (_swapWeaponAction != null)
                _swapWeaponAction.performed += context => OnSwapWeapon(context);

            // Add more actions if necessary...
        }
    }
}
