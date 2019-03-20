Shader "Custom/Barrier"
{

	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_SecondColor("Second Color", Color) = (1,1,1,1)
		_SecondTex("Second Texture", 2D) = "white" {}
		_Scale("Curva", Range (-5, 5)) = 0
		_Speed("Tex Speed", Range(-10, 10)) = 0
		_Alpha("Alpha", Range(0, 1)) = 1
	}
		SubShader
	{
		Tags{"Queue" = "Transparent"}


		CGPROGRAM
			#pragma surface surf Lambert vertex:vert alpha

			float4 _Color;
			sampler2D _MainTex;
			float4 _SecondColor;
			sampler2D _SecondTex;
			float _Scale;
			float _Speed;
			float _Alpha;

			struct Input
			{
				float2 uv_MainTex;
			};
			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};

			void vert(inout appdata v, out Input o) {
				UNITY_INITIALIZE_OUTPUT(Input, o);
				float PI = 3.14159265359;
				float x = sin(v.vertex.x * PI / 10 + PI/2);
				v.vertex.y += x * _Scale;
			}

			void surf(Input IN, inout SurfaceOutput o)
			{
				float texX = IN.uv_MainTex.x + _Time * -_Speed;
				float texY = IN.uv_MainTex.y;
				float2 tex = float2(texX, texY);
				float3 c = tex2D(_MainTex, tex) * _Color.rgb;

				float tex2X = IN.uv_MainTex.x + _Time * -_Speed / 3;
				float tex2Y = IN.uv_MainTex.y + .5;
				float2 tex2 = float2(tex2X, tex2Y);
				float3 c2 = tex2D(_SecondTex, tex2) * _SecondColor.rgb;

				o.Albedo = c.rgb * c2.rgb;
				o.Alpha = _Alpha;
			}
		ENDCG
	}
		FallBack "Diffuse"
}