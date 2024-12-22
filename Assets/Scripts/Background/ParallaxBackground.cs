using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float scrollSpeed = 0.2f; // Speed of background scrolling
    private Vector2 offset;         // Texture offset
    private Material backgroundMaterial; // Material of the background

    void Start()
    {
        // Get the material of the background
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Calculate offset based on time and scroll speed
        offset = new Vector2(scrollSpeed * Time.time, 0);

        // Apply offset to the material texture
        backgroundMaterial.mainTextureOffset = offset;
    }
}
