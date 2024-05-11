
Shader "KHAZAD/SKY"
{
	Properties
	{
		[StyledBanner(Khazad Room Sky)]_Banner("< Banner >", Float) = 1
		[StyledCategory(Background Settings, 5, 10)]_BackgroundCat("[ Background Cat ]", Float) = 1
		[KeywordEnum(Colors,Cubemap,Combined)] _BackgroundMode("Background Mode", Float) = 0
		[Space(10)]_SkyColor("Sky Color", Color) = (0.4980392,0.7450981,1,1)
		_EquatorColor("Equator Color", Color) = (1,0.747,0,1)
		_GroundColor("Ground Color", Color) = (0.4980392,0.497,0,1)
		_EquatorHeight("Equator Height", Range( 0 , 1)) = 0.5
		_EquatorSmoothness("Equator Smoothness", Range( 0.01 , 1)) = 0.5
		[StyledSpace(10)]_BackgroundCubemapSpace("BackgroundCubemapSpace", Float) = 0
		[NoScaleOffset]_BackgroundCubemap("Background Cubemap", CUBE) = "black" {}
		_BackgroundExposure("Background Exposure", Range( 0 , 8)) = 1
		[StyledCategory(Pattern Settings)]_PatternCat("[ Pattern Cat ]", Float) = 1
		[Toggle(_ENABLEPATTERNOVERLAY_ON)] _EnablePatternOverlay("Enable Pattern Overlay", Float) = 0
		[NoScaleOffset]_PatternCubemap("Pattern Cubemap", CUBE) = "black" {}
		_PatternContrast("Pattern Contrast", Range( 0 , 2)) = 0.5
		[StyledCategory(Stars Settings)]_StarsCat("[ Stars Cat ]", Float) = 1
		[Toggle(_ENABLESTARS_ON)] _EnableStars("Enable Stars", Float) = 0
		[NoScaleOffset]_StarsCubemap("Stars Cubemap", CUBE) = "white" {}
		[IntRange]_StarsLayer("Stars Layers", Range( 1 , 3)) = 2
		_StarsSize("Stars Size", Range( 0 , 0.99)) = 0.5
		_StarsIntensity("Stars Intensity", Range( 0 , 5)) = 2
		_StarsSunMask("Stars Sun Mask", Range( 0 , 1)) = 0
		_StarsHeightMask("Stars Height Mask", Range( 0 , 1)) = 0
		[Space(10)][Toggle(_ENABLESTARSTWINKLING_ON)] _EnableStarsTwinkling("Enable Stars Twinkling", Float) = 0
		[NoScaleOffset]_TwinklingTexture("Twinkling Texture", 2D) = "white" {}
		_TwinklingContrast("Twinkling Contrast", Range( 0 , 2)) = 1
		_TwinklingSpeed("Twinkling Speed", Float) = 0.05
		[Space(10)][Toggle(_ENABLESTARSROTATION_ON)] _EnableStarsRotation("Enable Stars Rotation", Float) = 0
		[IntRange]_StarsRotation("Stars Rotation", Range( 0 , 360)) = 360
		_StarsRotationSpeed("Stars Rotation Speed", Float) = 0.5
		[StyledCategory(Sun Settings)]_SunCat("[ Sun Cat ]", Float) = 1
		[Toggle(_ENABLESUN_ON)] _EnableSun("Enable Sun", Float) = 0
		[NoScaleOffset]_SunTexture("Sun Texture", 2D) = "black" {}
		_SunColor("Sun Color", Color) = (1,1,1,1)
		_SunSize("Sun Size", Range( 0.1 , 1)) = 0.5
		_SunIntensity("Sun Intensity", Range( 1 , 10)) = 1
		[StyledCategory(Moon Settings)]_MoonCat("[ Moon Cat ]", Float) = 1
		[Toggle(_ENABLEMOON_ON)] _EnableMoon("Enable Moon", Float) = 0
		[NoScaleOffset]_MoonTexture("Moon Texture", 2D) = "black" {}
		_MoonColor("Moon Color", Color) = (1,1,1,1)
		_MoonSize("Moon Size", Range( 0.1 , 1)) = 0.5
		_MoonIntensity("Moon Intensity", Range( 1 , 10)) = 1
		[StyledCategory(Clouds Settings)]_CloudsCat("[ Clouds Cat ]", Float) = 1
		[Toggle(_ENABLECLOUDS_ON)] _EnableClouds("Enable Clouds", Float) = 0
		[NoScaleOffset]_CloudsCubemap("Clouds Cubemap", CUBE) = "black" {}
		_CloudsHeight("Clouds Height", Range( -0.5 , 0.5)) = 0
		_CloudsLightColor("Clouds Light Color", Color) = (1,1,1,1)
		_CloudsShadowColor("Clouds Shadow Color", Color) = (0.4980392,0.7450981,1,1)
		[Space(10)][Toggle(_CLOUDSLITBYSUN_ON)] _CloudsLitbySun("Clouds Lit by Sun", Float) = 0
		[Space(10)][Toggle(_ENABLECLOUDSROTATION_ON)] _EnableCloudsRotation("Enable Clouds Rotation", Float) = 0
		[IntRange]_CloudsRotation("Clouds Rotation", Range( 0 , 360)) = 360
		_CloudsRotationSpeed("Clouds Rotation Speed", Float) = 0.5
		[StyledCategory(Fog Settings)]_FogCat("[ Fog Cat ]", Float) = 1
		[Toggle(_ENABLEBUILTINFOG_ON)] _EnableBuiltinFog("Enable Fog", Float) = 0
		[StyledMessage(Info, The fog color is controlled by the fog color set in the Lighting panel., _EnableBuiltinFog, 1, 5, 5)]_EnableFogMessage("EnableFogMessage", Float) = 0
		_FogHeight("Fog Height", Range( 0 , 1)) = 0
		_FogSmoothness("Fog Smoothness", Range( 0.01 , 1)) = 0
		_FogFill("Fog Fill", Range( 0 , 1)) = 0
		[StyledCategory(Skybox Settings)]_SkyboxCat("[ Skybox Cat ]", Float) = 1
		_SkyboxRotation("Skybox Rotation", Range( 0 , 1)) = 0
		[ASEEnd]_SkyboxRotationAxis("Skybox Rotation Axis", Vector) = (0,1,0,0)

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Background" "Queue"="Background" "PreviewType"="Skybox" "IgnoreProjector"="True" }
	LOD 100

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend Off
		AlphaToMask Off
		Cull Off
		ColorMask RGBA
		ZWrite Off
		ZTest LEqual
		
		
		
		Pass
		{
			Name "Unlit"
			Tags { "LightMode"="ForwardBase" }
			CGPROGRAM

			

			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			//only defining to not throw compilation error over Unity 5.5
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			#include "UnityShaderVariables.cginc"
			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local _ENABLEBUILTINFOG_ON
			#pragma shader_feature_local _ENABLECLOUDS_ON
			#pragma shader_feature_local _ENABLEMOON_ON
			#pragma shader_feature_local _ENABLESUN_ON
			#pragma shader_feature_local _ENABLESTARS_ON
			#pragma shader_feature_local _ENABLEPATTERNOVERLAY_ON
			#pragma shader_feature_local _BACKGROUNDMODE_COLORS _BACKGROUNDMODE_CUBEMAP _BACKGROUNDMODE_COMBINED
			#pragma shader_feature_local _ENABLESTARSROTATION_ON
			#pragma shader_feature_local _ENABLESTARSTWINKLING_ON
			#pragma shader_feature_local _CLOUDSLITBYSUN_ON
			#pragma shader_feature_local _ENABLECLOUDSROTATION_ON


			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 worldPos : TEXCOORD0;
				#endif
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			uniform half _BackgroundCat;
			uniform half _MoonCat;
			uniform half _FogCat;
			uniform half _SunCat;
			uniform half _PatternCat;
			uniform float _BackgroundCubemapSpace;
			uniform float _EnableFogMessage;
			uniform half _CloudsCat;
			uniform half _StarsCat;
			uniform half _Banner;
			uniform half _SkyboxCat;
			uniform half4 _EquatorColor;
			uniform half4 _GroundColor;
			uniform half4 _SkyColor;
			uniform float3 _SkyboxRotationAxis;
			uniform float _SkyboxRotation;
			uniform half _EquatorHeight;
			uniform half _EquatorSmoothness;
			uniform samplerCUBE _BackgroundCubemap;
			uniform half _BackgroundExposure;
			uniform half _PatternContrast;
			uniform samplerCUBE _PatternCubemap;
			uniform half3 GlobalSunDirection;
			uniform half _StarsSunMask;
			uniform samplerCUBE _StarsCubemap;
			uniform half _StarsRotation;
			uniform half _StarsRotationSpeed;
			uniform half _StarsLayer;
			uniform half _StarsSize;
			uniform sampler2D _TwinklingTexture;
			uniform half _TwinklingSpeed;
			uniform half _TwinklingContrast;
			uniform half _StarsHeightMask;
			uniform half _StarsIntensity;
			uniform sampler2D _SunTexture;
			uniform half _SunSize;
			uniform half4 _SunColor;
			uniform half _SunIntensity;
			uniform sampler2D _MoonTexture;
			uniform half3 GlobalMoonDirection;
			uniform half _MoonSize;
			uniform half4 _MoonColor;
			uniform half _MoonIntensity;
			uniform half4 _CloudsShadowColor;
			uniform half4 _CloudsLightColor;
			uniform samplerCUBE _CloudsCubemap;
			uniform half _CloudsRotation;
			uniform half _CloudsRotationSpeed;
			uniform half _CloudsHeight;
			uniform half _FogHeight;
			uniform half _FogSmoothness;
			uniform half _FogFill;
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				float3 rotatedValue1228 = RotateAroundAxis( float3( 0,0,0 ), v.vertex.xyz, normalize( _SkyboxRotationAxis ), ( _SkyboxRotation * ( 2.0 * UNITY_PI ) ) );
				float3 vertexToFrag1245 = rotatedValue1228;
				o.ase_texcoord1.xyz = vertexToFrag1245;
				half3 GlobalSunDirection1005 = GlobalSunDirection;
				float3 ase_worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				float3 ase_worldViewDir = UnityWorldSpaceViewDir(ase_worldPos);
				ase_worldViewDir = normalize(ase_worldViewDir);
				float dotResult732 = dot( GlobalSunDirection1005 , ase_worldViewDir );
				#ifdef _ENABLESTARS_ON
				float staticSwitch947 = saturate( (0.0 + (dotResult732 - -1.0) * (1.0 - 0.0) / (-( 1.0 - _StarsSunMask ) - -1.0)) );
				#else
				float staticSwitch947 = 0.0;
				#endif
				float vertexToFrag762 = staticSwitch947;
				o.ase_texcoord1.w = vertexToFrag762;
				half3 VertexPos1227 = rotatedValue1228;
				float3 break1238 = VertexPos1227;
				float lerpResult268 = lerp( 1.0 , ( unity_OrthoParams.y / unity_OrthoParams.x ) , unity_OrthoParams.w);
				half CAMERA_MODE300 = lerpResult268;
				float3 appendResult1217 = (float3(break1238.x , ( break1238.y * CAMERA_MODE300 ) , break1238.z));
				half3 VertexPos40_g2 = appendResult1217;
				float3 appendResult74_g2 = (float3(0.0 , VertexPos40_g2.y , 0.0));
				float3 VertexPosRotationAxis50_g2 = appendResult74_g2;
				float3 break84_g2 = VertexPos40_g2;
				float3 appendResult81_g2 = (float3(break84_g2.x , 0.0 , break84_g2.z));
				float3 VertexPosOtherAxis82_g2 = appendResult81_g2;
				half Angle44_g2 = -radians( ( _StarsRotation + ( _Time.y * _StarsRotationSpeed ) ) );
				#ifdef _ENABLESTARSROTATION_ON
				float3 staticSwitch1221 = ( VertexPosRotationAxis50_g2 + ( VertexPosOtherAxis82_g2 * cos( Angle44_g2 ) ) + ( cross( float3(0,1,0) , VertexPosOtherAxis82_g2 ) * sin( Angle44_g2 ) ) );
				#else
				float3 staticSwitch1221 = appendResult1217;
				#endif
				float3 vertexToFrag1220 = staticSwitch1221;
				o.ase_texcoord2.xyz = vertexToFrag1220;
				float2 temp_cast_0 = (_TwinklingSpeed).xx;
				float4 ase_clipPos = UnityObjectToClipPos(v.vertex);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float2 appendResult568 = (float2(ase_screenPosNorm.x , ase_screenPosNorm.y));
				float2 panner569 = ( _Time.y * temp_cast_0 + appendResult568);
				#ifdef _ENABLESTARS_ON
				float2 staticSwitch956 = panner569;
				#else
				float2 staticSwitch956 = float2( 0,0 );
				#endif
				float2 vertexToFrag761 = staticSwitch956;
				o.ase_texcoord3.xy = vertexToFrag761;
				#ifdef _ENABLESTARS_ON
				float staticSwitch953 = saturate( (0.1 + (abs( v.vertex.xyz.y ) - 0.0) * (1.0 - 0.1) / (_StarsHeightMask - 0.0)) );
				#else
				float staticSwitch953 = 0.0;
				#endif
				float vertexToFrag856 = staticSwitch953;
				o.ase_texcoord2.w = vertexToFrag856;
				float3 temp_output_962_0 = cross( GlobalSunDirection , half3(0,1,0) );
				float3 normalizeResult967 = normalize( temp_output_962_0 );
				float dotResult968 = dot( normalizeResult967 , v.vertex.xyz );
				float3 normalizeResult965 = normalize( cross( GlobalSunDirection1005 , temp_output_962_0 ) );
				float dotResult969 = dot( normalizeResult965 , v.vertex.xyz );
				float2 appendResult970 = (float2(dotResult968 , dotResult969));
				float2 break972 = appendResult970;
				float2 appendResult980 = (float2(break972.x , ( break972.y * CAMERA_MODE300 )));
				float2 temp_cast_1 = (-1.0).xx;
				float2 temp_cast_2 = (1.0).xx;
				float2 temp_cast_3 = (0.0).xx;
				float2 temp_cast_4 = (1.0).xx;
				#ifdef _ENABLESUN_ON
				float2 staticSwitch940 = (temp_cast_3 + (( appendResult980 * (20.0 + (_SunSize - 0.1) * (2.0 - 20.0) / (1.0 - 0.1)) ) - temp_cast_1) * (temp_cast_4 - temp_cast_3) / (temp_cast_2 - temp_cast_1));
				#else
				float2 staticSwitch940 = float2( 0,0 );
				#endif
				float2 vertexToFrag993 = staticSwitch940;
				o.ase_texcoord3.zw = vertexToFrag993;
				float dotResult988 = dot( GlobalSunDirection1005 , v.vertex.xyz );
				#ifdef _ENABLESUN_ON
				float staticSwitch1027 = saturate( dotResult988 );
				#else
				float staticSwitch1027 = 0.0;
				#endif
				float vertexToFrag997 = staticSwitch1027;
				o.ase_texcoord4.x = vertexToFrag997;
				float3 temp_output_1058_0 = cross( GlobalMoonDirection , half3(0,1,0) );
				float3 normalizeResult1039 = normalize( temp_output_1058_0 );
				float dotResult1036 = dot( normalizeResult1039 , v.vertex.xyz );
				half3 GlobalMoonDirection1073 = GlobalMoonDirection;
				float3 normalizeResult1064 = normalize( cross( GlobalMoonDirection1073 , temp_output_1058_0 ) );
				float dotResult1067 = dot( normalizeResult1064 , v.vertex.xyz );
				float2 appendResult1066 = (float2(dotResult1036 , dotResult1067));
				float2 break1063 = appendResult1066;
				float2 appendResult1069 = (float2(break1063.x , ( break1063.y * CAMERA_MODE300 )));
				float2 temp_cast_5 = (-1.0).xx;
				float2 temp_cast_6 = (1.0).xx;
				float2 temp_cast_7 = (0.0).xx;
				float2 temp_cast_8 = (1.0).xx;
				#ifdef _ENABLEMOON_ON
				float2 staticSwitch1057 = (temp_cast_7 + (( appendResult1069 * (20.0 + (_MoonSize - 0.1) * (2.0 - 20.0) / (1.0 - 0.1)) ) - temp_cast_5) * (temp_cast_8 - temp_cast_7) / (temp_cast_6 - temp_cast_5));
				#else
				float2 staticSwitch1057 = float2( 0,0 );
				#endif
				float2 vertexToFrag1043 = staticSwitch1057;
				o.ase_texcoord4.yz = vertexToFrag1043;
				float dotResult1054 = dot( GlobalMoonDirection1073 , v.vertex.xyz );
				#ifdef _ENABLEMOON_ON
				float staticSwitch1052 = saturate( dotResult1054 );
				#else
				float staticSwitch1052 = 0.0;
				#endif
				float vertexToFrag1051 = staticSwitch1052;
				o.ase_texcoord4.w = vertexToFrag1051;
				float3 break1240 = VertexPos1227;
				float3 appendResult1129 = (float3(break1240.x , ( break1240.y * CAMERA_MODE300 ) , break1240.z));
				float3 vertexToFrag1222 = appendResult1129;
				o.ase_texcoord5.xyz = vertexToFrag1222;
				half3 VertexPos40_g3 = appendResult1129;
				float3 appendResult74_g3 = (float3(0.0 , VertexPos40_g3.y , 0.0));
				float3 VertexPosRotationAxis50_g3 = appendResult74_g3;
				float3 break84_g3 = VertexPos40_g3;
				float3 appendResult81_g3 = (float3(break84_g3.x , 0.0 , break84_g3.z));
				float3 VertexPosOtherAxis82_g3 = appendResult81_g3;
				half Angle44_g3 = -radians( ( _CloudsRotation + ( _Time.y * _CloudsRotationSpeed ) ) );
				float3 vertexToFrag1207 = ( VertexPosRotationAxis50_g3 + ( VertexPosOtherAxis82_g3 * cos( Angle44_g3 ) ) + ( cross( float3(0,1,0) , VertexPosOtherAxis82_g3 ) * sin( Angle44_g3 ) ) );
				o.ase_texcoord6.xyz = vertexToFrag1207;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord5.w = 0;
				o.ase_texcoord6.w = 0;
				float3 vertexValue = float3(0, 0, 0);
				#if ASE_ABSOLUTE_VERTEX_POS
				vertexValue = v.vertex.xyz;
				#endif
				vertexValue = vertexValue;
				#if ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				o.vertex = UnityObjectToClipPos(v.vertex);

				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#endif
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				fixed4 finalColor;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 WorldPosition = i.worldPos;
				#endif
				float3 vertexToFrag1245 = i.ase_texcoord1.xyz;
				half3 VertexPos1227 = vertexToFrag1245;
				float4 lerpResult180 = lerp( _GroundColor , _SkyColor , ceil( VertexPos1227.y ));
				float saferPower470 = max( saturate( (0.0 + (abs( VertexPos1227.y ) - 0.0) * (1.0 - 0.0) / (_EquatorHeight - 0.0)) ) , 0.0001 );
				float4 lerpResult288 = lerp( _EquatorColor , lerpResult180 , pow( saferPower470 , ( 1.0 - _EquatorSmoothness ) ));
				half4 SKY218 = lerpResult288;
				half4 BACKGROUND1195 = ( texCUBE( _BackgroundCubemap, VertexPos1227 ) * _BackgroundExposure );
				#if defined(_BACKGROUNDMODE_COLORS)
				float4 staticSwitch1200 = SKY218;
				#elif defined(_BACKGROUNDMODE_CUBEMAP)
				float4 staticSwitch1200 = BACKGROUND1195;
				#elif defined(_BACKGROUNDMODE_COMBINED)
				float4 staticSwitch1200 = ( SKY218 * BACKGROUND1195 );
				#else
				float4 staticSwitch1200 = SKY218;
				#endif
				half4 PATTERN513 = saturate( CalculateContrast(_PatternContrast,texCUBE( _PatternCubemap, VertexPos1227 )) );
				float4 blendOpSrc574 = PATTERN513;
				float4 blendOpDest574 = staticSwitch1200;
				#ifdef _ENABLEPATTERNOVERLAY_ON
				float4 staticSwitch524 = ( saturate( (( blendOpDest574 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest574 ) * ( 1.0 - blendOpSrc574 ) ) : ( 2.0 * blendOpDest574 * blendOpSrc574 ) ) ));
				#else
				float4 staticSwitch524 = staticSwitch1200;
				#endif
				float vertexToFrag762 = i.ase_texcoord1.w;
				float3 vertexToFrag1220 = i.ase_texcoord2.xyz;
				float4 texCUBENode564 = texCUBE( _StarsCubemap, vertexToFrag1220 );
				float temp_output_537_0 = (3.0 + (_StarsLayer - 1.0) * (1.0 - 3.0) / (3.0 - 1.0));
				float2 vertexToFrag761 = i.ase_texcoord3.xy;
				float saferPower554 = max( tex2D( _TwinklingTexture, vertexToFrag761 ).r , 0.0001 );
				#ifdef _ENABLESTARSTWINKLING_ON
				float staticSwitch878 = saturate( pow( saferPower554 , _TwinklingContrast ) );
				#else
				float staticSwitch878 = 1.0;
				#endif
				float vertexToFrag856 = i.ase_texcoord2.w;
				half STARS630 = ( floor( ( vertexToFrag762 * ( ( texCUBENode564.r + ( texCUBENode564.g * step( temp_output_537_0 , 2.0 ) ) + ( texCUBENode564.b * step( temp_output_537_0 , 1.0 ) ) ) + ( _StarsSize * staticSwitch878 ) ) * vertexToFrag856 ) ) * _StarsIntensity );
				#ifdef _ENABLESTARS_ON
				float4 staticSwitch918 = ( staticSwitch524 + STARS630 );
				#else
				float4 staticSwitch918 = staticSwitch524;
				#endif
				float2 vertexToFrag993 = i.ase_texcoord3.zw;
				float4 tex2DNode995 = tex2D( _SunTexture, vertexToFrag993 );
				half4 SUN1004 = ( tex2DNode995.r * _SunColor * _SunIntensity );
				float vertexToFrag997 = i.ase_texcoord4.x;
				half SUN_MASK1003 = ( tex2DNode995.a * vertexToFrag997 );
				float4 lerpResult176 = lerp( staticSwitch918 , SUN1004 , SUN_MASK1003);
				#ifdef _ENABLESUN_ON
				float4 staticSwitch919 = lerpResult176;
				#else
				float4 staticSwitch919 = staticSwitch918;
				#endif
				float2 vertexToFrag1043 = i.ase_texcoord4.yz;
				float4 tex2DNode1049 = tex2D( _MoonTexture, vertexToFrag1043 );
				half4 MOON1077 = ( tex2DNode1049.r * _MoonColor * _MoonIntensity );
				float vertexToFrag1051 = i.ase_texcoord4.w;
				half MOON_MASK1078 = ( tex2DNode1049.a * vertexToFrag1051 );
				float4 lerpResult1114 = lerp( staticSwitch919 , MOON1077 , MOON_MASK1078);
				#ifdef _ENABLEMOON_ON
				float4 staticSwitch1113 = lerpResult1114;
				#else
				float4 staticSwitch1113 = staticSwitch919;
				#endif
				float3 vertexToFrag1222 = i.ase_texcoord5.xyz;
				float3 vertexToFrag1207 = i.ase_texcoord6.xyz;
				#ifdef _ENABLECLOUDSROTATION_ON
				float3 staticSwitch1164 = vertexToFrag1207;
				#else
				float3 staticSwitch1164 = vertexToFrag1222;
				#endif
				float3 break245 = staticSwitch1164;
				float3 appendResult246 = (float3(break245.x , ( break245.y + ( _CloudsHeight * -1.0 ) ) , break245.z));
				float4 texCUBENode41 = texCUBE( _CloudsCubemap, appendResult246 );
				half Clouds_G397 = texCUBENode41.g;
				half3 GlobalSunDirection1005 = GlobalSunDirection;
				#ifdef _ENABLECLOUDSROTATION_ON
				float3 staticSwitch1166 = vertexToFrag1207;
				#else
				float3 staticSwitch1166 = GlobalSunDirection1005;
				#endif
				float3 normalizeResult1163 = normalize( staticSwitch1166 );
				float3 temp_cast_0 = (0.0).xxx;
				float3 temp_cast_1 = (1.0).xxx;
				float3 temp_cast_2 = (-1.0).xxx;
				float3 temp_cast_3 = (1.0).xxx;
				float dotResult89 = dot( normalizeResult1163 , (temp_cast_2 + ((texCUBENode41).rgb - temp_cast_0) * (temp_cast_3 - temp_cast_2) / (temp_cast_1 - temp_cast_0)) );
				#ifdef _CLOUDSLITBYSUN_ON
				float staticSwitch391 = saturate( (0.0 + (dotResult89 - -1.0) * (1.0 - 0.0) / (1.0 - -1.0)) );
				#else
				float staticSwitch391 = Clouds_G397;
				#endif
				float4 lerpResult101 = lerp( _CloudsShadowColor , _CloudsLightColor , staticSwitch391);
				half4 CLOUDS222 = lerpResult101;
				half CLOUDS_MASK223 = texCUBENode41.a;
				float4 lerpResult227 = lerp( staticSwitch1113 , CLOUDS222 , CLOUDS_MASK223);
				#ifdef _ENABLECLOUDS_ON
				float4 staticSwitch1120 = lerpResult227;
				#else
				float4 staticSwitch1120 = staticSwitch1113;
				#endif
				float lerpResult678 = lerp( saturate( pow( (0.0 + (abs( VertexPos1227.y ) - 0.0) * (1.0 - 0.0) / (_FogHeight - 0.0)) , ( 1.0 - _FogSmoothness ) ) ) , 0.0 , _FogFill);
				half FOG_MASK359 = lerpResult678;
				float4 lerpResult317 = lerp( unity_FogColor , staticSwitch1120 , FOG_MASK359);
				#ifdef _ENABLEBUILTINFOG_ON
				float4 staticSwitch921 = lerpResult317;
				#else
				float4 staticSwitch921 = staticSwitch1120;
				#endif
				
				
				finalColor = staticSwitch921;
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "PolyverseSkiesShaderGUI"	
}
