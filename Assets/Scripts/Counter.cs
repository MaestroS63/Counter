using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;

    private int counter = 0;
    private bool isCounting = false;
    private Coroutine countCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }
    }

    private void ToggleCounter()
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
        while (true)
        {
            counter++;
            counterText.text = counter.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
}