using System;
using UnityEngine;

public class PerlinNoiseGeneratorSystem : INoiseGenerator
{
    private const float DefaultScale = 1.0f;
    
    private int _pixWidth;
    private int _pixHeight;

    private float _xOrg;
    private float _yOrg;

    private float _scale = DefaultScale;

    private Texture2D _noiseTex;
    private Color[] _Pixels;

    public PerlinNoiseGeneratorSystem(int PixWidht, int PixHeight, float XOrg, float YOrg, float Scale)
    {
        _pixHeight = PixHeight;
        _pixWidth = PixWidht;
        _xOrg = XOrg;
        _yOrg = YOrg;
        _scale = Scale;
    }
    
    public Texture2D GenerateNoiseTexture()
    {
        _noiseTex = new Texture2D(_pixWidth, _pixHeight);
        _Pixels = new Color[_noiseTex.width * _noiseTex.height];
        float y = 0;

        int Width = _noiseTex.width;
        
        while (y < _noiseTex.height) {
            float x = 0;
            while (x < _noiseTex.width) {
                float xCoord = _xOrg + x / _noiseTex.width * _scale;
                float yCoord = _yOrg + y / _noiseTex.height * _scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                
                int fixy = Convert.ToInt32(y);
                int fixx = Convert.ToInt32(x);
                _Pixels[fixy * _noiseTex.width + fixx] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }
        _noiseTex.SetPixels(_Pixels);
        _noiseTex.Apply();

        return _noiseTex;
    }
}
