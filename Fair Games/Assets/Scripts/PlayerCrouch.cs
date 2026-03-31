using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouch : MonoBehaviour
{
    [Header ("XR")]
    [SerializeField] XROrigin xrOrigin;
    [SerializeField] InputActionReference crouchButton;

    [Header("Crouch Info")]
    [SerializeField] float startingHeight;
    [SerializeField] float crouchHeight;
    [SerializeField] private bool isCrouched;

    void Start()
    {
        if (xrOrigin == null) { xrOrigin = gameObject.GetComponent<XROrigin>(); }
        crouchButton.action.started += Crouch;

        isCrouched = false;

        if (startingHeight == 0) { startingHeight = 4; }
        if (crouchHeight == 0) { crouchHeight = startingHeight / 2; }
    }

    void OnDestroy()
    {
        crouchButton.action.started -= Crouch;
    }

    public void Crouch(InputAction.CallbackContext obj)
    {
        isCrouched = !isCrouched;
        xrOrigin.CameraYOffset = (isCrouched) ? crouchHeight : startingHeight;
    }
}
