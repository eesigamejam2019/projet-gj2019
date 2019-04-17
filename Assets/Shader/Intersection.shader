// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Intersection"
{
	Properties
	{
	   _MainColor("Main Color",Color) = (0,0,0,0)
	   _GlowColor("Glow Color",Color) = (1,1,1,1)
		_IntersectColor("InstersectColor",Color) = (1,1,1,1)
		_FadeSize("fade size", range(0,100)) = 10
		_Fade("fade", range(0,1)) = 1
	}
		SubShader
	{
	
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite off
		Cull off
		Tags { "RenderType" = "Transparent"
		"Queue" = "Transparent" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

		struct v2f
		{

			float4 vertex : SV_POSITION;
			float2 screenuv : TEXCOORD0;
			float2 depth : TEXCOORD1;
			float3 viewDir : TEXCOORD2;
			float4 worldPos : TEXCOORD3;
			float3 normal : NORMAL;
		};

			fixed4 _MainColor;
			fixed4 _GlowColor;
			fixed4 _IntersectColor;
			float _FadeSize;
			sampler2D _CameraDepthNormalsTexture;
			sampler2D _CameraDepthTexture;
			float _Fade;
			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenuv = ((o.vertex.xy / o.vertex.w) + 1) / 2;
				o.screenuv.y = 1 - o.screenuv.y;
				o.depth = -mul(UNITY_MATRIX_MV, v.vertex).z * _ProjectionParams.w;
				o.viewDir = ObjSpaceViewDir(v.vertex);;
				o.normal = v.normal;
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				return o;
			}

			float rand(float3 myVector) {
				return frac(sin(dot(myVector, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float2 screenuv = i.vertex.xy / _ScreenParams.xy;
				float screenDepth = Linear01Depth(tex2D(_CameraDepthTexture, i.screenuv));

				float scale = length(float3(unity_ObjectToWorld[0].x, unity_ObjectToWorld[1].x, unity_ObjectToWorld[2].x));

				float diff = screenDepth - i.depth;
				float intersect = 0;
				float3 worldPos = mul(unity_ObjectToWorld, i.vertex).xyz;
			
				float camDist = distance(i.worldPos, _WorldSpaceCameraPos);

				if (diff > 0)
					intersect = 1 - smoothstep(0, _ProjectionParams.w * scale / 2, diff * _FadeSize);

				//float d = 1-abs(dot(i.normal, normalize(i.viewDir)))*2;
				//return fixed4(0,0,0, d);
				//float glow = max(intersect, rim);
				//if (abs(d) >= 0.9)
				//	return fixed4(1,1,1,0.5);
				
				fixed4 col = (0, 0, 0, 0);
				float d = dot(i.normal, normalize(i.viewDir));
				if (d < 0)
					col = fixed4(_GlowColor.r, _GlowColor.g, _GlowColor.b, clamp(pow(d, 2), 0, 1)) * _GlowColor.a;
					//lerp(fixed4(_GlowColor.r, _GlowColor.g, _GlowColor.b,0), _GlowColor, clamp(pow(d,4),0,1));

				
				col = lerp(_MainColor, _IntersectColor, intersect)/* * _MainColor.a + intersect;*/;
				return col;
				float dist = clamp(pow(camDist,1.1)-pow(2,1.1), 0, 1);
				col.a *= dist;
				col.a *= _Fade;
				//fixed4 gradient = fixed4(lerp(_MainColor.rgb, _GlowColor.rgb, clamp(pow(intersect, 4),0,1)), _MainColor.a);
				//fixed4 col = gradient * _MainColor.a + intersect;
				return col;
			}


			ENDCG
		}
	}
}
