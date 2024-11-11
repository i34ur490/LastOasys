using UnityEngine;

public class AnimateTexture : MonoBehaviour
{
    public Material material; // Arraste o material diretamente no Inspetor
    public Sprite[] frames;   // Adicione os frames como Sprites
    public float framesPerSecond = 10.0f;

    private int currentFrame;
    private float timer;

    private void Update()
    {
        if (material != null && frames.Length > 0)
        {
            timer += Time.deltaTime;

            if (timer >= 1.0f / framesPerSecond)
            {
                // Converte o sprite atual para Texture2D
                Texture2D currentTexture = SpriteToTexture(frames[currentFrame]);

                // Define a textura no material
                material.mainTexture = currentTexture;

                // Avança para o próximo frame
                currentFrame = (currentFrame + 1) % frames.Length;
                timer = 0.0f;
            }
        }
        else if (material == null)
        {
            Debug.LogWarning("Material não foi atribuído no Inspetor!");
        }
    }

    // Função para converter Sprite em Texture2D
    private Texture2D SpriteToTexture(Sprite sprite)
    {
        if (sprite != null)
        {
            // Cria uma nova Texture2D a partir dos dados do sprite
            Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            texture.SetPixels(sprite.texture.GetPixels(
                (int)sprite.textureRect.x,
                (int)sprite.textureRect.y,
                (int)sprite.textureRect.width,
                (int)sprite.textureRect.height));
            texture.Apply();
            return texture;
        }
        return null;
    }
}
