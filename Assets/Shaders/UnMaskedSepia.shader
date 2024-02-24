Shader "Unlit/UnMaskedSepia"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Saturation ("Saturation", Range(-100, 100)) = 0
        _Color ("Color", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _Width ("Width", Range(0, 10)) = 0.01
        
    }
    SubShader
    {
        Tags { "RenderType"="Geometry" "Queue"= "Geometry"}
        LOD 100
        Pass
        {
            Cull Off
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
        Pass
        {
            Stencil{
                Ref 2
                Comp NotEqual
                Pass Keep
            }
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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }

        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent"}
        Pass
        {
            Stencil{
                Ref 2
                Comp Equal
                Pass Keep
            }
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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Saturation;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            void SepiaEffect(in fixed3 In, out fixed3 Out){
                Out.r = dot(In, fixed3(0.393, 0.769, 0.189));
                Out.g = dot(In, fixed3(0.349, 0.686, 0.168));
                Out.b = dot(In, fixed3(0.272, 0.534, 0.131));
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv)*_Color;
                fixed4 new_col = tex2D(_MainTex, i.uv);
                SepiaEffect(col.rgb,new_col.rgb);
                UNITY_APPLY_FOG(i.fogCoord, new_col);
                return new_col;
            }
            ENDCG
        }
    }
}
