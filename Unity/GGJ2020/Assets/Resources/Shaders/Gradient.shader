Shader "Unlit/Gradient"
{
    Properties
    {
        _color ("Color A", COLOR) = (1,1,1,1)
        _color2 ("Color B", COLOR) = (1,1,1,1)
        _scale ("Scale", FLOAT) = 1
        _offset ("Offset", FLOAT) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "DisableBatching"="True" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            fixed4 _color;
            fixed4 _color2;
            float _scale;
            float _offset;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.y * _scale + _offset;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = lerp (_color, _color2, saturate(i.uv));
                return col;
            }
            ENDCG
        }
    }
}
