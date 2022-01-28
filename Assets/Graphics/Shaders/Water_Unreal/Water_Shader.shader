// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Water_Shader"
{
	Properties
	{
		_Water0339("Water 0339", 2D) = "white" {}
		_Water0339normal("Water 0339normal", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Water0339normal;
		uniform float4 _Water0339normal_ST;
		uniform sampler2D _Water0339;
		uniform float4 _Water0339_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Water0339normal = i.uv_texcoord * _Water0339normal_ST.xy + _Water0339normal_ST.zw;
			o.Normal = tex2D( _Water0339normal, uv_Water0339normal ).rgb;
			float2 uv_Water0339 = i.uv_texcoord * _Water0339_ST.xy + _Water0339_ST.zw;
			o.Albedo = tex2D( _Water0339, uv_Water0339 ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17400
563;291;994;768;507.5211;184.5149;1.076304;True;False
Node;AmplifyShaderEditor.SamplerNode;11;-63.00766,63.03495;Inherit;True;Property;_Water0339;Water 0339;0;0;Create;True;0;0;False;0;-1;7dc40a04650646c43a799d4696fe1178;7dc40a04650646c43a799d4696fe1178;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;12;-46.86314,276.1431;Inherit;True;Property;_Water0339normal;Water 0339normal;1;0;Create;True;0;0;False;0;-1;e5c670e3d7ed5d24b8397310eb44fdbe;e5c670e3d7ed5d24b8397310eb44fdbe;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;455.9191,80.72278;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Custom/Water_Shader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;0;0;11;0
WireConnection;0;1;12;0
ASEEND*/
//CHKSM=56544C66611FA76A1CFC0B2848F97E8133E3E0C1