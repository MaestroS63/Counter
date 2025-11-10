using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;

    private WaitForSeconds waitInterval;
    private Coroutine countCoroutine;

    private int counter = 0;
    private bool isCounting = false;

    private void Awake()
    {
        waitInterval = new WaitForSeconds(0.5f);
    }

    public void ToggleCounter()
    {
        if (isCounting)
        {
            StopCoroutine(countCoroutine);
            isCounting = false;
        }
        else
        {
            countCoroutine = StartCoroutine(CountRoutine());
            isCounting = true;
        }
    }

    private IEnumerator CountRoutine()
    {
        while (enabled)
        {
            counter++;
            counterText.text = counter.ToString();
            yield return waitInterval;
        }
    }
}