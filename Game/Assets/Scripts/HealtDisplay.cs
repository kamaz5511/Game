using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealtDisplay : MonoBehaviour
{
    public static HealtDisplay Instance { get; private set; }
    private Image FillImage;
    [SerializeField] private TextMeshProUGUI HealthDisplay;

    private void Awake() => Instance = this;
    private void Start()
    {
        FillImage = GetComponent<Image>();
    }
    public void Display(int health, int maxhealth)
    {
        FillImage.fillAmount = (float)health / maxhealth;
        HealthDisplay.text = health + " / " + maxhealth;
    }
}
