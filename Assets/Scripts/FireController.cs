// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/FireController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FireController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FireController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FireController"",
    ""maps"": [
        {
            ""name"": ""FireOnClick"",
            ""id"": ""e75b7a57-e2b6-4733-8284-70d2e2a43ed1"",
            ""actions"": [
                {
                    ""name"": ""FireOnMouse"",
                    ""type"": ""Button"",
                    ""id"": ""00ea328c-8e1c-4e40-8fba-95ede455d7e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""07c9f9c8-89c1-41e4-bd71-daf973a1d267"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""FireOnMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // FireOnClick
        m_FireOnClick = asset.FindActionMap("FireOnClick", throwIfNotFound: true);
        m_FireOnClick_FireOnMouse = m_FireOnClick.FindAction("FireOnMouse", throwIfNotFound: true);
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

    // FireOnClick
    private readonly InputActionMap m_FireOnClick;
    private IFireOnClickActions m_FireOnClickActionsCallbackInterface;
    private readonly InputAction m_FireOnClick_FireOnMouse;
    public struct FireOnClickActions
    {
        private @FireController m_Wrapper;
        public FireOnClickActions(@FireController wrapper) { m_Wrapper = wrapper; }
        public InputAction @FireOnMouse => m_Wrapper.m_FireOnClick_FireOnMouse;
        public InputActionMap Get() { return m_Wrapper.m_FireOnClick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FireOnClickActions set) { return set.Get(); }
        public void SetCallbacks(IFireOnClickActions instance)
        {
            if (m_Wrapper.m_FireOnClickActionsCallbackInterface != null)
            {
                @FireOnMouse.started -= m_Wrapper.m_FireOnClickActionsCallbackInterface.OnFireOnMouse;
                @FireOnMouse.performed -= m_Wrapper.m_FireOnClickActionsCallbackInterface.OnFireOnMouse;
                @FireOnMouse.canceled -= m_Wrapper.m_FireOnClickActionsCallbackInterface.OnFireOnMouse;
            }
            m_Wrapper.m_FireOnClickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FireOnMouse.started += instance.OnFireOnMouse;
                @FireOnMouse.performed += instance.OnFireOnMouse;
                @FireOnMouse.canceled += instance.OnFireOnMouse;
            }
        }
    }
    public FireOnClickActions @FireOnClick => new FireOnClickActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IFireOnClickActions
    {
        void OnFireOnMouse(InputAction.CallbackContext context);
    }
}
