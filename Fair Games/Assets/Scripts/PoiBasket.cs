using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PoiBasket : MonoBehaviour
{
    [SerializeField] XRInteractionManager interactionManager;
    [SerializeField] XRBaseInteractor interactor;

    [Header ("Poi")]
    [SerializeField] GameObject poiPrefab;

    public void GrabSpawnClone()
    {
        GameObject clone = Instantiate(poiPrefab, interactor.transform.position, Quaternion.identity);
        XRBaseInteractable grabInteractable = clone.GetComponent<XRBaseInteractable>();

        if (grabInteractable != null && interactionManager != null && interactor != null)
        {
            interactionManager.SelectEnter((IXRSelectInteractor)interactor, (IXRSelectInteractable)grabInteractable);
        }
    }
}
