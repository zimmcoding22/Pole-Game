using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craterGenerator : MonoBehaviour
{
    public Terrain terrain;

    public Vector3 pos;
    public float shape;
    public float R;

    public bool cm;
    public float TerTopH;
    public float wallH;
    public float MetNumber;
    // Start is called before the first frame update
    public void GenCrater()
    {
        float[,] map = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
        map = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
        Vector3 relpos = (pos - terrain.transform.position);
        int x = (terrain.terrainData.heightmapResolution * (int)relpos.x) / 1000;
        int y = (terrain.terrainData.heightmapResolution * (int)relpos.z) / 1000;

        int relR = (terrain.terrainData.heightmapResolution * Mathf.RoundToInt(R)) / 1000;

        float centerH = map[x, y];
        for (int i = 0; i < relR; i++)
        {
            int Rc = (i * 1000) / terrain.terrainData.heightmapResolution;


            for (int a = 0; a < 360; a++)
            {

                float alpha = a * Mathf.Deg2Rad;
                int plusx = (terrain.terrainData.heightmapResolution * Mathf.RoundToInt(Rc * Mathf.Cos(alpha))) / 1000;
                int plusy = (terrain.terrainData.heightmapResolution * Mathf.RoundToInt(Rc * Mathf.Sin(alpha))) / 1000;
                if (i > relR - relR / 20)
                {
                    float topH;
                    if (i < relR - relR / 40)
                    {
                        topH = relR / (wallH * shape);
                    }
                    else
                    {
                        topH = relR / ((shape * wallH) / 2);
                    }

                    float alt = Mathf.Sqrt(Mathf.Pow(R, 2) - Rc * Rc);
                    float sbh = centerH + (-alt) / (shape * TerTopH);

                    float myh = centerH + topH / TerTopH;
                    if (Blur(map, x + plusx, y + plusy) > sbh)
                    {
                        map[x + plusx, y + plusy] = myh;

                        map[x + plusx - 1, y + plusy] = myh;
                        map[x + plusx + 1, y + plusy] = myh;

                        map[x + plusx, y + plusy - 1] = myh;
                        map[x + plusx, y + plusy + 1] = myh;

                        map[x + plusx - 1, y + plusy - 1] = myh;
                        map[x + plusx + 1, y + plusy + 1] = myh;

                        map[x + plusx - 1, y + plusy + 1] = myh;
                        map[x + plusx + 1, y + plusy - 1] = myh;
                    }

                }
                else if (cm && i < relR / 6)
                {
                    float topH = R / 8;
                    float topR = relR / 6;
                    float alt = (topR - i) * 3;


                    float myh = centerH + (-R + alt) / (TerTopH * shape);
                    map[x + plusx, y + plusy] = myh;

                    map[x + plusx - 1, y + plusy] = myh;
                    map[x + plusx + 1, y + plusy] = myh;

                    map[x + plusx, y + plusy - 1] = myh;
                    map[x + plusx, y + plusy + 1] = myh;

                    map[x + plusx - 1, y + plusy - 1] = myh;
                    map[x + plusx + 1, y + plusy + 1] = myh;

                    map[x + plusx - 1, y + plusy + 1] = myh;
                    map[x + plusx + 1, y + plusy - 1] = myh;
                }
                else
                {
                    float alt = Mathf.Sqrt(Mathf.Pow(R, 2) - Rc * Rc);
                    float myh = centerH + (-alt) / (shape * TerTopH);
                    if (Blur(map, x + plusx, y + plusy) > myh)
                    {
                        map[x + plusx, y + plusy] = myh;


                        map[x + plusx - 1, y + plusy] = myh;
                        map[x + plusx + 1, y + plusy] = myh;

                        map[x + plusx, y + plusy - 1] = myh;
                        map[x + plusx, y + plusy + 1] = myh;

                        map[x + plusx - 1, y + plusy - 1] = myh;
                        map[x + plusx + 1, y + plusy + 1] = myh;

                        map[x + plusx - 1, y + plusy + 1] = myh;
                        map[x + plusx + 1, y + plusy - 1] = myh;


                    }

                }

            }
        }


        terrain.terrainData.SetHeights(0, 0, map);

    }
    float Blur(float[,] map, int x, int y)
    {
        return (
    map[x + 1, y] +
    map[x - 1, y] +
    map[x, y + 1] +
     map[x, y - 1] +
    map[x + 1, y + 1] +
    map[x - 1, y - 1] +
    map[x - 1, y + 1] +
    map[x + 1, y - 1]) / 8;
    }
    public void Smooth()
    {

        float[,] map = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
        map = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
        for (int x = 1; x < map.GetLength(0) - 1; x++)
        {
            for (int y = 1; y < map.GetLength(1) - 1; y++)
            {

                map[x, y] = Blur(map, x, y);
            }
        }
        terrain.terrainData.SetHeights(0, 0, map);
    }

    public void MakeItRain()
    {
        for (int i = 0; i < MetNumber; i++)
        {
            pos = new Vector3(Random.Range(200f, 800f), 0, Random.Range(200f, 800f));
            R = Random.Range(10f, 200f);
            GenCrater();
        }
        Smooth();

    }
}
