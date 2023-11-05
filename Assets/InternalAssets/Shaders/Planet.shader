Shader "Space/Procedure/Earth"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _WaterColor("Water Color", Color) = (0, 0, 1, 1)
        _SandColor("Sand Color", Color) = (1, 0.92, 0.55, 1)
        _GrassColor("Grass Color", Color) = (0.29, 0.48, 0.22, 1)
        _RockColor("Rock Color", Color) = (0.53, 0.53, 0.53, 1)
        
        
        _MountainHeight("Mountain Height", Float) = 100
        _OceanLevel("Ocean Level", Range(1, 5)) = 2
        
        _Saturation("Saturatuon", Range(0, 30)) = 1
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
        float _MountainHeight;

        struct Input
        {
            float2 uv_MainTex;
        };
        

        void vert(inout  appdata_full v)
        {
            float2 uv = v.texcoord;
            float4 noise = tex2Dlod (_MainTex, float4(v.texcoord.xy,0,0));

             float height = noise * (5 - _OceanLevel) - 1;
            
            float3 scaledNormal = normalize(v.normal);
        
            if (noise.y < 0.8)
            {
                v.vertex.xyz += scaledNormal * height * _Test;
            }
            else
            {
                v.vertex.xyz += scaledNormal * height * _MountainHeight  * _Test;
            }
            
        }

        void surf(Input IN,  inout SurfaceOutput o)
        {
            // ��������� ���� �������
            float noise = tex2D(_MainTex, IN.uv_MainTex).b;

            float2 uv = IN.uv_MainTex;
           // uv.y += sin(uv.y * 6.5 * _Time.y);
            fixed4 c = tex2D(_MainTex, uv);
            
            
            // ����������� ������ �� ����
            float height = noise * (5 - _OceanLevel) - 1;

            // ������������ ����� � ����������� �� ������
            
            float4 currentcollor;
            if (height <= 0.0)
            {
                currentcollor = _WaterColor;
                
            }
            else if (height <= 0.1)
            {
                currentcollor = _SandColor;
            }
            else if (height <= 0.6)
            {
                currentcollor = _GrassColor;
            }
            else if (height <= 1.1)
            {
                currentcollor = _RockColor;
            }
            else
            {
                currentcollor = 0.6;
            }

            
            
            o.Albedo = c.rgb * currentcollor.rgb; //CHANGE THIS
            o.Alpha = c.a * currentcollor.a;

            
            o.Albedo *= _Saturation;
            
            // ������ ��������� � ����������� �� �������� ����
            o.Normal = float3(0, 0, height);
        }
        ENDCG
    }

    FallBack "Diffuse"
}