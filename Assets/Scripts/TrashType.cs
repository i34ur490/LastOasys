using UnityEngine;

public enum TrashCategory
{
    Paper,      // Papel (azul)
    Food,       // Comida (marrom)
    Plastic,    // Plástico (amarelo)
    Can,        // Lata (amarelo)
    Glass       // Vidro (verde)
}

public class TrashType : MonoBehaviour
{
    public TrashCategory trashCategory;  // Definir o tipo de lixo

    // Função para obter o tipo de lixo
    public TrashCategory GetTrashCategory()
    {
        return trashCategory;
    }
}
