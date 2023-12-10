Shader "Custom/dirtykitchenfloor"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _DirtTex ("Dirt Texture", 2D) = "brown" { }
        _DirtStrength ("Dirt Strength", Range (0, 1)) = 0.1
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _DirtTex;
        fixed _DirtStrength;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Sample the base texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            // Sample the dirt texture
            fixed4 dirt = tex2D(_DirtTex, IN.uv_MainTex);

            // Mix the dirt texture with the base texture based on dirt strength
            c.rgb = lerp(c.rgb, dirt.rgb, _DirtStrength);

            // Assign the final color to the output
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
