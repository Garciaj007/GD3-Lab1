Shader "Custom/ImageSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		[HDR] _Emission ("Emission", color) = (0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry"}

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        
		fixed4 _Color;
		float4 _MainTex_ST;

        half _Glossiness;
        half _Metallic;
		half3 _Emission;

        struct Input
        {
            float2 uv_MainTex;
			float4 screenPos;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 texCoord = IN.screenPos.xy / IN.screenPos.w;
			texCoord.x *= _ScreenParams.x / _ScreenParams.y;
			texCoord = TRANSFORM_TEX(texCoord, _MainTex);

            fixed4 c = tex2D (_MainTex, texCoord) * _Color;
            o.Albedo = c.rgb;
			o.Emission = _Emission;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Standard"
}
