using System;
using UnityEngine;

public class NoiseTextureUnit : MonoBehaviour
{
    [field: SerializeField] public int PixelsWidht { get; private set; }
    [field: SerializeField] public int PixelsHeight { get; private set; }
    
    [field: SerializeField] public int Xorg { get; private set; }
    [field: SerializeField] public int Yorg { get; private set; }
    
    [field: SerializeField] public int Scale { get; private set; }
    
    private INoiseGenerator _noiseGenSystem;
    private Renderer _renderer;
    
    
    private void OnValidate()
    {
        _renderer = GetComponent<Renderer>();
    }

    [ContextMenu("GenerateNewNoiseTexture")]
    private void NewNoiseTexture()
    {
        _noiseGenSystem = new PerlinNoiseGeneratorSystem(PixelsWidht, PixelsHeight, Xorg, Yorg, Scale);
        _renderer.material.mainTexture = _noiseGenSystem.GenerateNoiseTexture();
    }
}
