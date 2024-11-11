using UnityEngine;

public class Enemy : MonoBehaviour
{
    // List of possible trash items the enemy can carry
    public GameObject[] trashItems;

    // The trash item this enemy is currently holding
    private GameObject currentTrash;

    [SerializeField]
    private Transform handTransform;

    void Start()
    {
        // Pick a random trash item from the list
        int randomIndex = Random.Range(0, trashItems.Length);
        currentTrash = Instantiate(trashItems[randomIndex], handTransform.position, Quaternion.identity);

        // Make the trash item a child of the enemy's "hand" so it follows the enemy
        currentTrash.transform.SetParent(handTransform);
    }

    // Function called when the enemy dies
    public void DropTrash()
    {
        // Remove the trash from the enemy and place it on the ground
        if (currentTrash != null)
        {
            currentTrash.transform.SetParent(null);
            currentTrash.transform.position = transform.position;
            currentTrash.SetActive(true);  // Make sure it’s visible and collectible
        }
    }

    void OnDestroy()
    {
        // When enemy is destroyed, drop the trash
        DropTrash();
    }
}
