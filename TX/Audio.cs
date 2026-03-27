using Microsoft.VisualBasic;
using NAudio.Wave;
using System;
using System.IO;
using System.Threading;

class BFSKModulator
{
    public static void GenerateWav(string inputTxt, string outputWav, bool vhf)
    {
        int bitRate;
        double f0, f1;
        if (vhf)
        {
            // VHF — 1200 bps según ITU-R M.493-16
            bitRate = 1200;  // CORREGIDO: era 100 (bug)
            f0 = 2100.0;     // bit 0
            f1 = 1300.0;     // bit 1
        }
        else
        {
            // HF — 100 bps
            bitRate = 100;
            f0 = 1785.0;     // bit 0
            f1 = 1615.0;     // bit 1
        }

        const int sampleRate = 44100;

        // samplesPerBit como double: 44100/1200 = 36.75 (NO se trunca a 36).
        // Si se usara int, cada símbolo VHF perdería 0.75 muestras →
        // drift de ~3 símbolos en un mensaje de 150 bits.
        double samplesPerBit = (double)sampleRate / bitRate;

        string bitstream = File.ReadAllText(inputTxt);

        var waveFormat = new WaveFormat(sampleRate, 16, 1);
        using var writer = new WaveFileWriter(outputWav, waveFormat);

        double amplitude = 0.25 * short.MaxValue;
        double phase = 0.0;  // acumulador de fase continua (CPFSK — nunca se resetea)
        double posAccum = 0.0;  // acumulador de posición para timing exacto

        foreach (char c in bitstream)
        {
            if (c != '0' && c != '1')
                continue;

            double freq = (c == '0') ? f0 : f1;

            // Calcular cuántas muestras le corresponden a este símbolo,
            // alternando entre floor/ceil para mantener promedio exacto en 36.75.
            int startSample = (int)Math.Round(posAccum);
            posAccum += samplesPerBit;
            int endSample = (int)Math.Round(posAccum);
            int nSamples = endSample - startSample;

            for (int n = 0; n < nSamples; n++)
            {
                double sample = amplitude * Math.Sin(2 * Math.PI * freq * phase / sampleRate);
                writer.WriteSample((float)(sample / short.MaxValue));
                phase++;  // fase continua: preserva CPFSK
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

        while (outputDevice.PlaybackState == PlaybackState.Playing)
            Thread.Sleep(100);
    }
}