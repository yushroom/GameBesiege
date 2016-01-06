Shader "Advanced SS/Standard/Specular Rim" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Shininess ("Shininess", Range(0.01,1)) = 0.078125
 _RimColor ("Rim Color", Color) = (0.75,0.75,0.75,0)
 _RimPower ("Rim Power", Range(0.5,8)) = 3
 _MainTex ("Texture", 2D) = "white" {}
}
SubShader { 
 LOD 500
 Tags { "QUEUE"="Geometry" "RenderType"="Opaque" }
 Pass {
  Tags { "QUEUE"="Geometry" "RenderType"="Opaque" }
 }
}
Fallback "Specular"
}