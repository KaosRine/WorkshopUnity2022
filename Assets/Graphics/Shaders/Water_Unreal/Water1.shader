// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Water1"
{
	Properties
	{
		_Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large("Water_preview.jpgC878A51E-2B84-45CA-85CB-75E5BC88EEC8Large", 2D) = "white" {}
		_Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large1("Water_preview.jpgC878A51E-2B84-45CA-85CB-75E5BC88EEC8Large", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large;
		uniform sampler2D _Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large1;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TexCoord7 = i.uv_texcoord * float2( 2,2 );
			float2 panner8 = ( 1.0 * _Time.y * float2( 0,0.5 ) + uv_TexCoord7);
			float2 panner10 = ( 1.0 * _Time.y * float2( 0.2,0 ) + uv_TexCoord7);
			o.Normal = ( tex2D( _Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large, panner8 ) + tex2D( _Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large1, panner10 ) ).rgb;
			float4 color6 = IsGammaSpace() ? float4(1,1,1,0) : float4(1,1,1,0);
			o.Albedo = color6.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17400
403;73;962;650;768.8903;20.9455;1;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;7;-1508.896,429.8677;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;2,2;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;8;-1164.213,239.2226;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0.5;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;10;-1148.288,604.4557;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.2,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;11;-900.0168,573.6724;Inherit;True;Property;_Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large1;Water_preview.jpgC878A51E-2B84-45CA-85CB-75E5BC88EEC8Large;1;0;Create;True;0;0;False;0;-1;ab56138dc7291694c9baa814049ad420;ab56138dc7291694c9baa814049ad420;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;5;-895.9414,274.4394;Inherit;True;Property;_Water_previewjpgC878A51E2B8445CA85CB75E5BC88EEC8Large;Water_preview.jpgC878A51E-2B84-45CA-85CB-75E5BC88EEC8Large;0;0;Create;True;0;0;False;0;-1;ab56138dc7291694c9baa814049ad420;ab56138dc7291694c9baa814049ad420;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;6;-450.8718,84.55862;Inherit;False;Constant;_Color0;Color 0;1;0;Create;True;0;0;False;0;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;12;-465.6017,363.397;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-104.7077,195.5452;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Water1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;8;0;7;0
WireConnection;10;0;7;0
WireConnection;11;1;10;0
WireConnection;5;1;8;0
WireConnection;12;0;5;0
WireConnection;12;1;11;0
WireConnection;0;0;6;0
WireConnection;0;1;12;0
ASEEND*/
//CHKSM=189FBE7C779BC3F0CF80BEA69A9ADBDA66DF1A98