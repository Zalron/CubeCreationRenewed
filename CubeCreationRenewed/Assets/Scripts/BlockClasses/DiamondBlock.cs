using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class DiamondBlock : Block
    {
        public Vector2[,] diamondBlockUVs = {
        {new Vector2( 0.125f, 0.75f ), new Vector2( 0.1875f, 0.75f),new Vector2( 0.125f, 0.8125f ),new Vector2( 0.1875f, 0.8125f )}, /*DIAMOND*/
        };
        public DiamondBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.DIAMOND;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = diamondBlockUVs;
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
        }
    }
}
