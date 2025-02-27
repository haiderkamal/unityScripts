﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EngineSound : MonoBehaviour
{

    //Setting's Values
    public float[] MinRpmTable = { 500f, 750f };
    public float[] NormalRpmTable = { 720f, 930f, 1559f };
    public float[] MaxRpmTable = { 1360f, 1829f};
    public float[] PitchingTable = { 0.12f, 0.12f, 0.12f, 0.12f, 0.11f, 0.10f, 0.09f, 0.08f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f };

    //Make Values
    //public float Pitching = 0.2f;
    public float RangeDivider = 4f;

    //Make Components
    public RearWheelDrive Fly;
    public float RPM;
    public float soundRPM;
    public List<AudioSource> CarSounds;
    //public bool Mode = false;

    //Make 16x Audio Source
    public AudioSource Audio1;
    public AudioSource Audio2;
    public AudioSource Audio3;
    public AudioSource Audio4;
    public AudioSource Audio5;
    public AudioSource Audio6;
    public AudioSource Audio7;
    public AudioSource Audio8;
    public AudioSource Audio9;
    public AudioSource Audio10;
    public AudioSource Audio11;
    public AudioSource Audio12;
    public AudioSource Audio13;
    public AudioSource Audio14;
    public AudioSource Audio15;
    public AudioSource Audio16;
    public AudioSource Reverse;

    void Start()
    {
        Fly = this.GetComponent<RearWheelDrive>();

        //Get 16x Audio Source
        Audio1 = Audio1.GetComponent<AudioSource>();
        Audio2 = Audio2.GetComponent<AudioSource>();
        Audio3 = Audio3.GetComponent<AudioSource>();
        Audio4 = Audio4.GetComponent<AudioSource>();
        Audio5 = Audio5.GetComponent<AudioSource>();
        Audio6 = Audio6.GetComponent<AudioSource>();
        Audio7 = Audio7.GetComponent<AudioSource>();
        Audio8 = Audio8.GetComponent<AudioSource>();
        Audio9 = Audio9.GetComponent<AudioSource>();
        Audio10 = Audio10.GetComponent<AudioSource>();
        Audio11 = Audio11.GetComponent<AudioSource>();
        Audio12 = Audio12.GetComponent<AudioSource>();
        Audio13 = Audio13.GetComponent<AudioSource>();
        Audio14 = Audio14.GetComponent<AudioSource>();
        Audio15 = Audio15.GetComponent<AudioSource>();
        Audio16 = Audio16.GetComponent<AudioSource>();
        Reverse = Reverse.GetComponent<AudioSource>();

        //Play Audio's
        Audio1.Play();
        Audio2.Play();
        Audio3.Play();
        Audio4.Play();
        Audio5.Play();
        Audio6.Play();
        Audio7.Play();
        Audio8.Play();
        Audio9.Play();
        Audio10.Play();
        Audio11.Play();
        Audio12.Play();
        Audio13.Play();
        Audio14.Play();
        Audio15.Play();
        Audio16.Play();
        Reverse.Play();
        for (int i=0; i<16;i++)
        {
         //   CarSounds.Add(GameObject.Find(string.Format("Carsounds ({0})",i)).GetComponent<AudioSource>());
        }
    }

    void Update()
    {
        soundRPM = (Fly.wheels[3].rpm*5) + 600f;
        //Debug.Log("Sound RPM: "+soundRPM);
       // RPM = Mathf.Round(soundRPM * (1000 / 420));
        RPM = soundRPM;
        Debug.Log("Sound RPM: " + RPM);
        //Set Volume By Rpm's
        for (int i = 0; i < 4; i++)
        {

            if (i == 0)
            {
                if (RPM < 550)
                {
                    Reverse.volume = 1f;
                    Audio1.volume = 0f;
                }
                if (RPM > 550)
                {
                    Reverse.volume = 0f;
                    Audio1.volume = 1f;
                }
                //Set Audio1
                else if (RPM < MinRpmTable[i])
                {
                    
                    Audio1.volume = 0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio1.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio1.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio1.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio1.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio1.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio1.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 1)
            {
                //Set Audio2
                if (RPM < MinRpmTable[i])
                {
                    Audio2.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio2.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio2.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio2.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio2.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio2.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio2.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 2)
            {
                //Set Audio3
                if (RPM < MinRpmTable[i])
                {
                    Audio3.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio3.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio3.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio3.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio3.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio3.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio3.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 3)
            {
                //Set Audio4
                if (RPM < MinRpmTable[i])
                {
                    Audio4.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio4.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio4.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio4.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio4.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio4.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio4.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 4)
            {
                //Set Audio5
                if (RPM < MinRpmTable[i])
                {
                    Audio5.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio5.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio5.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio5.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio5.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio5.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio5.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 5)
            {
                //Set Audio6
                if (RPM < MinRpmTable[i])
                {
                    Audio6.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio6.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio6.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio6.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio6.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio6.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio6.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 6)
            {
                //Set Audio7
                if (RPM < MinRpmTable[i])
                {
                    Audio7.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio7.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio7.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio7.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio7.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio7.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio7.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 7)
            {
                //Set Audio8
                if (RPM < MinRpmTable[i])
                {
                    Audio8.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio8.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio8.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio8.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio8.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio8.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio8.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 8)
            {
                //Set Audio9
                if (RPM < MinRpmTable[i])
                {
                    Audio9.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio9.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio9.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio9.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio9.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio9.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio9.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 9)
            {
                //Set Audio10
                if (RPM < MinRpmTable[i])
                {
                    Audio10.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio10.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio10.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio10.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio10.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio10.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio10.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 10)
            {
                //Set Audio11
                if (RPM < MinRpmTable[i])
                {
                    Audio11.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio11.volume = ((ReducedRPM / Range) * 2f) - 1f;
                    //Audio11.volume = 0.0f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio11.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio11.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio11.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio11.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio11.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 11)
            {
                //Set Audio12
                if (RPM < MinRpmTable[i])
                {
                    Audio12.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio12.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio12.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio12.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio12.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio12.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio12.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 12)
            {
                //Set Audio13
                if (RPM < MinRpmTable[i])
                {
                    Audio13.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio13.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio13.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio13.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio13.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio13.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio13.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 13)
            {
                //Set Audio14
                if (RPM < MinRpmTable[i])
                {
                    Audio14.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio14.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio14.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio14.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio14.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio14.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio14.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 14)
            {
                //Set Audio15
                if (RPM < MinRpmTable[i])
                {
                    Audio15.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio15.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio15.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio15.volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio15.pitch = 1f + PitchMath;
                }
                else if (RPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = RPM - MaxRpmTable[i];
                    Audio15.volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //Audio15.pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 15)
            {
                //Set Audio16
                if (RPM < MinRpmTable[i])
                {
                    Audio16.volume = 0.0f;
                }
                else if (RPM >= MinRpmTable[i] && RPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = RPM - MinRpmTable[i];
                    Audio16.volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    Audio16.pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (RPM >= NormalRpmTable[i] && RPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = RPM - NormalRpmTable[i];
                    Audio16.volume = 1f;
                    float PitchMath = (ReducedRPM * (PitchingTable[i] + 0.1f)) / Range;
                    Audio16.pitch = 1f + PitchMath;
                }
            }
        }

    }
}