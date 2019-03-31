using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlock : Block {

	public Vector2[,] myUVs = { 
		/*TOP*/			{new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f),
								new Vector2( 0.125f, 1.0f ),new Vector2( 0.1875f, 1.0f )},
		/*SIDE*/		{new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f),
								new Vector2( 0.125f, 1.0f ),new Vector2( 0.1875f, 1.0f )},
		/*BOTTOM*/		{new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f),
								new Vector2( 0.125f, 1.0f ),new Vector2( 0.1875f, 1.0f )}};

	public DirtBlock(Vector3 pos, GameObject p, Material c)
	{
		bType = BlockType.DIRT;
		parent = p;
		position = pos;
		cubeMaterial = c;
		isSolid = true;

		blockUVs = myUVs;
	}

}
