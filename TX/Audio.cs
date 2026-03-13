using Microsoft.VisualBasic;
using NAudio.Wave;
using System;
using System.IO;
using System.Threading;

class BFSKModulator
{
    //const int sampleRate = 44100;
    ////const int bitRate = 1200;  // VHF
    //const int bitRate = 100;  // HF
    //const double bitxsec = 1d / bitRate;
    //const double samplesPerBit = sampleRate * bitxsec;
    ////VHF
    ////const double f0 = 2100.0; // bit 0
    ////const double f1 = 1300.0; // bit 1
    ////HF
    //const double f0 = 1785.0; // bit 0
    //const double f1 = 1615.0; // bit 1

    public static void GenerateWav(string inputTxt, string outputWav, bool vhf)
    {
        int bitRate;
        double f0, f1;
        if (vhf) 
        {
            //VHF
            bitRate = 1200;  // VHF
            f0 = 2100.0; // bit 0
            f1 = 1300.0; // bit 1
        }
        else
        {
            //HF
            bitRate = 100;  // HF
            f0 = 1785.0; // bit 0
            f1 = 1615.0; // bit 1

        }
        const int sampleRate = 44100;
        double bitxsec = 1d / bitRate;
        double samplesPerBit = sampleRate * bitxsec;

        string bitstream = File.ReadAllText(inputTxt);

        var waveFormat = new WaveFormat(sampleRate, 16, 1);
        using var writer = new WaveFileWriter(outputWav, waveFormat);

        double amplitude = 0.25 * short.MaxValue;
        double phase = 0;

        foreach (char c in bitstream)
        {
            if (c != '0' && c != '1')
                continue; // ignora saltos de linea o espacios

            double freq = (c == '0') ? f0 : f1;

            for (int n = 0; n < samplesPerBit; n++)
            {
                double sample = amplitude * Math.Sin(2 * Math.PI * freq * phase / sampleRate);
                writer.WriteSample((float)(sample / short.MaxValue));
                phase++;
            }
        }
    }
}

class AudioPlayer
{
    public static void Play(string file)
    {
        using var audioFile = new AudioFileReader(file);
        using var outputDevice = new WaveOutEvent();

        outputDevice.Init(audioFile);
        outputDevice.Play();

        // Espera hasta que termine
        while (outputDevice.PlaybackState == PlaybackState.Playing)
            Thread.Sleep(100);
    }
}