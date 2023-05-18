using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isPlayerNearby = false;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (isPlayerNearby)
        {
            // Предотвращаем прохождение игрока сквозь дверь
            interactor.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }*/
    }
}
