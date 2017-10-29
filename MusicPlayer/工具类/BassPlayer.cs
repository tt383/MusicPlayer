using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Un4seen.Bass;
using Un4seen.Bass.Misc;
using Un4seen.Bass.AddOn.Tags;

namespace MusicPlayer
{
    class BassPlayer
    {
        public int _stream = 0;
        private string _fileName = String.Empty;
        private int _tickCounter = 0;
        private int _deviceLatencyMS = 0; // device latency in milliseconds
        private Visuals _vis = new Visuals(); // visuals class instance
        private int _updateInterval = 50; // 50ms
        private Un4seen.Bass.BASSTimer _updateTimer = null;

        public  double ElapsedTime = 0;
        public  double TotalTime = 0;

        public IntPtr Handle { get; private set; }
        public BASSActive bIsPlaying { get { return Bass.BASS_ChannelIsActive(_stream); } }


        public BassPlayer()
        {
            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_LATENCY, this.Handle))
            {
                BASS_INFO info = new BASS_INFO();
                Bass.BASS_GetInfo(info);
                Console.WriteLine(info.ToString());
                _deviceLatencyMS = info.latency;

                BassNet.UseBrokenLatin1Behavior = true;

                Bass.BASS_PluginLoad("bass_flac.dll");
                Bass.BASS_PluginLoad("bass_ape.dll");
            }
            else
                MessageBox.Show("Bass_Init error!");

            // create a secure timer
            _updateTimer = new Un4seen.Bass.BASSTimer(_updateInterval);
            _updateTimer.Tick += new EventHandler(timerUpdate_Tick);
            
        }

        private void timerUpdate_Tick(object sender, System.EventArgs e)
        {
            // here we gather info about the stream, when it is playing...
            if (Bass.BASS_ChannelIsActive(_stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                // the stream is still playing...
            }
            else
            {
                ElapsedTime = 0;
                _updateTimer.Stop();
                return;
            }

            // from here on, the stream is for sure playing...
            _tickCounter++;
            

            if (_tickCounter == 2)
            {
                _tickCounter = 0;
                long pos = Bass.BASS_ChannelGetPosition(_stream); // position in bytes
                long len = Bass.BASS_ChannelGetLength(_stream); // length in bytes
                TotalTime = (int)Bass.BASS_ChannelBytes2Seconds(_stream, len); // the total time length
                ElapsedTime = (int)Bass.BASS_ChannelBytes2Seconds(_stream, pos); // the elapsed time length
            }

        }
        
        public bool PlaySongs(string FileName)
        {
            _updateTimer.Stop();
            Bass.BASS_StreamFree(_stream);

            if (FileName != String.Empty)
            {
                _stream = Bass.BASS_StreamCreateFile(FileName, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);

                if (_stream != 0 && Bass.BASS_ChannelPlay(_stream, false))
                {
                    _updateTimer.Start();
                    ElapsedTime = 0;
                    return true;
                }
                else
                {
                    Console.WriteLine("Error={0}", Bass.BASS_ErrorGetCode());
                    return false;
                }
            }
            return false;
        }

        public static TAG_INFO GetSongInfo(string FileName)
        {

            TAG_INFO SongInfo = new TAG_INFO();

            SongInfo = BassTags.BASS_TAG_GetFromFile(FileName);
            return SongInfo;
        }

        public void Pause()
        {
            if (Bass.BASS_ChannelIsActive(_stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                // the stream is still playing...
                Bass.BASS_ChannelPause(_stream);
                _updateTimer.Stop();
            }
        }

        public void Resume()
        {
            if (Bass.BASS_ChannelIsActive(_stream) == BASSActive.BASS_ACTIVE_PAUSED)
            {
                // the stream is still playing...
                Bass.BASS_ChannelPlay(_stream,false);
                _updateTimer.Start();
            }
        }

        public void Stop()
        {
            if ((Bass.BASS_ChannelIsActive(_stream) == BASSActive.BASS_ACTIVE_PLAYING) ||
                 Bass.BASS_ChannelIsActive(_stream) == BASSActive.BASS_ACTIVE_PAUSED )
            {
                // the stream is still playing...
                Bass.BASS_ChannelStop(_stream);
                Bass.BASS_StreamFree(_stream);
                _updateTimer.Stop();
            }
        }

        public int SetPostion(int pos)
        {
            if (Bass.BASS_ChannelIsActive(_stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelSetPosition(_stream, (double)pos);

                return 1;
            }
            else
                return -1;
        }


        public void BassClose()
        {
            _updateTimer.Tick -= new EventHandler(timerUpdate_Tick);
            Bass.BASS_Stop();
            Bass.BASS_Free();
        }

        public void Free()
        {
            Bass.BASS_Free();
        }


    }
}
