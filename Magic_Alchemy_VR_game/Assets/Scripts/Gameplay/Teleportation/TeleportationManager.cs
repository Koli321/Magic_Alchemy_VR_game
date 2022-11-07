using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAssets;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;
    private InputAction stick;
    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        var activate = actionAssets.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAssets.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        stick = actionAssets.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        stick.Enable();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (!activated)
        {
            return;
        }

        if (stick.triggered)
        {
            return;
        }

        if (!rayInteractor.GetCurrentRaycastHit(out RaycastHit hit))
        {
            activated = false;
            return;
        }

        // Добавить таймер на касание клавиши, убрать касание - сделать нажатие клавиши, добавить контроллер.
        
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };
        provider.QueueTeleportRequest(request);
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        activated = true;
    }
    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        activated = false;
    }
}
