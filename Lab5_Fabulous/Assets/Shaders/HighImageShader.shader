Shader "Hidden/HighImageShader"
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
			uniform float _Blend;
			uniform float _Intensity;
			uniform float _Brightness; 

			float3 hue2rgb(float hue)
			{
				hue = frac(hue);
				float r = abs(hue * 6 - 3) - 1;
				float g = 2 - abs(hue * 6 - 2);
				float b = 2 - abs(hue * 6 - 4);
				float3 rgb = float3(r,g,b);
				return saturate(rgb);
			}

			float3 hsv2rgb(float3 hsv)
			{
				float3 rgb = hue2rgb(hsv.x);
				rgb = lerp(1, rgb, hsv.y);
				return rgb * hsv.z;
			}

			float3 rgb2hsv(float3 rgb)
			{
				float maxC = max(rgb.r, max(rgb.g, rgb.b));
				float minC = min(rgb.r, min(rgb.g, rgb.b));
				float diff = maxC - minC;
				float hue = 0;

				if(maxC == rgb.r)
					hue = 0 + (rgb.g - rgb.b) / diff;
				else if (maxC == rgb.g)
					hue = 2 + (rgb.b - rgb.r) / diff;
				else if (maxC == rgb.b)
					hue = 4 + (rgb.r - rgb.b) / diff;

				hue = frac(hue / 6);
				float sat = diff / maxC;
				float val = maxC;
				return float3(hue, sat, val);
			}

			float4 Frag(VaryingsDefault i) : SV_Target
			{
				//float coordY = i.texcoord.y + (_Power * _CosTime);
				//float coordX = i.texcoord.x + (_Power * _SinTime);
				float4 color = tex2D(_MainTex, i.texcoord);
				
				float nIterations = 4.0;

				for(int j = 1; j < nIterations; ++j)
				{
					float offsetX = i.texcoord.x * _SinTime.z * (_Power / 500.) / (float(j)/float(nIterations - 1) - 0.5);
					float offsetY = i.texcoord.y * _CosTime.z * (_Power / 500.) / (float(j)/float(nIterations - 1) - 0.5);
					color += lerp(tex2D(_MainTex, i.texcoord + float2(offsetX, offsetY)), color, _Blend);
				}
				color /= nIterations;

				float3 hsv = rgb2hsv(color);
				hsv.x += i.texcoord.x + _Time.x;
				hsv.z = _Brightness;
				color = float4(lerp(color.rgb, hsv2rgb(hsv), _Intensity), 1.0f);

				//color = saturate(color);

				return color;
			}

            ENDHLSL
        }
    }
}
