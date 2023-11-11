using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    
   public int length;
    public LineRenderer lineRend;
    public Vector3 [] segmentPoses;
    public Vector3[] segmentV;
    public Transform targetDir,dot, dot2;
    public float targetDist, targetDistMin, targetDistMax;
    public float smoothSpeed;
    public float tentacleTime;
    private float compTime;
    private bool tentacleSize;

    private void Start() 
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV= new Vector3[length];
        tentacleSize=true;
    }

    private void Update() 
    {
         if(compTime<tentacleTime)
         {
               
                compTime+=Time.deltaTime;
         }
         else{
                    compTime=0.0f;
                 if(tentacleSize)
                {
                    targetDist=targetDistMin;
                    tentacleSize=false;
                }
                else{

                    targetDist=targetDistMax;
                    tentacleSize=true;
                }

         }

          




         segmentPoses[0] =targetDir.position;
        for(int i =1;i< segmentPoses.Length;i++)
        {
                segmentPoses[i]=Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i-1]+ targetDir.up*targetDist, ref segmentV[i],smoothSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}
