using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public TrashCategory binCategory;  // Tipo de lixo que essa lixeira aceita
    public int moneyReward = 10;       // Quantidade de dinheiro que o jogador recebe por descartar o lixo correto

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Verifica se é o jogador que está na lixeira
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (playerInventory != null && playerInventory.HasTrash())
            {
                // Percorre todos os itens do inventário do jogador
                for (int i = 0; i < playerInventory.GetInventoryCount(); i++)
                {
                    GameObject trashItem = playerInventory.GetTrashAt(i);  // Pega o lixo em cada posição do inventário
                    TrashType trashType = trashItem.GetComponent<TrashType>();

                    if (trashType != null && trashType.GetTrashCategory() == binCategory)
                    {
                        // Descartar o lixo e dar dinheiro ao jogador
                        playerInventory.DiscardTrash(i);  // Passa o índice para descartar o lixo correto
                        playerInventory.AddMoney(moneyReward);
                        Debug.Log("Lixo descartado corretamente! Você recebeu: " + moneyReward + " moedas.");
                        break;  // Sai do loop depois de descartar o lixo correto
                    }
                    else
                    {
                        Debug.Log("Este lixo não é o correto!");
                    }
                }
            }
        }
    }
}
