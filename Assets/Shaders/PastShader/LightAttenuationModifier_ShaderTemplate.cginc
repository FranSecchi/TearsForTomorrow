//half4 fragForwardBaseInternal(VertexOutputForwardBase i)
//{
//    UNITY_APPLY_DITHER_CROSSFADE(i.pos.xy);
//
//    FRAGMENT_SETUP(s)
//
//        UNITY_SETUP_INSTANCE_ID(i);
//    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
//
//    UnityLight mainLight = MainLight();
//    UNITY_LIGHT_ATTENUATION(atten, i, s.posWorld);

//    ^^^ code just before this include

// ---------------------------------------
// CUSTOM code for attenuation goes here

// Make everything a 25% darker
atten *= 0.75;





// ---------------------------------------