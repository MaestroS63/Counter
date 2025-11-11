using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private WaitForSeconds waitInterval;
    private Coroutine countCoroutine;

    private int counter = 0;
    private bool isCounting = false;

    public event Action<int> OnCounterChanged;

    private void Awake()
    {
        waitInterval = new WaitForSeconds(0.5f);
    }

    private void OnEnable()
    {
        InputHandler.s_OnInteractionTriggered += ToggleCounter;
    }

    private void OnDisable()
    {
        InputHandler.s_OnInteractionTriggered -= ToggleCounter;
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
            countCoroutine = StartCoroutine(CountCoroutine());
            isCounting = true;
        }
    }

    private IEnumerator CountCoroutine()
    {
        while (enabled)
        {
            counter++;
            OnCounterChanged?.Invoke(counter);
            yield return waitInterval;
        }
    }
}