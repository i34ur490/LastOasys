using TMPro;
using UnityEngine;

public class StreamBehavior : MonoBehaviour
{
    public int streamHealth = 5;
    public GameController gameController;
    public TextMeshProUGUI streamHealthText;  // Reference to the UI Text for stream health


    private void Update()
    {
        UpdateStreamHealthUI();
    }
    public void IncreaseHealth(int amount)
    {
        streamHealth += amount;
        Debug.Log("Stream health increased! New health: " + streamHealth);
    }

    public void RechargeHealth(int maxHealth)
    {
        streamHealth = maxHealth;
        Debug.Log("Stream health recharged! Health is now full: " + streamHealth);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            streamHealth--;
            Destroy(collision.gameObject);

            if (streamHealth <= 0)
            {
                gameController.GameOver();
            }
        }
    }

    void UpdateStreamHealthUI()
    {
        if (streamHealthText != null)
        {
            streamHealthText.text = "Stream Health: " + streamHealth;
        }
    }
}
