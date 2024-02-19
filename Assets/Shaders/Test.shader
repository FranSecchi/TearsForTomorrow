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
        _Width ("Width", Range(0, 10)) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull Off
        Pass
        {
            Tags{ "RenderType"="Transparent" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"


            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal: NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 vertex_world : TEXCOORD2;
                float3 normal_world: TEXCOORD1;
            };
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _OutlineColor;
            float _Width;

            v2f vert (appdata v)
            {
                v2f o;
                v.vertex += v.vertex * _Width;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.normal_world = UnityObjectToWorldNormal(v.normal);
                o.vertex_world = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                UNITY_APPLY_FOG(i.fogCoord, col);
                fixed4 col = tex2D(_MainTex, i.uv);
                float3 normal = i.normal_world;
                float3 viewDir = normalize(_WorldSpaceCameraPos-i.vertex_world);
                float calculus = dot(viewDir, normal);
                if(calculus> 0)
                    discard;
                return col*_OutlineColor;
            }
            ENDCG
        }

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
