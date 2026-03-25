Shader "HoleShader/hole"
{   
    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline"  "Queue" = "Geometry+1"}
        
        ColorMask 0
        ZWrite On
        
        Pass{}      
        
    }
}
