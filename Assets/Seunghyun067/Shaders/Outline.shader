Shader "SH_Shader/OutlineShader"
{
	Properties
	{
		[HDR] _OutlineColor("OutlineColor", Color) = (1, 1, 1, 1)
		_Outline("Outline", Range(0, 0.01)) = 0.01
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		Cull front

		Stencil {
                Comp always
            }

		// Pass1
		CGPROGRAM
		#pragma surface surf NoLighting vertex:vert noshadow noambient

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		fixed4 _OutlineColor;
		float _Outline;

		void vert(inout appdata_full v)
		{
			v.vertex.xyz += v.normal.xyz * _Outline;
		}

		void surf(Input In, inout SurfaceOutput o)
		{
		}

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			return _OutlineColor;
		}
		ENDCG
	}
	FallBack "Diffuse"
}