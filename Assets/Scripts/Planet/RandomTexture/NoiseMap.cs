using UnityEngine;

public enum MapType
{
    Noise,
    Color
}

public class NoiseMap : MonoBehaviour
{
    [SerializeField] private NoiseMapRenderer _mapRenderer;
    // Input data for our noise generator
    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] public float scale;

    [SerializeField] public int octaves;
    [SerializeField] public float persistence;
    [SerializeField] public float lacunarity;

    [SerializeField] public Vector2 offset;

    [SerializeField] public MapType type = MapType.Noise;

    private NoiseMapGenerator _noiseMapGenerator;

    private void Start()
    {
        _noiseMapGenerator = new NoiseMapGenerator();
        GenerateMap();
    }

    public void GenerateMap()
    {
        // Generate a map
        float[] noiseMap = _noiseMapGenerator.GenerateNoiseMap(width, height, scale, octaves, persistence, lacunarity, offset);

        // Pass the map to the renderer
        _mapRenderer.RenderMap(width, height, noiseMap, type);
    }
}