using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlock : Block {

	public Vector2[,] myUVs = { 
		/*TOP*/			{new Vector2( 0.125f, 0.375f ), new Vector2( 0.1875f, 0.375f),
								new Vector2( 0.125f, 0.4375f ),new Vector2( 0.1875f, 0.4375f )},
		/*SIDE*/		{new Vector2( 0.1875f, 0.9375f ), new Vector2( 0.25f, 0.9375f),
								new Vector2( 0.1875f, 1.0f ),new Vector2( 0.25f, 1.0f )},
		/*BOTTOM*/			{new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f),
								new Vector2( 0.125f, 1.0f ),new Vector2( 0.1875f, 1.0f )}};
	
	public GrassBlock(Vector3 pos, GameObject p, Material c)
	{
		bType = BlockType.GRASS;
		parent = p;
		position = pos;
		cubeMaterial = c;
		isSolid = true;

		blockUVs = myUVs;
	}
}
