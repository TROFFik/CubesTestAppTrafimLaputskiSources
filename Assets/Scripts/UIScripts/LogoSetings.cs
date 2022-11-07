using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogoSetings : MonoBehaviour
{
    [SerializeField] private List<string> phrases;
    [SerializeField] private TextMeshProUGUI phrasesText;
    private void Start()
    {
        phrasesText.text = phrases[Random.Range(0, phrases.Count)]; 
    }
}
