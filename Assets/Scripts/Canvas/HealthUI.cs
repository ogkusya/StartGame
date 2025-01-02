using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private TMP_Text _healthText;

    private void Awake()
    {
        _healthText = GetComponent<TMP_Text>();
    }

    public void UpdateHealthText(int health)
    {
        if (_healthText != null)
        {
            _healthText.text = health.ToString();
        }
        
    }
}
