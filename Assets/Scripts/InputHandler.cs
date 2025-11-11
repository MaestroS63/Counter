using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int InteractionButton = 0;

    public static event Action s_OnInteractionTriggered;

    private void Update()
    {
        if (Input.GetMouseButtonDown(InteractionButton))
            s_OnInteractionTriggered?.Invoke();
    }
}