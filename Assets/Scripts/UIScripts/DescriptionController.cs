using System.Collections;
using UnityEngine;

public class DescriptionController : MonoBehaviour
{
    [SerializeField] private GameObject description;
    [SerializeField] private float secondsForTimer;

    private Coroutine coroutine;

    public void OnPointerEnter()
    {
        coroutine = StartCoroutine(TimerCorutine());
    }

    public void OnPointerExit()
    {
        StopCoroutine(coroutine);
        description.SetActive(false);
    }

    private IEnumerator TimerCorutine()
    {
        yield return new WaitForSeconds(secondsForTimer);
        description.SetActive(true);
    }
}
