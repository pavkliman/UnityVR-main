using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;

public class PushButtonSecondStand : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable simpleInteractable;

    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private Outline _objectOutline;

    private bool _isPressed = false;

    private void Awake()
    {
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!_isPressed)
        {
            _isPressed = true;
            _objectOutline.enabled = true;

            _smokeEffect.Play();
        }
        else
        {
            _isPressed = false;
            _objectOutline.enabled = false;

            _smokeEffect.Stop();
        }
    }

}
