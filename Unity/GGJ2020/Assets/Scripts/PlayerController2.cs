// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController2.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController2 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController2()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController2"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""dae73ab1-74e6-4054-ba1c-2a8cbc8d7629"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6c654344-0bdf-46ac-baaa-62164c04d2ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a248394c-f63f-4ecc-8315-54473bb8b906"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_movement = m_Gameplay.FindAction("movement", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_movement;
    public struct GameplayActions
    {
        private @PlayerController2 m_Wrapper;
        public GameplayActions(@PlayerController2 wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_Gameplay_movement;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
