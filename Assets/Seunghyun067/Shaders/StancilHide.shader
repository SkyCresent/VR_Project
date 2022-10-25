Shader "SH_Shader/StancilHide"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_Cutoff("Cutout", Range(0,1)) = 0.5
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		ZWrite On
		Stencil
		{
			Ref 2
			comp always
			pass replace
		}

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows alpha:blend

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{			
			
		}
		ENDCG
		ZWrite Off
		Cull back
		Stencil
		{
			Ref 2
			Comp NotEqual // 패스 1에서 렌더링 성공한 부분에는 그리지 않도록 한다
		}

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows alpha:blend

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input In, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, In.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}