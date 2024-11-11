using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Posição fixa do rio
    [SerializeField]
    private Vector3 riverPosition = new Vector3(0, 0, 0); // Defina a posição no Inspetor

    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        // Obtém o Rigidbody do inimigo
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move em direção à posição fixa do rio
        Vector3 directionToRiver = (riverPosition - transform.position).normalized;
        rb.MovePosition(transform.position + directionToRiver * speed * Time.fixedDeltaTime);
    }
}
