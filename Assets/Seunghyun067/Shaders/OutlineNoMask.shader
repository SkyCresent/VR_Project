Shader "SH_Shader/OutlineShader"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_BumpTex(" Normal Texture", 2D) = "Bump" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Ref("Stencil Ref", int) = 2

		[HDR] _OutlineColor("OutlineColor", Color) = (1, 1, 1, 1)
		_Outline("Outline", Range(0, 0.01)) = 0.01
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }

		Cull back
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

		sampler2D _MainTex;
		sampler2D _BumpTex;

		
		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpTex;
		};
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		int _Ref;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Normal = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
			o.Albedo = c.rgb;

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG

		Cull front		
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
			if (_Outline <= 0) discard;

			return _OutlineColor;
		}
		ENDCG

		
	}
	FallBack "Diffuse"
}