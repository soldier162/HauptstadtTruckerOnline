using UnityEngine;
using UnityEngine.UI;

public class DeliverySystem : MonoBehaviour
{
    public Text scoreText;
    public Text fuelText;
    private int score = 0;
    private TruckController truck;

    void Start()
    {
        truck = FindObjectOfType<TruckController>();
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Punkte: " + score;
        fuelText.text = "Tank: " + Mathf.Round(truck.fuel) + "%";
    }

    public void CompleteDelivery()
    {
        AddScore(100);
        Debug.Log("Lieferung abgeschlossen!");
    }
}