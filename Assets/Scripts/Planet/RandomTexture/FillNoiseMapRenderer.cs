using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillNoiseMapRenderer : MonoBehaviour
{
    [SerializeField] private Vector2 _heightRange;
    [SerializeField] private ColorGradientConfig _colorGradientConfig;

    private NoiseMapRenderer _noiseMapRenderer;

    private void Awake()
    {
        _noiseMapRenderer = GetComponent<NoiseMapRenderer>();
        SetUpNoiseMapRenderer(_noiseMapRenderer);
    }

    public void SetUpNoiseMapRenderer(NoiseMapRenderer noiseMapRenderer)
    {
        int index = Random.Range(0, _colorGradientConfig.GradientPalettesArray.Length - 1);
        ColorGradientConfig.GradientPalette bufGradientPalette = _colorGradientConfig.GradientPalettesArray[index];

        for (int i = 0; i < bufGradientPalette.MutchGradientsArray.Length; i++)
        {
            NoiseMapRenderer.TerrainLevel terrainLevel = new NoiseMapRenderer.TerrainLevel()
            {
                color = bufGradientPalette.MutchGradientsArray[i].Evaluate(Random.Range(0f, 1f)),
                height = Random.Range(_heightRange.x, _heightRange.y)
            };

            noiseMapRenderer.terrainLevel.Add(terrainLevel);
        };
    }
}

