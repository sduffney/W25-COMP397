using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

namespace Platformer397
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
    public class InputReader : ScriptableObject, IPlayerActions
    {

        public event UnityAction<Vector2> Move = delegate {};

        InputSystem_Actions input;

        private void OnEnable()
        {
            if (input == null)
            {
                input = new InputSystem_Actions();
                input.Player.SetCallbacks(this);
            }
        }

        public void EnablePlayerActions()
        {
            input.Enable();
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
           // throw new System.NotImplementedException();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                case InputActionPhase.Canceled:
                    Move?.Invoke(context.ReadValue<Vector2>());
                    break;
                default:
                    Debug.Log("Not input handled");
                    break;

            }
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }
    }
}
