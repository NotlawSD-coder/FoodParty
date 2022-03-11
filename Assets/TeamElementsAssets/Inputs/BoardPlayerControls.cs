// GENERATED AUTOMATICALLY FROM 'Assets/TeamElementsAssets/Inputs/BoardPlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BoardPlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BoardPlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BoardPlayerControls"",
    ""maps"": [
        {
            ""name"": ""Dice"",
            ""id"": ""a8b0cdc8-b719-40e5-b27b-6e62be13901c"",
            ""actions"": [
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""035d3aa0-898a-48dc-b75e-56036974e5c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""438b70d9-247f-4052-ba2f-5244744cbacc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18c1d1a6-d715-45bc-9212-07daec6e5f9e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""6b026fd0-04c6-4883-8418-44148503f8e8"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""d9570fd4-2539-4ce7-82ef-4a67e250ce69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""86128ad9-11cf-4d5a-87e0-8c5b8d54c1d0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbdc68fc-35f9-4682-8bbd-a3ffe40c0584"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Map"",
            ""id"": ""5c7d1925-e73c-4d11-8a18-74cdeac3363c"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""14fb94b2-9c2e-4440-b0e3-4838d33f7beb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5314403b-d7f2-4e5c-b975-3d9da5cee247"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f1165057-cfab-46fe-8771-39c8f3e62148"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94a5b956-d54e-4011-b3ad-03879222b27c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""3eb299d0-db2d-43d3-b645-fc21e61c7dd9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""acfdc73c-e2f9-4c24-9295-46644b08302f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d83ffb98-c62d-490b-8d86-86c23bf79d47"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a3edfe80-46b2-452a-a5d9-d825a7ce7565"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7340ea09-0cf3-48f1-8990-ba7121c25094"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""57c2f56c-7957-4760-bb26-a94529b76f1c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""82127149-5024-4348-bde8-7ba0980b69fc"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c26e8bdb-d815-48ec-9f82-7f617758160e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""40e91e6a-4b3d-4292-a8cf-1918405935e9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5b7763d3-42cc-4b8b-8e55-56ece7598d00"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Dice
        m_Dice = asset.FindActionMap("Dice", throwIfNotFound: true);
        m_Dice_Throw = m_Dice.FindAction("Throw", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_Toggle = m_Inventory.FindAction("Toggle", throwIfNotFound: true);
        // Map
        m_Map = asset.FindActionMap("Map", throwIfNotFound: true);
        m_Map_Toggle = m_Map.FindAction("Toggle", throwIfNotFound: true);
        m_Map_Move = m_Map.FindAction("Move", throwIfNotFound: true);
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

    // Dice
    private readonly InputActionMap m_Dice;
    private IDiceActions m_DiceActionsCallbackInterface;
    private readonly InputAction m_Dice_Throw;
    public struct DiceActions
    {
        private @BoardPlayerControls m_Wrapper;
        public DiceActions(@BoardPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throw => m_Wrapper.m_Dice_Throw;
        public InputActionMap Get() { return m_Wrapper.m_Dice; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DiceActions set) { return set.Get(); }
        public void SetCallbacks(IDiceActions instance)
        {
            if (m_Wrapper.m_DiceActionsCallbackInterface != null)
            {
                @Throw.started -= m_Wrapper.m_DiceActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_DiceActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_DiceActionsCallbackInterface.OnThrow;
            }
            m_Wrapper.m_DiceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
            }
        }
    }
    public DiceActions @Dice => new DiceActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_Toggle;
    public struct InventoryActions
    {
        private @BoardPlayerControls m_Wrapper;
        public InventoryActions(@BoardPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Toggle => m_Wrapper.m_Inventory_Toggle;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @Toggle.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnToggle;
                @Toggle.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnToggle;
                @Toggle.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnToggle;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Toggle.started += instance.OnToggle;
                @Toggle.performed += instance.OnToggle;
                @Toggle.canceled += instance.OnToggle;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);

    // Map
    private readonly InputActionMap m_Map;
    private IMapActions m_MapActionsCallbackInterface;
    private readonly InputAction m_Map_Toggle;
    private readonly InputAction m_Map_Move;
    public struct MapActions
    {
        private @BoardPlayerControls m_Wrapper;
        public MapActions(@BoardPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Toggle => m_Wrapper.m_Map_Toggle;
        public InputAction @Move => m_Wrapper.m_Map_Move;
        public InputActionMap Get() { return m_Wrapper.m_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActions set) { return set.Get(); }
        public void SetCallbacks(IMapActions instance)
        {
            if (m_Wrapper.m_MapActionsCallbackInterface != null)
            {
                @Toggle.started -= m_Wrapper.m_MapActionsCallbackInterface.OnToggle;
                @Toggle.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnToggle;
                @Toggle.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnToggle;
                @Move.started -= m_Wrapper.m_MapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Toggle.started += instance.OnToggle;
                @Toggle.performed += instance.OnToggle;
                @Toggle.canceled += instance.OnToggle;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public MapActions @Map => new MapActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IDiceActions
    {
        void OnThrow(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnToggle(InputAction.CallbackContext context);
    }
    public interface IMapActions
    {
        void OnToggle(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
