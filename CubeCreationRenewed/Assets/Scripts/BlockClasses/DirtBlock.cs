using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class DirtBlock : Block
    {
        public Vector2[,] dirtBlockUVs = {
        {new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f),new Vector2( 0.125f, 1.0f ),new Vector2( 0.1875f, 1.0f )}, // DIRT TOP
        {new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f),new Vector2( 0.125f, 1.0f ),new Vector2( 0.1875f, 1.0f )}, // DIRT SIDE
        {new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f),new Vector2( 0.125f, 1.0f ),new Vector2( 0.1875f, 1.0f )}  // DIRT BOTTOM 
        };
        public DirtBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.DIRT;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = dirtBlockUVs;
            health = BlockHealth.CRACK3;
            currentHealth = blockHealthMax[(int)bType];
        }

    }
}

