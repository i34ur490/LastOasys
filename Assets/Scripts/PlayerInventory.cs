using UnityEngine;
using System.Collections.Generic;
using TMPro;  // Required for TextMeshPro


public class PlayerInventory : MonoBehaviour
{
    public int maxSlots = 1;  // Número inicial de slots
    private List<GameObject> inventory = new List<GameObject>();  // Inventário
    private int playerMoney = 0;  // Dinheiro do jogador

    [SerializeField] private Transform headTransform;  // Transform da cabeça do jogador
    [SerializeField] private float pickupRange = 2f;  // Raio para detectar o lixo
    [SerializeField] private float spacing = 0.5f;  // Distância entre os itens

    [SerializeField] private TMP_Text moneyText;  // Reference to the UI text element for displaying money


    void Update()
    {
        // Detecta lixos no alcance para pegar
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Trash") && hitCollider.transform.parent == null && inventory.Count < maxSlots)
            {
                PickUpTrash(hitCollider.gameObject);
                break;  // Pega um item de cada vez
            }
        }
    }

    void PickUpTrash(GameObject trash)
    {
        if (inventory.Count < maxSlots)
        {
            inventory.Add(trash);

            // Desabilitar física para não cair (não usar gravidade)
            Rigidbody rb = trash.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            // Posicionar o lixo na cabeça do jogador
            Vector3 newPosition = headTransform.position + new Vector3(0, inventory.Count * spacing, 0);
            trash.transform.position = newPosition;

            trash.transform.SetParent(headTransform);  // Seguir o jogador
            trash.SetActive(true);  // Garantir que o lixo esteja visível
        }
    }

    // Checa se o jogador tem lixo
    public bool HasTrash()
    {
        return inventory.Count > 0;
    }

    // Retorna o número de itens no inventário
    public int GetInventoryCount()
    {
        return inventory.Count;
    }

    // Retorna o lixo de uma posição específica no inventário
    public GameObject GetTrashAt(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            return inventory[index];
        }
        return null;
    }

    // Descartar lixo (libera o slot)
    public void DiscardTrash(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            GameObject discardedTrash = inventory[index];
            inventory.RemoveAt(index);  // Remove o lixo do inventário
            Destroy(discardedTrash);  // Destrói o lixo

            // Agora a posição no inventário está "vazia", então um novo item pode ser colocado no slot

            // Atualiza a exibição do inventário, caso tenha uma interface (UI)
            UpdateInventoryDisplay();
        }
    }

    // Adicionar dinheiro ao jogador
    public void AddMoney(int amount)
    {
        playerMoney += amount;
        Debug.Log("Dinheiro do jogador: " + playerMoney);
        UpdateMoneyUI();  // Update the money display in the UI

    }

    // Atualiza a exibição do inventário (UI)
    void UpdateInventoryDisplay()
    {
        // Aqui você pode adicionar um código para atualizar a UI se necessário
        // Se houver uma barra de itens ou algo similar, ela pode refletir a mudança
    }

    // Função para comprar upgrades
    public void UpgradeInventory()
    {
        maxSlots++;  // Aumenta o número de slots
    }

    // Updates the money UI text to show the current balance
    void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "$: " + playerMoney.ToString();
        }
    }

    // Methods to add or spend money
    public int GetMoney() { return playerMoney; }

    public bool SpendMoney(int amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
            UpdateMoneyUI();
            return true;
        }
        return false;
    }

}
