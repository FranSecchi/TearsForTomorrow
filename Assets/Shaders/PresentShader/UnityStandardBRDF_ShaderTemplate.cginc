#ifndef UnityStandardBRDF_ShaderTemplateH
#define UnityStandardBRDF_ShaderTemplateH

void SepiaEffect(in fixed3 In, out fixed3 Out){
    Out.r = dot(In, fixed3(0.393, 0.769, 0.189));
    Out.g = dot(In, fixed3(0.349, 0.686, 0.168));
    Out.b = dot(In, fixed3(0.272, 0.534, 0.131));
}

half4 BRDF3_Unity_PBS_ShaderTemplate(half3 diffColor, half3 specColor, half oneMinusReflectivity, half smoothness,
    float3 normal, float3 viewDir,
    UnityLight light, UnityIndirect gi)
{
    float3 reflDir = reflect(viewDir, normal);

    half nl = saturate(dot(normal, light.dir));
    half nv = saturate(dot(normal, viewDir));

    // Vectorize Pow4 to save instructions
    half2 rlPow4AndFresnelTerm = Pow4(float2(dot(reflDir, light.dir), 1 - nv));  // use R.L instead of N.H to save couple of instructions
    half rlPow4 = rlPow4AndFresnelTerm.x; // power exponent must match kHorizontalWarpExp in NHxRoughness() function in GeneratedTextures.cpp
    half fresnelTerm = rlPow4AndFresnelTerm.y;

    half grazingTerm = saturate(smoothness + (1 - oneMinusReflectivity));

    half3 color = BRDF3_Direct(diffColor, specColor, rlPow4, smoothness);
    color *= light.color * nl;
    color += BRDF3_Indirect(diffColor, specColor, gi, grazingTerm, fresnelTerm);

    half3 new_color = color;
    // ShaderTemplate
    // Make the color red by default to illustate that the template is working
    SepiaEffect(color,new_color);

    return half4(new_color, 1);
}

#endif