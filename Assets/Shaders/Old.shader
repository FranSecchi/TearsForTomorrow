Shader "Unlit/UnMasked"
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
        LOD 100
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
            void Unity_Saturation_float(float3 In, float Saturation, out float3 Out)
            {
                float luma = dot(In, float3(0.2126729, 0.7151522, 0.0721750));
                Out =  luma.xxx + Saturation.xxx * (In - luma.xxx);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv)*_Color;
                fixed4 new_col = tex2D(_MainTex, i.uv);
                Unity_Saturation_float(col.rgb,_Saturation,new_col.rgb);
                UNITY_APPLY_FOG(i.fogCoord, new_col);
                return new_col;
            }
            ENDCG
        }
    }
}
