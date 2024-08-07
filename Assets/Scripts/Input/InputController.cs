using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace WeaponrySystem
{
    [CreateAssetMenu(fileName = "InputController", menuName = "ScriptableObjects/InputController")]
    public class InputController : ScriptableObject
    {
        public event UnityAction AttackEvent;
        public event UnityAction SwapWeaponEvent;

        private InputAction _attackAction;
        private InputAction _swapWeaponAction;

        private void OnEnable()
        {
            // Attack
            _attackAction = InputSystem.actions.FindAction("Attack");

            if (_attackAction != null)
                _attackAction.performed += context => OnAttack(context);

            // Swap Weapon
            _swapWeaponAction = InputSystem.actions.FindAction("SwapWeapon");

            if (_swapWeaponAction != null)
                _swapWeaponAction.performed += context => OnSwapWeapon(context);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (AttackEvent == null)
                return;

            if (context.phase == InputActionPhase.Performed)
                AttackEvent.Invoke();
        }

        public void OnSwapWeapon(InputAction.CallbackContext context)
        {
            if (SwapWeaponEvent == null)
                return;

            if (context.phase == InputActionPhase.Performed)
                SwapWeaponEvent.Invoke();
        }
    }
}
