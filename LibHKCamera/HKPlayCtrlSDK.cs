using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LibHKCamera.HKPlayCtrlSDK
{
    public class HKPlayCtrlSDK
    {
        public const string dllPath= @"PlayCtrl.dll";
        //Frame position
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;

            public void Init()
            {
                wYear = 0;
                wMonth = 0;
                wDayOfWeek = 0;
                wDay = 0;
                wHour = 0;
                wMinute = 0;
                wSecond = 0;
                wMilliseconds = 0;
            }
        }

        public struct FRAME_POS
        {
            public int nFilePos;
            public int nFrameNum;
            public int nFrameTime;
            public int nErrorFrameNum;
            public IntPtr pErrorTime;
            public int nErrorLostFrameNum;
            public int nErrorFrameSize;

            public void Init()
            {
                nFilePos = 0;
                nFrameNum = 0;
                nFrameTime = 0;
                nErrorFrameNum = 0;
                pErrorTime = new IntPtr();
                nErrorLostFrameNum = 0;
                nErrorFrameSize = 0;
            }
        }

        //Frame Info
        public struct FRAME_INFO
        {
            public int nWidth;
            public int nHeight;
            public int nStamp;
            public int nType;
            public int nFrameRate;
            public uint dwFrameNum;

            public void Init()
            {
                nWidth = 0;
                nHeight = 0;
                nStamp = 0;
                nType = 0;
                nFrameRate = 0;
                dwFrameNum = 0;
            }
        }

        //Frame
        public struct FRAME_TYPE
        {
            [MarshalAsAttribute(UnmanagedType.LPStr)]
            public string pDataBuf;
            public int nSize;
            public int nFrameNum;
            public bool bIsAudio;
            public int nReserved;

            public void Init()
            {
                pDataBuf = "";
                nSize = 0;
                nFrameNum = 0;
                bIsAudio = false;
                nReserved = 0;
            }
        }

        //Watermark Info	//add by gb 080119
        public struct WATERMARK_INFO
        {
            [MarshalAsAttribute(UnmanagedType.LPStr)]
            public string pDataBuf;
            public int nSize;
            public int nFrameNum;
            public bool bRsaRight;
            public int nReserved;

            public void Init()
            {
                pDataBuf = "";
                nSize = 0;
                nFrameNum = 0;
                bRsaRight = false;
                nReserved = 0;
            }
        }

        // modified by gb 080425
        public struct HIK_MEDIAINFO
        {
            public uint media_fourcc;// "HKMI": 0x484B4D49 Hikvision Media Information
            public ushort media_version;// 版本号：指本信息结构版本号，目前为0x0101,即1.01版本，01：主版本号；01：子版本号。
            public ushort device_id;// 设备ID，便于跟踪/分析	

            public ushort system_format;// 系统封装层
            public ushort video_format;// 视频编码类型

            public ushort audio_format;// 音频编码类型
            public byte audio_channels;// 通道数  
            public byte audio_bits_per_sample;// 样位率
            public uint audio_samplesrate;// 采样率 
            public uint audio_bitrate;// 压缩音频码率,单位：bit
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            public uint[] reserved;// 保留

            public void Init()
            {
                media_fourcc = 0;
                media_version = 0;
                device_id = 0;
                system_format = 0;
                video_format = 0;
                audio_format = 0;
                audio_channels = 0;
                audio_bits_per_sample = 0;
                audio_samplesrate = 0;
                audio_bitrate = 0;
                reserved = new uint[4];
            }
        }

        //自己定义的函数接口
        /*************************************************
        Function:	 ConverUiTimeToDateTime
        Description: 把用uint表示的时间转换成DateTime表示的时间
        Input:		 void
        Output:      void
        Return:		 void
        *************************************************/
        public static DateTime ConverUiTimeToDateTime(uint uiTime)
        {
            int iYear = (int)((uiTime >> 26) + 2000);
            int iMonth = (int)((uiTime >> 22) & 15);
            int iDay = (int)((uiTime >> 17) & 31);
            int iHour = (int)((uiTime >> 12) & 31);
            int iMinute = (int)((uiTime >> 6) & 63);
            int iSecond = (int)((uiTime >> 0) & 63);
            DateTime dateTime = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);
            return dateTime;
        }

        /*************************************************
        Function:	 GetTimeFromUiTime
        Description:  从uint表示的时间获取时间
        Input:		  void
        Output:       void
        Return:		  void
        *************************************************/
        public static void GetTimeFromUiTime(uint uiTime, ref uint uiHour, ref uint uiMinute, ref uint uiSecond)
        {
            uiHour = ((uiTime >> 12) & 31);
            uiMinute = ((uiTime >> 6) & 63);
            uiSecond = ((uiTime >> 0) & 63);
        }

        ////////////////ver 3.0 added///////////////////////////////////////
        public struct tagRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public void Init()
            {
                left = 0;
                top = 0;
                right = 0;
                bottom = 0;
            }
        }

        //API
        //Initialize DirecDraw.Now invalid.
        [DllImport(dllPath)]
        public static extern bool PlayM4_InitDDraw(IntPtr hWnd);
        //Release directDraw; Now invalid.
        [DllImport(dllPath)]
        public static extern bool PlayM4_RealeseDDraw();

        [DllImport(dllPath)]
        public static extern bool PlayM4_OpenFile(int nPort, String sFileName);

        [DllImport(dllPath)]
        public static extern bool PlayM4_CloseFile(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_Play(int nPort, IntPtr hWnd);

        [DllImport(dllPath)]
        public static extern bool PlayM4_Stop(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_Pause(int nPort, uint nPause);

        [DllImport(dllPath)]
        public static extern bool PlayM4_Fast(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_Slow(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_OneByOne(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetPlayPos(int nPort, float fRelativePos);

        [DllImport(dllPath)]
        public static extern float PlayM4_GetPlayPos(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetFileEndMsg(int nPort, IntPtr hWnd, uint nMsg);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetVolume(int nPort, ushort nVolume);

        [DllImport(dllPath)]
        public static extern bool PlayM4_StopSound();

        [DllImport(dllPath)]
        public static extern bool PlayM4_PlaySound(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_OpenStream(int nPort, IntPtr pFileHeadBuf, uint nSize, uint nBufPoolSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_InputData(int nPort, IntPtr pBuf, uint nSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_CloseStream(int nPort);

        [DllImport(dllPath)]
        public static extern int PlayM4_GetCaps();

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetFileTime(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetFileTimeEx(int nPort, ref uint pStart, ref uint pStop, ref uint pRev);


        [DllImport(dllPath)]
        public static extern uint PlayM4_GetPlayedTime(int nPort);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetPlayedFrames(int nPort);

        ////////////////ver 2.0 added///////////////////////////////////////
        public delegate void DECCBFUN(int nPort, IntPtr pBuf, int nSize, ref FRAME_INFO pFrameInfo, int nReserved1, int nReserved2);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDecCallBack(int nPort, DECCBFUN DecCBFun);


        public delegate void DISPLAYCBFUN(int nPort, IntPtr pBuf, int nSize, int nWidth, int nHeight, int nStamp, int nType, int nReserved);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDisplayCallBack(int nPort, DISPLAYCBFUN DisplayCBFun);

        [DllImport(dllPath)]
        public static extern bool PLayM4_ConvertToBmpFile(IntPtr pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetFileTotalFrames(int nPort);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetCurrentFrameRate(int nPort);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetPlayedTimeEx(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetPlayedTimeEx(int nPort, uint nTime);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetCurrentFrameNum(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetStreamOpenMode(int nPort, uint nMode);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetFileHeadLength();

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetSdkVersion();

        ////////////////ver 2.2 added///////////////////////////////////////
        [DllImport(dllPath)]
        public static extern uint PlayM4_GetLastError(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_RefreshPlay(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetOverlayMode(int nPort, int bOverlay, uint colorKey);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetPictureSize(int nPort, ref int pWidth, ref int pHeight);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetPicQuality(int nPort, int bHighQuality);

        [DllImport(dllPath)]
        public static extern bool PlayM4_PlaySoundShare(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_StopSoundShare(int nPort);

        ////////////////ver 2.4 added///////////////////////////////////////
        [DllImport(dllPath)]
        public static extern int PlayM4_GetStreamOpenMode(int nPort);

        [DllImport(dllPath)]
        public static extern int PlayM4_GetOverlayMode(int nPort);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetColorKey(int nPort);

        [DllImport(dllPath)]
        public static extern ushort PlayM4_GetVolume(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetPictureQuality(int nPort, ref int bHighQuality);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetSourceBufferRemain(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_ResetSourceBuffer(int nPort);

        public delegate void SOURCEBUFCALLBACKI(int nPort, uint nBufSize, uint dwUser, IntPtr pResvered);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetSourceBufCallBack(int nPort, uint nThreShold, SOURCEBUFCALLBACKI SourceBufCallBack, uint dwUser, IntPtr pReserved);

        [DllImport(dllPath)]
        public static extern bool PlayM4_ResetSourceBufFlag(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDisplayBuf(int nPort, uint nNum);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetDisplayBuf(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_OneByOneBack(int nPort);

        // PLAYM4_API BOOL __stdcall PlayM4_SetFileRefCallBack(LONG nPort, void (__stdcall *pFileRefDone)(DWORD nPort,DWORD nUser),DWORD nUser);
        public delegate void PFILEREFDONE(uint nPort, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetFileRefCallBack(int nPort, PFILEREFDONE pFileRefDone, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetKeyFramePos(int nPort, uint nValue, uint nType, ref FRAME_POS pFramePos);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetNextKeyFramePos(int nPort, uint nValue, uint nType, ref FRAME_POS pFramePos);


        //#if (WINVER >= 0x0400)
        //Note: These funtion must be builded under win2000 or above with Microsoft Platform sdk.
        //	    You can download the sdk from "http://www.microsoft.com/msdownload/platformsdk/sdkupdate/";
        [DllImport(dllPath)]
        public static extern bool PlayM4_InitDDrawDevice();

        [DllImport(dllPath)]
        public static extern void PlayM4_ReleaseDDrawDevice();

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetDDrawDeviceTotalNums();

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDDrawDevice(int nPort, uint nDeviceNum);

        [DllImport(dllPath)]
        public static extern int PlayM4_GetCapsEx(uint nDDrawDeviceNum);

        //#endif
        [DllImport(dllPath)]
        public static extern bool PlayM4_ThrowBFrameNum(int nPort, uint nNum);

        ////////////////ver 2.5 added///////////////////////////////////////
        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDisplayType(int nPort, int nType);

        [DllImport(dllPath)]
        public static extern int PlayM4_GetDisplayType(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDecCBStream(int nPort, uint nStream);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDisplayRegion(int nPort, uint nRegionNum, ref tagRECT pSrcRect, System.IntPtr hDestWnd, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bEnable);

        [DllImport(dllPath)]
        public static extern bool PlayM4_RefreshPlayEx(int nPort, uint nRegionNum);

        //#if (WINVER >= 0x0400)
        //Note: The funtion must be builded under win2000 or above with Microsoft Platform sdk.
        //	    You can download the sdk from http://www.microsoft.com/msdownload/platformsdk/sdkupdate/;
        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDDrawDeviceEx(int nPort, uint nRegionNum, uint nDeviceNum);

        //#endif
        /////////////////v3.2 added/////////////////////////////////////////
        [DllImport(dllPath)]
        public static extern bool PlayM4_GetRefValue(int nPort, ref byte pBuffer, ref uint pSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetRefValue(int nPort, ref byte pBuffer, uint nSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_OpenStreamEx(int nPort, ref byte pFileHeadBuf, uint nSize, uint nBufPoolSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_CloseStreamEx(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_InputVideoData(int nPort, IntPtr pBuf, uint nSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_InputAudioData(int nPort, ref byte pBuf, uint nSize);


        public delegate void DRAWFUN(int nPort, System.IntPtr hDc, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_RigisterDrawFun(int nPort, DRAWFUN DrawFun, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_RegisterDrawFun(int nPort, DRAWFUN DrawFun, int nUser);

        //////////////////v3.4/////////////////////////////////////////////////////
        [DllImport(dllPath)]
        public static extern bool PlayM4_SetTimerType(int nPort, uint nTimerType, uint nReserved);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetTimerType(int nPort, ref uint pTimerType, ref uint pReserved);

        [DllImport(dllPath)]
        public static extern bool PlayM4_ResetBuffer(int nPort, uint nBufType);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetBufferValue(int nPort, uint nBufType);

        //////////////////V3.6/////////////////////////////////////////////////////////
        [DllImport(dllPath)]
        public static extern bool PlayM4_AdjustWaveAudio(int nPort, int nCoefficient);

        public delegate void FUNVERYFY(int nPort, ref FRAME_POS pFilePos, uint bIsVideo, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetVerifyCallBack(int nPort, uint nBeginTime, uint nEndTime, FUNVERYFY funVerify, uint nUser);

        public delegate void FUNAUDIO(int nPort, string pAudioBuf, int nSize, int nStamp, int nType, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetAudioCallBack(int nPort, FUNAUDIO funAudio, int nUser);


        public delegate void FUNENCCHANGE(int nPort, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetEncTypeChangeCallBack(int nPort, FUNENCCHANGE funEncChange, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetColor(int nPort, uint nRegionNum, int nBrightness, int nContrast, int nSaturation, int nHue);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetColor(int nPort, uint nRegionNum, ref int pBrightness, ref int pContrast, ref int pSaturation, ref int pHue);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetEncChangeMsg(int nPort, System.IntPtr hWnd, uint nMsg);

        public delegate void FUNGETORIGNALFRAME(int nPort, ref FRAME_TYPE frameType, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetOriginalFrameCallBack(int nPort, int bIsChange, int bNormalSpeed, int nStartFrameNum, int nStartStamp, int nFileHeader, FUNGETORIGNALFRAME funGetOrignalFrame, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetFileSpecialAttr(int nPort, ref uint pTimeStamp, ref uint pFileNum, ref uint pReserved);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetSpecialData(int nPort);

        public delegate void FUNCHECKWATERMARK(int nPort, ref WATERMARK_INFO pWatermarkInfo, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetCheckWatermarkCallBack(int nPort, FUNCHECKWATERMARK funCheckWatermark, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetImageSharpen(int nPort, uint nLevel);

        public delegate void FUNTHROWBFRAME(int nPort, uint nBFrame, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetThrowBFrameCallBack(int nPort, FUNTHROWBFRAME funThrowBFrame, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDecodeFrameType(int nPort, uint nFrameType);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetPlayMode(int nPort, int bNormal);

        public delegate void FUNGETUSERDATA(int nPort, ref byte pUserBuf, uint nBufLen, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetGetUserDataCallBack(int nPort, FUNGETUSERDATA funGetUserData, uint nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetOverlayFlipMode(int nPort, int bTrue);

        [DllImport(dllPath)]
        public static extern uint PlayM4_GetAbsFrameNum(int nPort);

        //////////////////V4.7.0.0//////////////////////////////////////////////////////
        ////convert yuv to jpeg
        [DllImport(dllPath)]
        public static extern bool PlayM4_ConvertToJpegFile(IntPtr pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetJpegQuality(int nQuality);

        //set deflash
        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDeflash(int nPort, int bDefalsh);

        //////////////////V4.8.0.0/////////////////////////////////////////////////////////
        //check discontinuous frame number as error data?
        [DllImport(dllPath)]
        public static extern bool PlayM4_CheckDiscontinuousFrameNum(int nPort, int bCheck);

        //get bmp or jpeg
        [DllImport(dllPath)]
        public static extern bool PlayM4_GetBMP(int nPort, byte[] pBitmap, uint nBufSize, ref uint pBmpSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_GetJPEG(int nPort, IntPtr pJpeg, uint nBufSize, ref uint pJpegSize);

        //dec call back mend
        //public delegate void DECCBFUN(int nPort, string pBuf, int nSize, ref FRAME_INFO pFrameInfo, int nUser, int nReserved2);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDecCallBackMend(int nPort, DECCBFUN DecCBFun, int nUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetSecretKey(int nPort, int lKeyType, string pSecretKey, int lKeyLen);

        // add by gb 2007-12-23
        public delegate void FILEENDCALLBACK(int nPort, System.IntPtr pUser);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetFileEndCallback(int nPort, FILEENDCALLBACK FileEndCallback, IntPtr pUser);

        // add by gb 080131 version 4.9.0.1
        [DllImport(dllPath)]
        public static extern bool PlayM4_GetPort(ref int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_FreePort(int nPort);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SyncToAudio(int nPort, int bSyncToAudio);

        //public delegate void Anonymous_b532dad6_7470_4b10_9638_c82a363cd853(int nPort, System.IntPtr pBuf, int nSize, ref FRAME_INFO pFrameInfo, int nReserved1, int nReserved2);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetDecCallBackEx(int nPort, DECCBFUN DecCBFun, IntPtr pDest, int nDestSize);

        [DllImport(dllPath)]
        public static extern bool PlayM4_RenderPrivateData(int nPort, int nIntelType, bool bTrue);

        [DllImport(dllPath)]
        public static extern bool PlayM4_RenderPrivateDataEx(int nPort, int nIntelType, int nSubType, bool bTrue);

        [DllImport(dllPath)]
        public static extern bool PlayM4_SetOverlayPriInfoFlag(int nPort, int nIntelType, bool bTrue);
    }
}
