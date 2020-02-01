// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""df3f2259-b87b-47b9-a5ba-0d737f66c9f8"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Button"",
                    ""id"": ""30bfcc27-3a8f-4019-803f-49b1f982daa1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ea116049-dc1d-4987-8633-504d9423ad9e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7cdb8bee-adaf-4f6a-8833-e336b397db9e"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eee0645b-6578-4600-a9a2-e979f5f4f79d"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay2"",
            ""id"": ""43e38c7b-dfdc-4643-8ba8-5a3c3b3ecc2d"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Button"",
                    ""id"": ""8f4801b9-3fea-43f3-874e-050c2b8f600c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""9ee087b9-3819-4c18-b77a-f0c410cea659"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a3fb3acd-5aa5-4a22-b418-a69612d72db5"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5a29349-0974-4a1b-94d7-4e73d2560c4a"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay3"",
            ""id"": ""26603394-c06d-4109-9e8f-eeae6b44c2b9"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Button"",
                    ""id"": ""a49abdad-5e5a-4f79-aa34-444a236ac441"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""e72ba1b4-1d44-4916-83ff-97009b08b0bd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b314c27-1784-4d46-84e7-16fa7e65eaf9"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bcc0ac0-203c-415d-87b4-f4b7a449ba4b"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay4"",
            ""id"": ""dbf642dd-7a5e-49f0-ba63-4fbbde7af928"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Button"",
                    ""id"": ""81317a20-c255-469c-95fa-c013c17997ba"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""1f10f0a4-310e-49f0-a83b-da7f402a9b0f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e5daf9f5-2b4b-4dfb-8bf8-ffdc73820146"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f36e7da-19d4-450d-bc65-5c15e0cfe31f"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
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
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        // Gameplay2
        m_Gameplay2 = asset.FindActionMap("Gameplay2", throwIfNotFound: true);
        m_Gameplay2_movement = m_Gameplay2.FindAction("movement", throwIfNotFound: true);
        m_Gameplay2_Dash = m_Gameplay2.FindAction("Dash", throwIfNotFound: true);
        // Gameplay3
        m_Gameplay3 = asset.FindActionMap("Gameplay3", throwIfNotFound: true);
        m_Gameplay3_movement = m_Gameplay3.FindAction("movement", throwIfNotFound: true);
        m_Gameplay3_Dash = m_Gameplay3.FindAction("Dash", throwIfNotFound: true);
        // Gameplay4
        m_Gameplay4 = asset.FindActionMap("Gameplay4", throwIfNotFound: true);
        m_Gameplay4_movement = m_Gameplay4.FindAction("movement", throwIfNotFound: true);
        m_Gameplay4_Dash = m_Gameplay4.FindAction("Dash", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Dash;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_Gameplay_movement;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
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
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Gameplay2
    private readonly InputActionMap m_Gameplay2;
    private IGameplay2Actions m_Gameplay2ActionsCallbackInterface;
    private readonly InputAction m_Gameplay2_movement;
    private readonly InputAction m_Gameplay2_Dash;
    public struct Gameplay2Actions
    {
        private @PlayerControls m_Wrapper;
        public Gameplay2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_Gameplay2_movement;
        public InputAction @Dash => m_Wrapper.m_Gameplay2_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay2Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay2Actions instance)
        {
            if (m_Wrapper.m_Gameplay2ActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnMovement;
                @Dash.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_Gameplay2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public Gameplay2Actions @Gameplay2 => new Gameplay2Actions(this);

    // Gameplay3
    private readonly InputActionMap m_Gameplay3;
    private IGameplay3Actions m_Gameplay3ActionsCallbackInterface;
    private readonly InputAction m_Gameplay3_movement;
    private readonly InputAction m_Gameplay3_Dash;
    public struct Gameplay3Actions
    {
        private @PlayerControls m_Wrapper;
        public Gameplay3Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_Gameplay3_movement;
        public InputAction @Dash => m_Wrapper.m_Gameplay3_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay3; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay3Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay3Actions instance)
        {
            if (m_Wrapper.m_Gameplay3ActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnMovement;
                @Dash.started -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_Gameplay3ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public Gameplay3Actions @Gameplay3 => new Gameplay3Actions(this);

    // Gameplay4
    private readonly InputActionMap m_Gameplay4;
    private IGameplay4Actions m_Gameplay4ActionsCallbackInterface;
    private readonly InputAction m_Gameplay4_movement;
    private readonly InputAction m_Gameplay4_Dash;
    public struct Gameplay4Actions
    {
        private @PlayerControls m_Wrapper;
        public Gameplay4Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_Gameplay4_movement;
        public InputAction @Dash => m_Wrapper.m_Gameplay4_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay4; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay4Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay4Actions instance)
        {
            if (m_Wrapper.m_Gameplay4ActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnMovement;
                @Dash.started -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_Gameplay4ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public Gameplay4Actions @Gameplay4 => new Gameplay4Actions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IGameplay2Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IGameplay3Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IGameplay4Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
