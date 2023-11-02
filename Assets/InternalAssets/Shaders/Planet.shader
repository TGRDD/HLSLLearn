Shader "Space/Procedure/Earth"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _WaterColor("Water Color", Color) = (0, 0, 1, 1)
        _SandColor("Sand Color", Color) = (1, 0.92, 0.55, 1)
        _GrassColor("Grass Color", Color) = (0.29, 0.48, 0.22, 1)
        _RockColor("Rock Color", Color) = (0.53, 0.53, 0.53, 1)
        
        _OceanLevel("Ocean Level", Range(1, 5)) = 2
        
        _Saturation("Saturatuon", Range(0, 3)) = 1
        _Test("Test", Float) = 0
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct appdata members noise)

        #pragma surface surf Lambert
        #pragma vertex vert 

        sampler2D _MainTex;
        fixed4 _WaterColor;
        fixed4 _SandColor;
        fixed4 _GrassColor;
        fixed4 _RockColor;
        half _Saturation;
        half _OceanLevel;
        float _Test;

        struct Input
        {
            float2 uv_MainTex;
        };
        

        void vert(inout appdata_full v)
        {
            
            //Умножение нормали на коэффициент масштабирования
            float3 scaledNormal = normalize(v.normal) * _Test;
    
            // Добавление результатов к позиции вершины
            v.vertex.xyz += scaledNormal;

            //v.texcoord.y += _Time.y;
            
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Генерация шума Перлина
            float noise = tex2D(_MainTex, IN.uv_MainTex).b;

            float2 uv = IN.uv_MainTex;
           // uv.y += sin(uv.y * 6.5 * _Time.y);
            fixed4 c = tex2D(_MainTex, uv);
            
            
            // Определение высоты по шуму
            float height = noise * (5 - _OceanLevel) - 1;

            // Присваивание цвета в зависимости от высоты
            
            float4 currentcollor;
            if (height <= 0.0)
            {
                currentcollor = _WaterColor;
            }
            else if (height <= 0.2)
            {
                currentcollor = _SandColor;
            }
            else if (height <= 0.6)
            {
                currentcollor = _GrassColor;
            }
            else
            {
                currentcollor = _RockColor;
            }


            
            o.Albedo = c.rgb * currentcollor.rgb;
            o.Alpha = c.a * currentcollor.a;

            
            o.Albedo *= _Saturation;
            
            // Высота вертексов в зависимости от значения шума
            o.Normal = float3(0, 0, height);
        }
        ENDCG
    }

    FallBack "Diffuse"
}