using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
public class ParticleManager : MonoBehaviour
{

    [SerializeField]
    Attractor proton;

    [SerializeField]
    Attractor electron;

    [SerializeField]
    Transform rightHandLocation;
    HapticImpulsePlayer haptic;
    
    [SerializeField]
    Transform LeftHandLocation;
    public InputActionReference rightPrimaryButton;
    public InputActionReference leftPrimaryButton;
    // Start is called before the first frame update
    void Start()
    {
        rightPrimaryButton.action.started += RightButtonWasPressed;
        leftPrimaryButton.action.started += LeftButtonWasPressed;
    }

    private void LeftButtonWasPressed(InputAction.CallbackContext context)
    {
        Instantiate(electron, LeftHandLocation.position, LeftHandLocation.rotation);
    }

    private void RightButtonWasPressed(InputAction.CallbackContext context)
    {
        Instantiate(proton, rightHandLocation.position, rightHandLocation.rotation);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
