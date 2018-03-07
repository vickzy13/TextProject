Shader "Unlit/MyShader"
{
Properties
{
_Color("Color", Color) =(1,1,1,1)
_MainTex ("Texture", 2D) = "white" {}
_Mytexture ("Texture", 2D) = "white" {}
_X("X",Float) = 0
_Y("Y",Float) = 1.0
}
SubShader
{

Pass{
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct appdata
{
float4 vertex : POSITION;
float2 uv : TEXCOORD0;
};

struct v2f
{
float2 uv : TEXCOORD0;
float4 vertex : SV_POSITION;
float2 val:TEXCOORD1;
};

sampler2D _MainTex;
float4 _Color;
float _X;
float _Y;

v2f vert (appdata v)
{
v2f o;
o.val.x = abs(_X * sin(v.vertex.x + v.vertex.z+_Time.y));
o.vertex = UnityObjectToClipPos(v.vertex+o.val.x);

return o;
}

float4 frag (v2f i) : COLOR
{
float4 col = abs(i.val.x)*_Color;

return col;
}
ENDCG
}
}
}
