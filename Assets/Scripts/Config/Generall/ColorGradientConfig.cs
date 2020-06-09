using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorGradientConfig", menuName = "ScriptableObjects/ColorGradientConfig")]
public class ColorGradientConfig : ScriptableObject
{
    [System.Serializable]
    public class GradientPalette
    {
        [SerializeField]private Gradient[] _mutchGradientsArray;
        public Gradient[] MutchGradientsArray => _mutchGradientsArray;
    }

    [SerializeField] private GradientPalette[] _gradientPalettesArray;
    public GradientPalette[] GradientPalettesArray => _gradientPalettesArray;

}
