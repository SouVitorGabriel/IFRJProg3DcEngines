
Shader	"Custom/Basic2D"
{
	Properties 
	{
		_MainTex ("Base (RGB) Transparency (A)", 2D) = "white" {}
	}

	SubShader
	{
		AlphaTest Greater 0.5

		Pass
		{	
			SetTexture [_MainTex]
			{				
				combine texture
			}
		}
	}
}
