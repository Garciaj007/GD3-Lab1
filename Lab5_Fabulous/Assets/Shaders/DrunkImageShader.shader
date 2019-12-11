Shader "Hidden/DrunkImageShader"
{
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM
            #pragma vertex VertDefault
            #pragma fragment Frag
            #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

            uniform sampler2D _MainTex;
			uniform float _Power;
			uniform float3 _Direction;

			float4 Frag(VaryingsDefault i) : SV_Target
			{
				float4 color = tex2D(_MainTex, i.texcoord);
				
				float nIterations = 4.0;

				for(int j = 1; j < nIterations; ++j)
				{
					float offsetX = _Direction.x * _SinTime.z * (_Power / 500.) / (float(j)/float(nIterations - 1) - 0.5);
					float offsetY = _Direction.y * _CosTime.z * (_Power / 500.) / (float(j)/float(nIterations - 1) - 0.5);
					color += tex2D(_MainTex, i.texcoord + float2(offsetX, offsetY));
				}
				color /= nIterations;

				return color;
			}

            ENDHLSL
        }
    }
}
