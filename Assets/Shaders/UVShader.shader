Shader "UVShader"
{
    Properties
    {
        _BaseMap("Albedo (RGB)", 2D) = "white" {}
        _BaseColor("Color", Color) = (1,1,1,1)
        _LightPosition("Light Position", Vector) = (0,0,0,0)
        _LightDirection("Light Direction", Vector) = (0,0,1,0)
        _LightAngle("Light Angle", Range(0,180)) = 45
        _StrengthScalor("Strength", Float) = 50
        _GlowColor("Glow Color", Color) = (0.6, 0, 1, 1)
        _GlowIntensity("Glow Intensity", Range(0, 2)) = 1.0
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        LOD 100

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 positionWS : TEXCOORD1;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                float4 _BaseColor;
                float3 _LightPosition;
                float3 _LightDirection;
                float _LightAngle;
                float _StrengthScalor;
                float4 _GlowColor;
                float _GlowIntensity;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                OUT.positionWS = TransformObjectToWorld(IN.positionOS.xyz);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float3 lightDir = normalize(_LightPosition - IN.positionWS);
                float scale = dot(lightDir, normalize(_LightDirection));
                float halfAngleRad = radians(_LightAngle) * 0.5;
                float threshold = cos(halfAngleRad);
                float strength = scale - threshold;
                strength = saturate(strength * _StrengthScalor);

                half4 albedo = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv) * _BaseColor;
                half4 glow = _GlowColor * _GlowIntensity;

                half4 finalColor = albedo * glow * strength;
                finalColor.a = albedo.a * strength;

                return finalColor;
            }
            ENDHLSL
        }
    }
}