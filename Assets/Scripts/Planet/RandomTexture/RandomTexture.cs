using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexture : MonoBehaviour
{
    [SerializeField]private int _pixWidth;
    [SerializeField] private int _pixHeight;
    [SerializeField] private float _xOrg;
    [SerializeField] private float _yOrg;
    [SerializeField] private float _scale = 1.0F;

    private Texture2D _noiseTex;
    private Color[] _pix;
    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();

        // Set up the texture and a Color array to hold pixels during processing.
        _noiseTex = new Texture2D(_pixWidth, _pixHeight);
        _pix = new Color[_noiseTex.width * _noiseTex.height];
        _rend.material.mainTexture = _noiseTex;
    }

    void CalcNoise()
    {
        // For each pixel in the texture...
        float y = 0.0F;

        while (y < _noiseTex.height)
        {
            float x = 0.0F;
            while (x < _noiseTex.width)
            {
                float xCoord = _xOrg + x / _noiseTex.width * _scale;
                float yCoord = _yOrg + y / _noiseTex.height * _scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                _pix[(int)y * _noiseTex.width + (int)x] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }

        // Copy the pixel data to the texture and load it into the GPU.
        _noiseTex.SetPixels(_pix);
        _noiseTex.Apply();
    }

    void Update()
    {
        CalcNoise();
    }
}
