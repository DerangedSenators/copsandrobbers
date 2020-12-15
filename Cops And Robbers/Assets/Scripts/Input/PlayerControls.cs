// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""KeyMap"",
            ""id"": ""000cb310-0f87-4bad-a34b-e0761bbcac2e"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""99709c44-7e22-4d05-9d1b-af089a43e8aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""4e436329-ccb8-4f1f-96db-eb377f8dbdf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""116dbcfa-0dd4-4347-8be8-818a37ea9a97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""7ded8595-76a1-49ee-8ad0-894d1f9cb492"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6d53d873-f6bd-489f-a698-cbbcdf441444"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bbe47d9-4fea-4fa3-a87d-9198fb1edf3f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e2365a9-7e4d-4f6f-81c5-976015f74d42"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5954f532-8e3c-464c-9ccc-9e15b56af706"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74563960-a2dc-4d83-8c47-d6bf77986fa9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0851a52c-4c83-45b8-ada6-588e71b58431"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35c465d1-2665-4345-8386-291248b26dcc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90f42f13-9727-4f87-a5ab-93960466aedf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""AttackMap"",
            ""id"": ""c555eb68-e0d3-4c91-85f0-6e2d4b407976"",
            ""actions"": [
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""ed1c85fd-4a20-41c3-b712-0e2f7351ebe9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2134183d-65be-4f6f-a0ca-7f9ad72467f8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23ab07b0-1440-4231-bbac-02d8cae7d19d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraViewPoints"",
            ""id"": ""8499fc18-0dc4-41b7-9b62-79df31c6c49a"",
            ""actions"": [
                {
                    ""name"": ""FocusPlayer"",
                    ""type"": ""Value"",
                    ""id"": ""e69acfb1-d99d-4772-a383-9094263acf1b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomOut"",
                    ""type"": ""Button"",
                    ""id"": ""65c985df-abd0-4dde-940e-143c9cd038b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomIn"",
                    ""type"": ""Button"",
                    ""id"": ""3ac220e7-b182-4f8b-b1ec-5ee825d228ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""51994961-bb64-4886-9bc8-1299e2e8053d"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""FocusPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef204dc8-3dbb-4dd4-bb1c-9d54f2a0cf96"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ZoomOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecca0231-2396-46f8-aa67-38b5f2fc910f"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ZoomIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MouseActions"",
            ""id"": ""b22815b2-72b4-4598-be7c-f0f559fc9fc9"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""16453f95-8661-4e3c-9ea6-d94c4980b0ee"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6048c6bf-57a6-40ef-ba8f-a865fb04c386"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        }
    ]
}");
            // KeyMap
            m_KeyMap = asset.FindActionMap("KeyMap", throwIfNotFound: true);
            m_KeyMap_MoveUp = m_KeyMap.FindAction("MoveUp", throwIfNotFound: true);
            m_KeyMap_MoveDown = m_KeyMap.FindAction("MoveDown", throwIfNotFound: true);
            m_KeyMap_MoveLeft = m_KeyMap.FindAction("MoveLeft", throwIfNotFound: true);
            m_KeyMap_MoveRight = m_KeyMap.FindAction("MoveRight", throwIfNotFound: true);
            // AttackMap
            m_AttackMap = asset.FindActionMap("AttackMap", throwIfNotFound: true);
            m_AttackMap_Melee = m_AttackMap.FindAction("Melee", throwIfNotFound: true);
            // CameraViewPoints
            m_CameraViewPoints = asset.FindActionMap("CameraViewPoints", throwIfNotFound: true);
            m_CameraViewPoints_FocusPlayer = m_CameraViewPoints.FindAction("FocusPlayer", throwIfNotFound: true);
            m_CameraViewPoints_ZoomOut = m_CameraViewPoints.FindAction("ZoomOut", throwIfNotFound: true);
            m_CameraViewPoints_ZoomIn = m_CameraViewPoints.FindAction("ZoomIn", throwIfNotFound: true);
            // MouseActions
            m_MouseActions = asset.FindActionMap("MouseActions", throwIfNotFound: true);
            m_MouseActions_MousePosition = m_MouseActions.FindAction("MousePosition", throwIfNotFound: true);
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

        // KeyMap
        private readonly InputActionMap m_KeyMap;
        private IKeyMapActions m_KeyMapActionsCallbackInterface;
        private readonly InputAction m_KeyMap_MoveUp;
        private readonly InputAction m_KeyMap_MoveDown;
        private readonly InputAction m_KeyMap_MoveLeft;
        private readonly InputAction m_KeyMap_MoveRight;
        public struct KeyMapActions
        {
            private @PlayerControls m_Wrapper;
            public KeyMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveUp => m_Wrapper.m_KeyMap_MoveUp;
            public InputAction @MoveDown => m_Wrapper.m_KeyMap_MoveDown;
            public InputAction @MoveLeft => m_Wrapper.m_KeyMap_MoveLeft;
            public InputAction @MoveRight => m_Wrapper.m_KeyMap_MoveRight;
            public InputActionMap Get() { return m_Wrapper.m_KeyMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(KeyMapActions set) { return set.Get(); }
            public void SetCallbacks(IKeyMapActions instance)
            {
                if (m_Wrapper.m_KeyMapActionsCallbackInterface != null)
                {
                    @MoveUp.started -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveUp;
                    @MoveUp.performed -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveUp;
                    @MoveUp.canceled -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveUp;
                    @MoveDown.started -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveDown;
                    @MoveDown.performed -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveDown;
                    @MoveDown.canceled -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveDown;
                    @MoveLeft.started -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.performed -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.canceled -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveLeft;
                    @MoveRight.started -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveRight;
                    @MoveRight.performed -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveRight;
                    @MoveRight.canceled -= m_Wrapper.m_KeyMapActionsCallbackInterface.OnMoveRight;
                }
                m_Wrapper.m_KeyMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveUp.started += instance.OnMoveUp;
                    @MoveUp.performed += instance.OnMoveUp;
                    @MoveUp.canceled += instance.OnMoveUp;
                    @MoveDown.started += instance.OnMoveDown;
                    @MoveDown.performed += instance.OnMoveDown;
                    @MoveDown.canceled += instance.OnMoveDown;
                    @MoveLeft.started += instance.OnMoveLeft;
                    @MoveLeft.performed += instance.OnMoveLeft;
                    @MoveLeft.canceled += instance.OnMoveLeft;
                    @MoveRight.started += instance.OnMoveRight;
                    @MoveRight.performed += instance.OnMoveRight;
                    @MoveRight.canceled += instance.OnMoveRight;
                }
            }
        }
        public KeyMapActions @KeyMap => new KeyMapActions(this);

        // AttackMap
        private readonly InputActionMap m_AttackMap;
        private IAttackMapActions m_AttackMapActionsCallbackInterface;
        private readonly InputAction m_AttackMap_Melee;
        public struct AttackMapActions
        {
            private @PlayerControls m_Wrapper;
            public AttackMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Melee => m_Wrapper.m_AttackMap_Melee;
            public InputActionMap Get() { return m_Wrapper.m_AttackMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AttackMapActions set) { return set.Get(); }
            public void SetCallbacks(IAttackMapActions instance)
            {
                if (m_Wrapper.m_AttackMapActionsCallbackInterface != null)
                {
                    @Melee.started -= m_Wrapper.m_AttackMapActionsCallbackInterface.OnMelee;
                    @Melee.performed -= m_Wrapper.m_AttackMapActionsCallbackInterface.OnMelee;
                    @Melee.canceled -= m_Wrapper.m_AttackMapActionsCallbackInterface.OnMelee;
                }
                m_Wrapper.m_AttackMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Melee.started += instance.OnMelee;
                    @Melee.performed += instance.OnMelee;
                    @Melee.canceled += instance.OnMelee;
                }
            }
        }
        public AttackMapActions @AttackMap => new AttackMapActions(this);

        // CameraViewPoints
        private readonly InputActionMap m_CameraViewPoints;
        private ICameraViewPointsActions m_CameraViewPointsActionsCallbackInterface;
        private readonly InputAction m_CameraViewPoints_FocusPlayer;
        private readonly InputAction m_CameraViewPoints_ZoomOut;
        private readonly InputAction m_CameraViewPoints_ZoomIn;
        public struct CameraViewPointsActions
        {
            private @PlayerControls m_Wrapper;
            public CameraViewPointsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @FocusPlayer => m_Wrapper.m_CameraViewPoints_FocusPlayer;
            public InputAction @ZoomOut => m_Wrapper.m_CameraViewPoints_ZoomOut;
            public InputAction @ZoomIn => m_Wrapper.m_CameraViewPoints_ZoomIn;
            public InputActionMap Get() { return m_Wrapper.m_CameraViewPoints; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraViewPointsActions set) { return set.Get(); }
            public void SetCallbacks(ICameraViewPointsActions instance)
            {
                if (m_Wrapper.m_CameraViewPointsActionsCallbackInterface != null)
                {
                    @FocusPlayer.started -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnFocusPlayer;
                    @FocusPlayer.performed -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnFocusPlayer;
                    @FocusPlayer.canceled -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnFocusPlayer;
                    @ZoomOut.started -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnZoomOut;
                    @ZoomOut.performed -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnZoomOut;
                    @ZoomOut.canceled -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnZoomOut;
                    @ZoomIn.started -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnZoomIn;
                    @ZoomIn.performed -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnZoomIn;
                    @ZoomIn.canceled -= m_Wrapper.m_CameraViewPointsActionsCallbackInterface.OnZoomIn;
                }
                m_Wrapper.m_CameraViewPointsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @FocusPlayer.started += instance.OnFocusPlayer;
                    @FocusPlayer.performed += instance.OnFocusPlayer;
                    @FocusPlayer.canceled += instance.OnFocusPlayer;
                    @ZoomOut.started += instance.OnZoomOut;
                    @ZoomOut.performed += instance.OnZoomOut;
                    @ZoomOut.canceled += instance.OnZoomOut;
                    @ZoomIn.started += instance.OnZoomIn;
                    @ZoomIn.performed += instance.OnZoomIn;
                    @ZoomIn.canceled += instance.OnZoomIn;
                }
            }
        }
        public CameraViewPointsActions @CameraViewPoints => new CameraViewPointsActions(this);

        // MouseActions
        private readonly InputActionMap m_MouseActions;
        private IMouseActionsActions m_MouseActionsActionsCallbackInterface;
        private readonly InputAction m_MouseActions_MousePosition;
        public struct MouseActionsActions
        {
            private @PlayerControls m_Wrapper;
            public MouseActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePosition => m_Wrapper.m_MouseActions_MousePosition;
            public InputActionMap Get() { return m_Wrapper.m_MouseActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MouseActionsActions set) { return set.Get(); }
            public void SetCallbacks(IMouseActionsActions instance)
            {
                if (m_Wrapper.m_MouseActionsActionsCallbackInterface != null)
                {
                    @MousePosition.started -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_MouseActionsActionsCallbackInterface.OnMousePosition;
                }
                m_Wrapper.m_MouseActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                }
            }
        }
        public MouseActionsActions @MouseActions => new MouseActionsActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        public interface IKeyMapActions
        {
            void OnMoveUp(InputAction.CallbackContext context);
            void OnMoveDown(InputAction.CallbackContext context);
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
        }
        public interface IAttackMapActions
        {
            void OnMelee(InputAction.CallbackContext context);
        }
        public interface ICameraViewPointsActions
        {
            void OnFocusPlayer(InputAction.CallbackContext context);
            void OnZoomOut(InputAction.CallbackContext context);
            void OnZoomIn(InputAction.CallbackContext context);
        }
        public interface IMouseActionsActions
        {
            void OnMousePosition(InputAction.CallbackContext context);
        }
    }
}
