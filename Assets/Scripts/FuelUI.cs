using UnityEngine;
using TMPro;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fuelText;

    private ShipMovement shipMovement;

    private void Start()
    {
        shipMovement = ShipMovement.Instance;
    }

    private void Update()
    {
        fuelText.text = shipMovement.GetBoosts().ToString();
    }
}
