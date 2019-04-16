using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class SandBlock : Block
    {
        public Vector2[,] sandBlockUVs = {
        {new Vector2( 0.125f, 0.875f ), new Vector2( 0.1875f, 0.875f),new Vector2( 0.125f, 0.9375f ),new Vector2( 0.1875f, 0.9375f )}, /*SAND*/
        };
        public SandBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.SAND;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = sandBlockUVs;
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];


        }
    }
}
