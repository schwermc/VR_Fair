using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PoiBasket : MonoBehaviour
{
    [SerializeField] XRInteractionManager interactionManager;
    [SerializeField] XRBaseInteractor interactor;

    [Header("Poi")]
    [SerializeField] GameObject poiPrefab;

    [Header("Tickets")]
    [SerializeField] Currency currency;
    [SerializeField] int decreaseAmount = 10;

    public void GrabSpawnClone()
    {
        if (currency.getCurrentCurrencyAmount() >= decreaseAmount)
        {
            GameObject clone = Instantiate(poiPrefab, interactor.transform.position, Quaternion.identity);
            XRBaseInteractable grabInteractable = clone.GetComponent<XRBaseInteractable>();
            if (grabInteractable != null && interactionManager != null && interactor != null)
            {
                currency.removeFromCurrency(decreaseAmount);
                interactionManager.SelectEnter((IXRSelectInteractor)interactor, (IXRSelectInteractable)grabInteractable);
            }
        }
    }
}
