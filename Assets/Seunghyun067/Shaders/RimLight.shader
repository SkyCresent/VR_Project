Shader "SH_Shader/RimLight"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "White" {}
        _BumpTex("Normal Texture", 2D) = "bump" {}
        _RimPower("RimPower", Range(1, 10))=5
        [HDR] _RimColor("RimColor", Color)=(1,1,1,1)
        _RimGo("RimEnable", Range(0, 1))=0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 200

        CGPROGRAM
        
        #pragma surface surf Lambert
        #pragma target 3.0

        sampler2D _MainTex;
        float _RimPower;
        float4 _RimColor;
        float _RimGo;
        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            float rim = saturate(dot(o.Normal, IN.viewDir)); // 노말, 카메라 내적           
            
            o.Emission = pow(1 - rim, _RimPower) * _RimColor.rgb * _RimGo;
            o.Alpha= 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
