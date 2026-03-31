using Unity.XR.CoreUtils;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField] XROrigin xrOrigin;
    [SerializeField] float startingHeight;
    [SerializeField] float crouchHeight;

    private bool isCrouched;

    void Start()
    {
        if (xrOrigin == null) { xrOrigin = gameObject.GetComponent<XROrigin>(); }

        isCrouched = false;

        if (startingHeight == 0) { startingHeight = 4; }
        if (crouchHeight == 0) { crouchHeight = startingHeight / 2; }
    }

    void Update()
    {
        if (Input.GetButtonDown("XRI_Right_PrimaryButton"))
        {
            Crouch();
        }
    }

    public void Crouch()
    {
        if (!isCrouched)
        {
            isCrouched = true;
            xrOrigin.CameraYOffset = crouchHeight;
        }

        if (isCrouched)
        {
            isCrouched = false;
            xrOrigin.CameraYOffset = startingHeight;
        }
    }
}
