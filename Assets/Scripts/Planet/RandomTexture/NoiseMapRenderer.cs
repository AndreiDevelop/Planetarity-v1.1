using System;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapRenderer : MonoBehaviour
{
    // Determining the coloring of the map depending on the height
    [Serializable]
    public struct TerrainLevel
    {
        public string name;
        public float height;
        public Color color;
    }

    public List<TerrainLevel> terrainLevel = new List<TerrainLevel>();
    private Renderer _rend;

    private void Awake()
    {
        _rend = GetComponent<Renderer>();
    }

    // Depending on the type, we draw noise either in black and white or in color
    public void RenderMap(int width, int height, float[] noiseMap, MapType type)
    {
        if (type == MapType.Noise)
        {
            ApplyColorMap(width, height, GenerateNoiseMap(noiseMap));
        }
        else if (type == MapType.Color)
        {
            ApplyColorMap(width, height, GenerateColorMap(noiseMap));
        }
    }

    // Create texture and sprite to display
    private void ApplyColorMap(int width, int height, Color[] colors)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(colors);
        texture.Apply();

        _rend.material.SetTexture("_MainTex", texture);
    }

    // Convert an array with noise data into an array of black and white colors, for transmission to the texture
    private Color[] GenerateNoiseMap(float[] noiseMap)
    {
        Color[] colorMap = new Color[noiseMap.Length];
        for (int i = 0; i < noiseMap.Length; i++)
        {
            colorMap[i] = Color.Lerp(Color.black, Color.white, noiseMap[i]);
        }
        return colorMap;
    }

    // Convert an array with noise data into an array of colors, depending on the height, for transmission to the texture
    private Color[] GenerateColorMap(float[] noiseMap)
    {
        Color[] colorMap = new Color[noiseMap.Length];
        for (int i = 0; i < noiseMap.Length; i++)
        {
            // Base color with the highest value range
            colorMap[i] = terrainLevel[terrainLevel.Count - 1].color;
            foreach (var level in terrainLevel)
            {
                // If the noise falls into a lower range, then use it
                if (noiseMap[i] < level.height)
                {
                    colorMap[i] = level.color;
                    break;
                }
            }
        }

        return colorMap;
    }
}