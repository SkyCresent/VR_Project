Shader "SH_Shader/CullFront"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		Cull Front
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

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