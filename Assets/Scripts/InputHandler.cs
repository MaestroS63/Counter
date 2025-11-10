using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Counter counter;

    private const int InteractionButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(InteractionButton))
        {
            counter.ToggleCounter();
        }
    }
}