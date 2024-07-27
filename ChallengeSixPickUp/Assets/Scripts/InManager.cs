using System;
using UnityEngine;
using TMPro;

public class InManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI invintoryText;
    private int item;

    private void Start()
    {
        invintoryText.text = "Item(s): " + item;
    }

    public void ItemCounter()
    {
        item++;
        invintoryText.text = "Item(s): " + item;
    }
}
