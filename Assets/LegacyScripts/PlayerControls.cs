//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace LegacyMushrooms
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GameControls"",
            ""id"": ""aed9a827-f8ea-4225-9a4e-6711428b950f"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""fcbb7062-c7f5-42c9-b5aa-b8d6980f3eaa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""29e2c7f2-7004-42ab-bbef-201b4c6a5a63"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a44a4a6-0054-4c50-bd8d-3be00b5923ca"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4d9824a-af15-4c36-948b-efac58d6e4b4"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // GameControls
            m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
            m_GameControls_Touch = m_GameControls.FindAction("Touch", throwIfNotFound: true);
            m_GameControls_TouchPosition = m_GameControls.FindAction("TouchPosition", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // GameControls
        private readonly InputActionMap m_GameControls;
        private IGameControlsActions m_GameControlsActionsCallbackInterface;
        private readonly InputAction m_GameControls_Touch;
        private readonly InputAction m_GameControls_TouchPosition;
        public struct GameControlsActions
        {
            private @PlayerControls m_Wrapper;
            public GameControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Touch => m_Wrapper.m_GameControls_Touch;
            public InputAction @TouchPosition => m_Wrapper.m_GameControls_TouchPosition;
            public InputActionMap Get() { return m_Wrapper.m_GameControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
            public void SetCallbacks(IGameControlsActions instance)
            {
                if (m_Wrapper.m_GameControlsActionsCallbackInterface != null)
                {
                    @Touch.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnTouch;
                    @Touch.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnTouch;
                    @Touch.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnTouch;
                    @TouchPosition.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnTouchPosition;
                }
                m_Wrapper.m_GameControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Touch.started += instance.OnTouch;
                    @Touch.performed += instance.OnTouch;
                    @Touch.canceled += instance.OnTouch;
                    @TouchPosition.started += instance.OnTouchPosition;
                    @TouchPosition.performed += instance.OnTouchPosition;
                    @TouchPosition.canceled += instance.OnTouchPosition;
                }
            }
        }
        public GameControlsActions @GameControls => new GameControlsActions(this);
        public interface IGameControlsActions
        {
            void OnTouch(InputAction.CallbackContext context);
            void OnTouchPosition(InputAction.CallbackContext context);
        }
    }
}