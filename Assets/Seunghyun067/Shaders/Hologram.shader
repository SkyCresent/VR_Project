Shader "SH_Shader/Hologram"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("BumpMap", 2D) = "bump" {}
       [HDR] _RimColor("RimColor", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}

        CGPROGRAM
        #pragma surface surf Lambert noambient alpha:fade


        sampler2D _MainTex;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float3 viewDir;
            float3 worldPos;
        };

        float4 _RimColor;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            o.Emission = _RimColor.rgb;
            float rim = saturate(dot(o.Normal, IN.viewDir));
            rim = pow(1 - rim, 3) + pow(frac(IN.worldPos.y * 10 - _Time.y), 30);
            o.Alpha = rim;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
