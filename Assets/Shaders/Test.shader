Shader "Custom/Test"
{
    Properties
    {
        [Header(Base Parameters)]
        _Color ("Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        [HDR] _Emission ("Emission", color) = (0 ,0 ,0 , 1)
    
        [Header(Lighting Parameters)]
        _ShadowTint ("Shadow Color", Color) = (0, 0, 0, 1)

        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _Width ("Width", Range(0, 1)) = 0.03
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Stepped fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };
        fixed4 _Color;
        float3 _ShadowTint;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
        
        float4 LightingStepped(SurfaceOutput s, float3 lightDir, half3 viewDir, float shadowAttenuation){
            float towardsLight = dot(s.Normal, lightDir);
            float towardsLightChange = fwidth(towardsLight);
            float lightIntensity = smoothstep(0, towardsLightChange, towardsLight);
            
            #ifdef USING_DIRECTIONAL_LIGHT
                float attenuationChange = fwidth(shadowAttenuation) * 0.5;
                float shadow = smoothstep(0.5 - attenuationChange, 0.5 + attenuationChange, shadowAttenuation);
            #else
                float attenuationChange = fwidth(shadowAttenuation);
                float shadow = smoothstep(0, attenuationChange, shadowAttenuation);
            #endif
                lightIntensity = lightIntensity * shadow;
                
                float3 shadowColor = s.Albedo * _ShadowTint;
                float4 color;
                color.rgb = lerp(shadowColor, s.Albedo, lightIntensity) * _LightColor0.rgb;
                color.a = s.Alpha;
                return color;
        }
        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
        }
        ENDCG
    }
    FallBack "Diffuse"
}
