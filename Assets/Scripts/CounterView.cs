using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;

    public void UpdateCounterDisplay(int value)
    {
        if (counterText != null)
            counterText.text = value.ToString();
    }

    private void OnEnable()
    {
        Counter counter = GetComponent<Counter>();

        if (counter != null)
            counter.OnCounterChanged += UpdateCounterDisplay;
    }

    private void OnDisable()
    {
        Counter counter = GetComponent<Counter>();

        if (counter != null)
            counter.OnCounterChanged -= UpdateCounterDisplay;
    }
}