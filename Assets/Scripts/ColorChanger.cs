using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material color1MAterial = null;
    public Material color2Material = null;

    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.onActivate.AddListener(SetColor1);
        grabInteractable.onDeactivate.AddListener(SetColor2);
    }

    private void OnDestroy()
    {
        grabInteractable.onActivate.RemoveListener(SetColor1);
        grabInteractable.onDeactivate.RemoveListener(SetColor2);
    }

    private void SetColor1(XRBaseInteractor interactor)
    {
        meshRenderer.material = color1MAterial;
    }

    private void SetColor2(XRBaseInteractor interactor)
    {
        meshRenderer.material = color2Material;
    }
}
