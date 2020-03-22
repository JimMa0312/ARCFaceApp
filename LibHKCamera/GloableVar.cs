using System;
using System.Collections.Generic;
using System.Text;

namespace LibHKCamera
{
    public static class GloableVar
    {
        public const int NAME_LEN = 32;   //用户名长度
        public const int PASSWD_LEN = 16;   //密码长度
        public const int GUID_LEN = 16; //GUID长度
        public const int DEV_TYPE_NAME_LEN = 24;      //设备类型名称长度
        public const int MAX_NAMELEN = 16;//DVR本地登陆名
        public const int MAX_RIGHT = 32;//设备支持的权限（1-12表示本地权限，13-32表示远程权限）
        public const int SERIALNO_LEN = 48;//序列号长度
        public const int MACADDR_LEN = 6;//mac地址长度
        public const int MAX_ETHERNET = 2;//设备可配以太网络
        public const int MAX_NETWORK_CARD = 4; //设备可配最大网卡数目
        public const int PATHNAME_LEN = 128;//路径长度

        public const int MAX_NUMBER_LEN = 32;	//号码最大长度
        public const int MAX_NAME_LEN = 128; //设备名称最大长度

        public const int MAX_TIMESEGMENT_V30 = 8;//9000设备最大时间段数
        public const int MAX_TIMESEGMENT = 4;//8000设备最大时间段数
        public const int MAX_ICR_NUM = 8;   //抓拍机红外滤光片预置点数

        public const int MAX_SHELTERNUM = 4;//8000设备最大遮挡区域数
        public const int PHONENUMBER_LEN = 32;//pppoe拨号号码最大长度

        public const int MAX_DISKNUM = 16;//8000设备最大硬盘数
        public const int MAX_DISKNUM_V10 = 8;//1.2版本之前版本

        public const int MAX_WINDOW_V30 = 32;//9000设备本地显示最大播放窗口数
        public const int MAX_WINDOW = 16;//8000设备最大硬盘数
        public const int MAX_VGA_V30 = 4;//9000设备最大可接VGA数
        public const int MAX_VGA = 1;//8000设备最大可接VGA数

        public const int MAX_USERNUM_V30 = 32;//9000设备最大用户数
        public const int MAX_USERNUM = 16;//8000设备最大用户数
        public const int MAX_EXCEPTIONNUM_V30 = 32;//9000设备最大异常处理数
        public const int MAX_EXCEPTIONNUM = 16;//8000设备最大异常处理数
        public const int MAX_LINK = 6;//8000设备单通道最大视频流连接数
        public const int MAX_ITC_EXCEPTIONOUT = 32;//抓拍机最大报警输出

        public const int MAX_DECPOOLNUM = 4;//单路解码器每个解码通道最大可循环解码数
        public const int MAX_DECNUM = 4;//单路解码器的最大解码通道数（实际只有一个，其他三个保留）
        public const int MAX_TRANSPARENTNUM = 2;//单路解码器可配置最大透明通道数
        public const int MAX_CYCLE_CHAN = 16; //单路解码器最大轮循通道数
        public const int MAX_CYCLE_CHAN_V30 = 64;//最大轮询通道数（扩展）
        public const int MAX_DIRNAME_LENGTH = 80;//最大目录长度

        public const int MAX_STRINGNUM_V30 = 8;//9000设备最大OSD字符行数数
        public const int MAX_STRINGNUM = 4;//8000设备最大OSD字符行数数
        public const int MAX_STRINGNUM_EX = 8;//8000定制扩展
        public const int MAX_AUXOUT_V30 = 16;//9000设备最大辅助输出数
        public const int MAX_AUXOUT = 4;//8000设备最大辅助输出数
        public const int MAX_HD_GROUP = 16;//9000设备最大硬盘组数
        public const int MAX_NFS_DISK = 8; //8000设备最大NFS硬盘数

        public const int IW_ESSID_MAX_SIZE = 32;//WIFI的SSID号长度
        public const int IW_ENCODING_TOKEN_MAX = 32;//WIFI密锁最大字节数
        public const int WIFI_WEP_MAX_KEY_COUNT = 4;
        public const int WIFI_WEP_MAX_KEY_LENGTH = 33;
        public const int WIFI_WPA_PSK_MAX_KEY_LENGTH = 63;
        public const int WIFI_WPA_PSK_MIN_KEY_LENGTH = 8;
        public const int WIFI_MAX_AP_COUNT = 20;
        public const int MAX_SERIAL_NUM = 64;//最多支持的透明通道路数
        public const int MAX_DDNS_NUMS = 10;//9000设备最大可配ddns数
        public const int MAX_EMAIL_ADDR_LEN = 48;//最大email地址长度
        public const int MAX_EMAIL_PWD_LEN = 32;//最大email密码长度

        public const int MAXPROGRESS = 100;//回放时的最大百分率
        public const int MAX_SERIALNUM = 2;//8000设备支持的串口数 1-232， 2-485
        public const int CARDNUM_LEN = 20;//卡号长度
        public const int CARDNUM_LEN_OUT = 32; //外部结构体卡号长度
        public const int MAX_VIDEOOUT_V30 = 4;//9000设备的视频输出数
        public const int MAX_VIDEOOUT = 2;//8000设备的视频输出数

        public const int MAX_PRESET_V30 = 256;// 9000设备支持的云台预置点数
        public const int MAX_TRACK_V30 = 256;// 9000设备支持的云台轨迹数
        public const int MAX_CRUISE_V30 = 256;// 9000设备支持的云台巡航数
        public const int MAX_PRESET = 128;// 8000设备支持的云台预置点数 
        public const int MAX_TRACK = 128;// 8000设备支持的云台轨迹数
        public const int MAX_CRUISE = 128;// 8000设备支持的云台巡航数 

        public const int CRUISE_MAX_PRESET_NUMS = 32;// 一条巡航最多的巡航点 

        public const int MAX_SERIAL_PORT = 8;//9000设备支持232串口数
        public const int MAX_PREVIEW_MODE = 8;// 设备支持最大预览模式数目 1画面,4画面,9画面,16画面.... 
        public const int MAX_MATRIXOUT = 16;// 最大模拟矩阵输出个数 
        public const int LOG_INFO_LEN = 11840; // 日志附加信息 
        public const int DESC_LEN = 16;// 云台描述字符串长度 
        public const int PTZ_PROTOCOL_NUM = 200;// 9000最大支持的云台协议数 

        public const int MAX_AUDIO = 1;//8000语音对讲通道数
        public const int MAX_AUDIO_V30 = 2;//9000语音对讲通道数
        public const int MAX_CHANNUM = 16;//8000设备最大通道数
        public const int MAX_ALARMIN = 16;//8000设备最大报警输入数
        public const int MAX_ALARMOUT = 4;//8000设备最大报警输出数
        //9000 IPC接入
        public const int MAX_ANALOG_CHANNUM = 32;//最大32个模拟通道
        public const int MAX_ANALOG_ALARMOUT = 32; //最大32路模拟报警输出 
        public const int MAX_ANALOG_ALARMIN = 32;//最大32路模拟报警输入

        public const int MAX_IP_DEVICE = 32;//允许接入的最大IP设备数
        public const int MAX_IP_DEVICE_V40 = 64;//允许接入的最大IP设备数
        public const int MAX_IP_CHANNEL = 32;//允许加入的最多IP通道数
        public const int MAX_IP_ALARMIN = 128;//允许加入的最多报警输入数
        public const int MAX_IP_ALARMOUT = 64;//允许加入的最多报警输出数
        public const int MAX_IP_ALARMIN_V40 = 4096;    //允许加入的最多报警输入数
        public const int MAX_IP_ALARMOUT_V40 = 4096;    //允许加入的最多报警输出数

        public const int MAX_RECORD_FILE_NUM = 20;      // 每次删除或者刻录的最大文件数

        //SDK_V31 ATM
        public const int MAX_ATM_NUM = 1;
        public const int MAX_ACTION_TYPE = 12;
        public const int ATM_FRAMETYPE_NUM = 4;
        public const int MAX_ATM_PROTOCOL_NUM = 1025;
        public const int ATM_PROTOCOL_SORT = 4;
        public const int ATM_DESC_LEN = 32;
        // SDK_V31 ATM

        /* 最大支持的通道数 最大模拟加上最大IP支持 */
        public const int MAX_CHANNUM_V30 = MAX_ANALOG_CHANNUM + MAX_IP_CHANNEL;//64
        public const int MAX_ALARMOUT_V30 = MAX_ANALOG_ALARMOUT + MAX_IP_ALARMOUT;//96
        public const int MAX_ALARMIN_V30 = MAX_ANALOG_ALARMIN + MAX_IP_ALARMIN;//160

        public const int MAX_CHANNUM_V40 = 512;
        public const int MAX_ALARMOUT_V40 = MAX_IP_ALARMOUT_V40 + MAX_ANALOG_ALARMOUT;//4128
        public const int MAX_ALARMIN_V40 = MAX_IP_ALARMIN_V40 + MAX_ANALOG_ALARMOUT;//4128
        public const int MAX_MULTI_AREA_NUM = 24;

        public const int MAX_HUMAN_PICTURE_NUM = 10;   //最大照片数
        public const int MAX_HUMAN_BIRTHDATE_LEN = 10;

        public const int MAX_LAYERNUMS = 32;

        public const int MAX_ROIDETECT_NUM = 8;    //支持的ROI区域数
        public const int MAX_LANERECT_NUM = 5;    //最大车牌识别区域数
        public const int MAX_FORTIFY_NUM = 10;   //最大布防个数
        public const int MAX_INTERVAL_NUM = 4;    //最大时间间隔个数
        public const int MAX_CHJC_NUM = 3;    //最大车辆省份简称字符个数
        public const int MAX_VL_NUM = 5;    //最大虚拟线圈个数
        public const int MAX_DRIVECHAN_NUM = 16;   //最大车道数
        public const int MAX_COIL_NUM = 3;    //最大线圈个数
        public const int MAX_SIGNALLIGHT_NUM = 6;   //最大信号灯个数
        public const int LEN_32 = 32;
        public const int LEN_31 = 31;
        public const int MAX_CABINET_COUNT = 8;    //最大支持机柜数量
        public const int MAX_ID_LEN = 48;
        public const int MAX_PARKNO_LEN = 16;
        public const int MAX_ALARMREASON_LEN = 32;
        public const int MAX_UPGRADE_INFO_LEN = 48; //获取升级文件匹配信息(模糊升级)
        public const int MAX_CUSTOMDIR_LEN = 32; //自定义目录长度

        public const int MAX_TRANSPARENT_CHAN_NUM = 4;   //每个串口允许建立的最大透明通道数
        public const int MAX_TRANSPARENT_ACCESS_NUM = 4;   //每个监听端口允许接入的最大主机数

        //ITS
        public const int MAX_PARKING_STATUS = 8;    //车位状态 0代表无车，1代表有车，2代表压线(优先级最高), 3特殊车位 
        public const int MAX_PARKING_NUM = 4;    //一个通道最大4个车位 (从左到右车位 数组0～3)

        public const int MAX_ITS_SCENE_NUM = 16;   //最大场景数量
        public const int MAX_SCENE_TIMESEG_NUM = 16;   //最大场景时间段数量
        public const int MAX_IVMS_IP_CHANNEL = 128;  //最大IP通道数
        public const int DEVICE_ID_LEN = 48;   //设备编号长度
        public const int MONITORSITE_ID_LEN = 48;   //监测点编号长度
        public const int MAX_AUXAREA_NUM = 16;   //辅助区域最大数目
        public const int MAX_SLAVE_CHANNEL_NUM = 16;   //最大从通道数量

        public const int MAX_SCH_TASKS_NUM = 10;

        public const int MAX_SERVERID_LEN = 64; //最大服务器ID的长度
        public const int MAX_SERVERDOMAIN_LEN = 128; //服务器域名最大长度
        public const int MAX_AUTHENTICATEID_LEN = 64; //认证ID最大长度
        public const int MAX_AUTHENTICATEPASSWD_LEN = 32; //认证密码最大长度
        public const int MAX_SERVERNAME_LEN = 64; //最大服务器用户名 
        public const int MAX_COMPRESSIONID_LEN = 64; //编码ID的最大长度
        public const int MAX_SIPSERVER_ADDRESS_LEN = 128; //SIP服务器地址支持域名和IP地址
        //压线报警
        public const int MAX_PlATE_NO_LEN = 32;   //车牌号码最大长度 2013-09-27
        public const int UPNP_PORT_NUM = 12;      //upnp端口映射端口数目


        public const int MAX_LOCAL_ADDR_LEN = 96;		//SOCKS最大本地网段个数
        public const int MAX_COUNTRY_NAME_LEN = 4;		//国家简写名称长度

        public const int THERMOMETRY_ALARMRULE_NUM = 40; //热成像报警规则数

        public const int ACS_CARD_NO_LEN = 32; //门禁卡号长度    
        public const int MAX_ID_NUM_LEN = 32;  //最大身份证号长度
        public const int MAX_ID_NAME_LEN = 128;   //最大姓名长度
        public const int MAX_ID_ADDR_LEN = 280;   //最大住址长度
        public const int MAX_ID_ISSUING_AUTHORITY_LEN = 128; //最大签发机关长度

        public const int MAX_CARD_RIGHT_PLAN_NUM = 4;   //卡权限最大计划个数
        public const int MAX_GROUP_NUM_128 = 128; //最大群组数
        public const int MAX_CARD_READER_NUM = 64;  //最大读卡器数
        public const int MAX_SNEAK_PATH_NODE = 8;   //最大后续读卡器数
        public const int MAX_MULTI_DOOR_INTERLOCK_GROUP = 8;   //最大多门互锁组数
        public const int MAX_INTER_LOCK_DOOR_NUM = 8;   //一个多门互锁组中最大互锁门数
        public const int MAX_CASE_SENSOR_NUM = 8;  //最大case sensor触发器数
        public const int MAX_DOOR_NUM_256 = 256; //最大门数
        public const int MAX_READER_ROUTE_NUM = 16;  //最大刷卡循序路径 
        public const int MAX_FINGER_PRINT_NUM = 10;  //最大指纹个数
        public const int MAX_CARD_READER_NUM_512 = 512; //最大读卡器数
        public const int NET_SDK_MULTI_CARD_GROUP_NUM_20 = 20;   //单门最大多重卡组数
        public const int CARD_PASSWORD_LEN = 8;   //卡密码长度
        public const int MAX_DOOR_CODE_LEN = 8; //房间代码长度
        public const int MAX_LOCK_CODE_LEN = 8; //锁代码长度

        public const int MAX_NOTICE_NUMBER_LEN = 32;   //公告编号最大长度
        public const int MAX_NOTICE_THEME_LEN = 64;   //公告主题最大长度
        public const int MAX_NOTICE_DETAIL_LEN = 1024; //公告详情最大长度
        public const int MAX_NOTICE_PIC_NUM = 6;    //公告信息最大图片数量
        public const int MAX_DEV_NUMBER_LEN = 32;   //设备编号最大长度
        public const int LOCK_NAME_LEN = 32;  //锁名称

        public const int NET_SDK_EMPLOYEE_NO_LEN = 32;  //工号长度

        public const int VCA_MAX_POLYGON_POINT_NUM = 10;//检测区域最多支持10个点的多边形
        public const int MAX_RULE_NUM = 8;//最多规则条数
        public const int MAX_TARGET_NUM = 30;//最多目标个数
        public const int MAX_CALIB_PT = 6;//最大标定点个数
        public const int MIN_CALIB_PT = 4;//最小标定点个数
        public const int MAX_TIMESEGMENT_2 = 2;//最大时间段数
        public const int MAX_LICENSE_LEN = 16;//车牌号最大长度
        public const int MAX_PLATE_NUM = 3;//车牌个数
        public const int MAX_MASK_REGION_NUM = 4;//最多四个屏蔽区域
        public const int MAX_SEGMENT_NUM = 6;//摄像机标定最大样本线数目
        public const int MIN_SEGMENT_NUM = 3;//摄像机标定最小样本线数目  
        public const int MAX_CATEGORY_LEN = 8;       //车牌附加信息最大字符
        public const int SERIAL_NO_LEN = 16;      //泊车位编号

        //码流连接方式
        public const int NORMALCONNECT = 1;
        public const int MEDIACONNECT = 2;

        //设备型号(大类)
        public const int HCDVR = 1;
        public const int MEDVR = 2;
        public const int PCDVR = 3;
        public const int HC_9000 = 4;
        public const int HF_I = 5;
        public const int PCNVR = 6;
        public const int HC_76NVR = 8;

        //NVR类型
        public const int DS8000HC_NVR = 0;
        public const int DS9000HC_NVR = 1;
        public const int DS8000ME_NVR = 2;

        /*******************全局错误码 begin**********************/
        public const int NET_DVR_NOERROR = 0;//没有错误
        public const int NET_DVR_PASSWORD_ERROR = 1;//用户名密码错误
        public const int NET_DVR_NOENOUGHPRI = 2;//权限不足
        public const int NET_DVR_NOINIT = 3;//没有初始化
        public const int NET_DVR_CHANNEL_ERROR = 4;//通道号错误
        public const int NET_DVR_OVER_MAXLINK = 5;//连接到DVR的客户端个数超过最大
        public const int NET_DVR_VERSIONNOMATCH = 6;//版本不匹配
        public const int NET_DVR_NETWORK_FAIL_CONNECT = 7;//连接服务器失败
        public const int NET_DVR_NETWORK_SEND_ERROR = 8;//向服务器发送失败
        public const int NET_DVR_NETWORK_RECV_ERROR = 9;//从服务器接收数据失败
        public const int NET_DVR_NETWORK_RECV_TIMEOUT = 10;//从服务器接收数据超时
        public const int NET_DVR_NETWORK_ERRORDATA = 11;//传送的数据有误
        public const int NET_DVR_ORDER_ERROR = 12;//调用次序错误
        public const int NET_DVR_OPERNOPERMIT = 13;//无此权限
        public const int NET_DVR_COMMANDTIMEOUT = 14;//DVR命令执行超时
        public const int NET_DVR_ERRORSERIALPORT = 15;//串口号错误
        public const int NET_DVR_ERRORALARMPORT = 16;//报警端口错误
        public const int NET_DVR_PARAMETER_ERROR = 17;//参数错误
        public const int NET_DVR_CHAN_EXCEPTION = 18;//服务器通道处于错误状态
        public const int NET_DVR_NODISK = 19;//没有硬盘
        public const int NET_DVR_ERRORDISKNUM = 20;//硬盘号错误
        public const int NET_DVR_DISK_FULL = 21;//服务器硬盘满
        public const int NET_DVR_DISK_ERROR = 22;//服务器硬盘出错
        public const int NET_DVR_NOSUPPORT = 23;//服务器不支持
        public const int NET_DVR_BUSY = 24;//服务器忙
        public const int NET_DVR_MODIFY_FAIL = 25;//服务器修改不成功
        public const int NET_DVR_PASSWORD_FORMAT_ERROR = 26;//密码输入格式不正确
        public const int NET_DVR_DISK_FORMATING = 27;//硬盘正在格式化，不能启动操作
        public const int NET_DVR_DVRNORESOURCE = 28;//DVR资源不足
        public const int NET_DVR_DVROPRATEFAILED = 29;//DVR操作失败
        public const int NET_DVR_OPENHOSTSOUND_FAIL = 30;//打开PC声音失败
        public const int NET_DVR_DVRVOICEOPENED = 31;//服务器语音对讲被占用
        public const int NET_DVR_TIMEINPUTERROR = 32;//时间输入不正确
        public const int NET_DVR_NOSPECFILE = 33;//回放时服务器没有指定的文件
        public const int NET_DVR_CREATEFILE_ERROR = 34;//创建文件出错
        public const int NET_DVR_FILEOPENFAIL = 35;//打开文件出错
        public const int NET_DVR_OPERNOTFINISH = 36; //上次的操作还没有完成
        public const int NET_DVR_GETPLAYTIMEFAIL = 37;//获取当前播放的时间出错
        public const int NET_DVR_PLAYFAIL = 38;//播放出错
        public const int NET_DVR_FILEFORMAT_ERROR = 39;//文件格式不正确
        public const int NET_DVR_DIR_ERROR = 40;//路径错误
        public const int NET_DVR_ALLOC_RESOURCE_ERROR = 41;//资源分配错误
        public const int NET_DVR_AUDIO_MODE_ERROR = 42;//声卡模式错误
        public const int NET_DVR_NOENOUGH_BUF = 43;//缓冲区太小
        public const int NET_DVR_CREATESOCKET_ERROR = 44;//创建SOCKET出错
        public const int NET_DVR_SETSOCKET_ERROR = 45;//设置SOCKET出错
        public const int NET_DVR_MAX_NUM = 46;//个数达到最大
        public const int NET_DVR_USERNOTEXIST = 47;//用户不存在
        public const int NET_DVR_WRITEFLASHERROR = 48;//写FLASH出错
        public const int NET_DVR_UPGRADEFAIL = 49;//DVR升级失败
        public const int NET_DVR_CARDHAVEINIT = 50;//解码卡已经初始化过
        public const int NET_DVR_PLAYERFAILED = 51;//调用播放库中某个函数失败
        public const int NET_DVR_MAX_USERNUM = 52;//设备端用户数达到最大
        public const int NET_DVR_GETLOCALIPANDMACFAIL = 53;//获得客户端的IP地址或物理地址失败
        public const int NET_DVR_NOENCODEING = 54;//该通道没有编码
        public const int NET_DVR_IPMISMATCH = 55;//IP地址不匹配
        public const int NET_DVR_MACMISMATCH = 56;//MAC地址不匹配
        public const int NET_DVR_UPGRADELANGMISMATCH = 57;//升级文件语言不匹配
        public const int NET_DVR_MAX_PLAYERPORT = 58;//播放器路数达到最大
        public const int NET_DVR_NOSPACEBACKUP = 59;//备份设备中没有足够空间进行备份
        public const int NET_DVR_NODEVICEBACKUP = 60;//没有找到指定的备份设备
        public const int NET_DVR_PICTURE_BITS_ERROR = 61;//图像素位数不符，限24色
        public const int NET_DVR_PICTURE_DIMENSION_ERROR = 62;//图片高*宽超限， 限128*256
        public const int NET_DVR_PICTURE_SIZ_ERROR = 63;//图片大小超限，限100K
        public const int NET_DVR_LOADPLAYERSDKFAILED = 64;//载入当前目录下Player Sdk出错
        public const int NET_DVR_LOADPLAYERSDKPROC_ERROR = 65;//找不到Player Sdk中某个函数入口
        public const int NET_DVR_LOADDSSDKFAILED = 66;//载入当前目录下DSsdk出错
        public const int NET_DVR_LOADDSSDKPROC_ERROR = 67;//找不到DsSdk中某个函数入口
        public const int NET_DVR_DSSDK_ERROR = 68;//调用硬解码库DsSdk中某个函数失败
        public const int NET_DVR_VOICEMONOPOLIZE = 69;//声卡被独占
        public const int NET_DVR_JOINMULTICASTFAILED = 70;//加入多播组失败
        public const int NET_DVR_CREATEDIR_ERROR = 71;//建立日志文件目录失败
        public const int NET_DVR_BINDSOCKET_ERROR = 72;//绑定套接字失败
        public const int NET_DVR_SOCKETCLOSE_ERROR = 73;//socket连接中断，此错误通常是由于连接中断或目的地不可达
        public const int NET_DVR_USERID_ISUSING = 74;//注销时用户ID正在进行某操作
        public const int NET_DVR_SOCKETLISTEN_ERROR = 75;//监听失败
        public const int NET_DVR_PROGRAM_EXCEPTION = 76;//程序异常
        public const int NET_DVR_WRITEFILE_FAILED = 77;//写文件失败
        public const int NET_DVR_FORMAT_READONLY = 78;//禁止格式化只读硬盘
        public const int NET_DVR_WITHSAMEUSERNAME = 79;//用户配置结构中存在相同的用户名
        public const int NET_DVR_DEVICETYPE_ERROR = 80;//导入参数时设备型号不匹配
        public const int NET_DVR_LANGUAGE_ERROR = 81;//导入参数时语言不匹配
        public const int NET_DVR_PARAVERSION_ERROR = 82;//导入参数时软件版本不匹配
        public const int NET_DVR_IPCHAN_NOTALIVE = 83; //预览时外接IP通道不在线
        public const int NET_DVR_RTSP_SDK_ERROR = 84;//加载高清IPC通讯库StreamTransClient.dll失败
        public const int NET_DVR_CONVERT_SDK_ERROR = 85;//加载转码库失败
        public const int NET_DVR_IPC_COUNT_OVERFLOW = 86;//超出最大的ip接入通道数

        public const int NET_PLAYM4_NOERROR = 500;//no error
        public const int NET_PLAYM4_PARA_OVER = 501;//input parameter is invalid
        public const int NET_PLAYM4_ORDER_ERROR = 502;//The order of the function to be called is error
        public const int NET_PLAYM4_TIMER_ERROR = 503;//Create multimedia clock failed
        public const int NET_PLAYM4_DEC_VIDEO_ERROR = 504;//Decode video data failed
        public const int NET_PLAYM4_DEC_AUDIO_ERROR = 505;//Decode audio data failed
        public const int NET_PLAYM4_ALLOC_MEMORY_ERROR = 506;//Allocate memory failed
        public const int NET_PLAYM4_OPEN_FILE_ERROR = 507;//Open the file failed
        public const int NET_PLAYM4_CREATE_OBJ_ERROR = 508;//Create thread or event failed
        public const int NET_PLAYM4_CREATE_DDRAW_ERROR = 509;//Create DirectDraw object failed
        public const int NET_PLAYM4_CREATE_OFFSCREEN_ERROR = 510;//failed when creating off-screen surface
        public const int NET_PLAYM4_BUF_OVER = 511;//buffer is overflow
        public const int NET_PLAYM4_CREATE_SOUND_ERROR = 512;//failed when creating audio device
        public const int NET_PLAYM4_SET_VOLUME_ERROR = 513;//Set volume failed
        public const int NET_PLAYM4_SUPPORT_FILE_ONLY = 514;//The function only support play file
        public const int NET_PLAYM4_SUPPORT_STREAM_ONLY = 515;//The function only support play stream
        public const int NET_PLAYM4_SYS_NOT_SUPPORT = 516;//System not support
        public const int NET_PLAYM4_FILEHEADER_UNKNOWN = 517;//No file header
        public const int NET_PLAYM4_VERSION_INCORRECT = 518;//The version of decoder and encoder is not adapted
        public const int NET_PALYM4_INIT_DECODER_ERROR = 519;//Initialize decoder failed
        public const int NET_PLAYM4_CHECK_FILE_ERROR = 520;//The file data is unknown
        public const int NET_PLAYM4_INIT_TIMER_ERROR = 521;//Initialize multimedia clock failed
        public const int NET_PLAYM4_BLT_ERROR = 522;//Blt failed
        public const int NET_PLAYM4_UPDATE_ERROR = 523;//Update failed
        public const int NET_PLAYM4_OPEN_FILE_ERROR_MULTI = 524;//openfile error, streamtype is multi
        public const int NET_PLAYM4_OPEN_FILE_ERROR_VIDEO = 525;//openfile error, streamtype is video
        public const int NET_PLAYM4_JPEG_COMPRESS_ERROR = 526;//JPEG compress error
        public const int NET_PLAYM4_EXTRACT_NOT_SUPPORT = 527;//Don't support the version of this file
        public const int NET_PLAYM4_EXTRACT_DATA_ERROR = 528;//extract video data failed
        /*******************全局错误码 end**********************/

        /*************************************************
        NET_DVR_IsSupport()返回值
        1－9位分别表示以下信息（位与是TRUE)表示支持；
        **************************************************/
        public const int NET_DVR_SUPPORT_DDRAW = 1;//支持DIRECTDRAW，如果不支持，则播放器不能工作
        public const int NET_DVR_SUPPORT_BLT = 2;//显卡支持BLT操作，如果不支持，则播放器不能工作
        public const int NET_DVR_SUPPORT_BLTFOURCC = 4;//显卡BLT支持颜色转换，如果不支持，播放器会用软件方法作RGB转换
        public const int NET_DVR_SUPPORT_BLTSHRINKX = 8;//显卡BLT支持X轴缩小；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_BLTSHRINKY = 16;//显卡BLT支持Y轴缩小；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_BLTSTRETCHX = 32;//显卡BLT支持X轴放大；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_BLTSTRETCHY = 64;//显卡BLT支持Y轴放大；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_SSE = 128;//CPU支持SSE指令，Intel Pentium3以上支持SSE指令
        public const int NET_DVR_SUPPORT_MMX = 256;//CPU支持MMX指令集，Intel Pentium3以上支持SSE指令

        /**********************云台控制命令 begin*************************/
        public const int LIGHT_PWRON = 2;// 接通灯光电源
        public const int WIPER_PWRON = 3;// 接通雨刷开关 
        public const int FAN_PWRON = 4;// 接通风扇开关
        public const int HEATER_PWRON = 5;// 接通加热器开关
        public const int AUX_PWRON1 = 6;// 接通辅助设备开关
        public const int AUX_PWRON2 = 7;// 接通辅助设备开关 
        public const int SET_PRESET = 8;// 设置预置点 
        public const int CLE_PRESET = 9;// 清除预置点 

        public const int ZOOM_IN = 11;// 焦距以速度SS变大(倍率变大)
        public const int ZOOM_OUT = 12;// 焦距以速度SS变小(倍率变小)
        public const int FOCUS_NEAR = 13;// 焦点以速度SS前调 
        public const int FOCUS_FAR = 14;// 焦点以速度SS后调
        public const int IRIS_OPEN = 15;// 光圈以速度SS扩大
        public const int IRIS_CLOSE = 16;// 光圈以速度SS缩小 

        public const int TILT_UP = 21;/* 云台以SS的速度上仰 */
        public const int TILT_DOWN = 22;/* 云台以SS的速度下俯 */
        public const int PAN_LEFT = 23;/* 云台以SS的速度左转 */
        public const int PAN_RIGHT = 24;/* 云台以SS的速度右转 */
        public const int UP_LEFT = 25;/* 云台以SS的速度上仰和左转 */
        public const int UP_RIGHT = 26;/* 云台以SS的速度上仰和右转 */
        public const int DOWN_LEFT = 27;/* 云台以SS的速度下俯和左转 */
        public const int DOWN_RIGHT = 28;/* 云台以SS的速度下俯和右转 */
        public const int PAN_AUTO = 29;/* 云台以SS的速度左右自动扫描 */

        public const int FILL_PRE_SEQ = 30;/* 将预置点加入巡航序列 */
        public const int SET_SEQ_DWELL = 31;/* 设置巡航点停顿时间 */
        public const int SET_SEQ_SPEED = 32;/* 设置巡航速度 */
        public const int CLE_PRE_SEQ = 33;/* 将预置点从巡航序列中删除 */
        public const int STA_MEM_CRUISE = 34;/* 开始记录轨迹 */
        public const int STO_MEM_CRUISE = 35;/* 停止记录轨迹 */
        public const int RUN_CRUISE = 36;/* 开始轨迹 */
        public const int RUN_SEQ = 37;/* 开始巡航 */
        public const int STOP_SEQ = 38;/* 停止巡航 */
        public const int GOTO_PRESET = 39;/* 快球转到预置点 */
        /**********************云台控制命令 end*************************/

        /*************************************************
        回放时播放控制命令宏定义 
        NET_DVR_PlayBackControl
        NET_DVR_PlayControlLocDisplay
        NET_DVR_DecPlayBackCtrl的宏定义
        具体支持查看函数说明和代码
        **************************************************/
        public const int NET_DVR_PLAYSTART = 1;//开始播放
        public const int NET_DVR_PLAYSTOP = 2;//停止播放
        public const int NET_DVR_PLAYPAUSE = 3;//暂停播放
        public const int NET_DVR_PLAYRESTART = 4;//恢复播放
        public const int NET_DVR_PLAYFAST = 5;//快放
        public const int NET_DVR_PLAYSLOW = 6;//慢放
        public const int NET_DVR_PLAYNORMAL = 7;//正常速度
        public const int NET_DVR_PLAYFRAME = 8;//单帧放
        public const int NET_DVR_PLAYSTARTAUDIO = 9;//打开声音
        public const int NET_DVR_PLAYSTOPAUDIO = 10;//关闭声音
        public const int NET_DVR_PLAYAUDIOVOLUME = 11;//调节音量
        public const int NET_DVR_PLAYSETPOS = 12;//改变文件回放的进度
        public const int NET_DVR_PLAYGETPOS = 13;//获取文件回放的进度
        public const int NET_DVR_PLAYGETTIME = 14;//获取当前已经播放的时间(按文件回放的时候有效)
        public const int NET_DVR_PLAYGETFRAME = 15;//获取当前已经播放的帧数(按文件回放的时候有效)
        public const int NET_DVR_GETTOTALFRAMES = 16;//获取当前播放文件总的帧数(按文件回放的时候有效)
        public const int NET_DVR_GETTOTALTIME = 17;//获取当前播放文件总的时间(按文件回放的时候有效)
        public const int NET_DVR_THROWBFRAME = 20;//丢B帧
        public const int NET_DVR_SETSPEED = 24;//设置码流速度
        public const int NET_DVR_KEEPALIVE = 25;//保持与设备的心跳(如果回调阻塞，建议2秒发送一次)
        public const int NET_DVR_PLAYSETTIME = 26;//按绝对时间定位
        public const int NET_DVR_PLAYGETTOTALLEN = 27;//获取按时间回放对应时间段内的所有文件的总长度
        public const int NET_DVR_PLAY_FORWARD = 29;//倒放切换为正放
        public const int NET_DVR_PLAY_REVERSE = 30;//正放切换为倒放
        public const int NET_DVR_SET_TRANS_TYPE = 32;//设置转封装类型
        public const int NET_DVR_PLAY_CONVERT = 33;//正放切换为倒放

        //远程按键定义如下：
        /* key value send to CONFIG program */
        public const int KEY_CODE_1 = 1;
        public const int KEY_CODE_2 = 2;
        public const int KEY_CODE_3 = 3;
        public const int KEY_CODE_4 = 4;
        public const int KEY_CODE_5 = 5;
        public const int KEY_CODE_6 = 6;
        public const int KEY_CODE_7 = 7;
        public const int KEY_CODE_8 = 8;
        public const int KEY_CODE_9 = 9;
        public const int KEY_CODE_0 = 10;
        public const int KEY_CODE_POWER = 11;
        public const int KEY_CODE_MENU = 12;
        public const int KEY_CODE_ENTER = 13;
        public const int KEY_CODE_CANCEL = 14;
        public const int KEY_CODE_UP = 15;
        public const int KEY_CODE_DOWN = 16;
        public const int KEY_CODE_LEFT = 17;
        public const int KEY_CODE_RIGHT = 18;
        public const int KEY_CODE_EDIT = 19;
        public const int KEY_CODE_ADD = 20;
        public const int KEY_CODE_MINUS = 21;
        public const int KEY_CODE_PLAY = 22;
        public const int KEY_CODE_REC = 23;
        public const int KEY_CODE_PAN = 24;
        public const int KEY_CODE_M = 25;
        public const int KEY_CODE_A = 26;
        public const int KEY_CODE_F1 = 27;
        public const int KEY_CODE_F2 = 28;

        /* for PTZ control */
        public const int KEY_PTZ_UP_START = KEY_CODE_UP;
        public const int KEY_PTZ_UP_STOP = 32;

        public const int KEY_PTZ_DOWN_START = KEY_CODE_DOWN;
        public const int KEY_PTZ_DOWN_STOP = 33;


        public const int KEY_PTZ_LEFT_START = KEY_CODE_LEFT;
        public const int KEY_PTZ_LEFT_STOP = 34;

        public const int KEY_PTZ_RIGHT_START = KEY_CODE_RIGHT;
        public const int KEY_PTZ_RIGHT_STOP = 35;

        public const int KEY_PTZ_AP1_START = KEY_CODE_EDIT;/* 光圈+ */
        public const int KEY_PTZ_AP1_STOP = 36;

        public const int KEY_PTZ_AP2_START = KEY_CODE_PAN;/* 光圈- */
        public const int KEY_PTZ_AP2_STOP = 37;

        public const int KEY_PTZ_FOCUS1_START = KEY_CODE_A;/* 聚焦+ */
        public const int KEY_PTZ_FOCUS1_STOP = 38;

        public const int KEY_PTZ_FOCUS2_START = KEY_CODE_M;/* 聚焦- */
        public const int KEY_PTZ_FOCUS2_STOP = 39;

        public const int KEY_PTZ_B1_START = 40;/* 变倍+ */
        public const int KEY_PTZ_B1_STOP = 41;

        public const int KEY_PTZ_B2_START = 42;/* 变倍- */
        public const int KEY_PTZ_B2_STOP = 43;

        //9000新增
        public const int KEY_CODE_11 = 44;
        public const int KEY_CODE_12 = 45;
        public const int KEY_CODE_13 = 46;
        public const int KEY_CODE_14 = 47;
        public const int KEY_CODE_15 = 48;
        public const int KEY_CODE_16 = 49;

        /*************************参数配置命令 begin*******************************/
        //用于NET_DVR_SetDVRConfig和NET_DVR_GetDVRConfig,注意其对应的配置结构
        public const int NET_DVR_GET_DEVICECFG = 100;//获取设备参数
        public const int NET_DVR_SET_DEVICECFG = 101;//设置设备参数
        public const int NET_DVR_GET_NETCFG = 102;//获取网络参数
        public const int NET_DVR_SET_NETCFG = 103;//设置网络参数
        public const int NET_DVR_GET_PICCFG = 104;//获取图象参数
        public const int NET_DVR_SET_PICCFG = 105;//设置图象参数
        public const int NET_DVR_GET_COMPRESSCFG = 106;//获取压缩参数
        public const int NET_DVR_SET_COMPRESSCFG = 107;//设置压缩参数
        public const int NET_DVR_GET_RECORDCFG = 108;//获取录像时间参数
        public const int NET_DVR_SET_RECORDCFG = 109;//设置录像时间参数
        public const int NET_DVR_GET_DECODERCFG = 110;//获取解码器参数
        public const int NET_DVR_SET_DECODERCFG = 111;//设置解码器参数
        public const int NET_DVR_GET_RS232CFG = 112;//获取232串口参数
        public const int NET_DVR_SET_RS232CFG = 113;//设置232串口参数
        public const int NET_DVR_GET_ALARMINCFG = 114;//获取报警输入参数
        public const int NET_DVR_SET_ALARMINCFG = 115;//设置报警输入参数
        public const int NET_DVR_GET_ALARMOUTCFG = 116;//获取报警输出参数
        public const int NET_DVR_SET_ALARMOUTCFG = 117;//设置报警输出参数
        public const int NET_DVR_GET_TIMECFG = 118;//获取DVR时间
        public const int NET_DVR_SET_TIMECFG = 119;//设置DVR时间
        public const int NET_DVR_GET_PREVIEWCFG = 120;//获取预览参数
        public const int NET_DVR_SET_PREVIEWCFG = 121;//设置预览参数
        public const int NET_DVR_GET_VIDEOOUTCFG = 122;//获取视频输出参数
        public const int NET_DVR_SET_VIDEOOUTCFG = 123;//设置视频输出参数
        public const int NET_DVR_GET_USERCFG = 124;//获取用户参数
        public const int NET_DVR_SET_USERCFG = 125;//设置用户参数
        public const int NET_DVR_GET_EXCEPTIONCFG = 126;//获取异常参数
        public const int NET_DVR_SET_EXCEPTIONCFG = 127;//设置异常参数
        public const int NET_DVR_GET_ZONEANDDST = 128;//获取时区和夏时制参数
        public const int NET_DVR_SET_ZONEANDDST = 129;//设置时区和夏时制参数
        public const int NET_DVR_GET_SHOWSTRING = 130;//获取叠加字符参数
        public const int NET_DVR_SET_SHOWSTRING = 131;//设置叠加字符参数
        public const int NET_DVR_GET_EVENTCOMPCFG = 132;//获取事件触发录像参数
        public const int NET_DVR_SET_EVENTCOMPCFG = 133;//设置事件触发录像参数

        public const int NET_DVR_GET_AUXOUTCFG = 140;//获取报警触发辅助输出设置(HS设备辅助输出2006-02-28)
        public const int NET_DVR_SET_AUXOUTCFG = 141;//设置报警触发辅助输出设置(HS设备辅助输出2006-02-28)
        public const int NET_DVR_GET_PREVIEWCFG_AUX = 142;//获取-s系列双输出预览参数(-s系列双输出2006-04-13)
        public const int NET_DVR_SET_PREVIEWCFG_AUX = 143;//设置-s系列双输出预览参数(-s系列双输出2006-04-13)

        public const int NET_DVR_GET_PICCFG_EX = 200;//获取图象参数(SDK_V14扩展命令)
        public const int NET_DVR_SET_PICCFG_EX = 201;//设置图象参数(SDK_V14扩展命令)
        public const int NET_DVR_GET_USERCFG_EX = 202;//获取用户参数(SDK_V15扩展命令)
        public const int NET_DVR_SET_USERCFG_EX = 203;//设置用户参数(SDK_V15扩展命令)
        public const int NET_DVR_GET_COMPRESSCFG_EX = 204;//获取压缩参数(SDK_V15扩展命令2006-05-15)
        public const int NET_DVR_SET_COMPRESSCFG_EX = 205;//设置压缩参数(SDK_V15扩展命令2006-05-15)

        public const int NET_DVR_GET_NETAPPCFG = 222;//获取网络应用参数 NTP/DDNS/EMAIL
        public const int NET_DVR_SET_NETAPPCFG = 223;//设置网络应用参数 NTP/DDNS/EMAIL
        public const int NET_DVR_GET_NTPCFG = 224;//获取网络应用参数 NTP
        public const int NET_DVR_SET_NTPCFG = 225;//设置网络应用参数 NTP
        public const int NET_DVR_GET_DDNSCFG = 226;//获取网络应用参数 DDNS
        public const int NET_DVR_SET_DDNSCFG = 227;//设置网络应用参数 DDNS
        //对应NET_DVR_EMAILPARA
        public const int NET_DVR_GET_EMAILCFG = 228;//获取网络应用参数 EMAIL
        public const int NET_DVR_SET_EMAILCFG = 229;//设置网络应用参数 EMAIL

        public const int NET_DVR_GET_NFSCFG = 230;/* NFS disk config */
        public const int NET_DVR_SET_NFSCFG = 231;/* NFS disk config */

        public const int NET_DVR_GET_SHOWSTRING_EX = 238;//获取叠加字符参数扩展(支持8条字符)
        public const int NET_DVR_SET_SHOWSTRING_EX = 239;//设置叠加字符参数扩展(支持8条字符)
        public const int NET_DVR_GET_NETCFG_OTHER = 244;//获取网络参数
        public const int NET_DVR_SET_NETCFG_OTHER = 245;//设置网络参数

        //对应NET_DVR_EMAILCFG结构
        public const int NET_DVR_GET_EMAILPARACFG = 250;//Get EMAIL parameters
        public const int NET_DVR_SET_EMAILPARACFG = 251;//Setup EMAIL parameters

        public const int NET_DVR_GET_DDNSCFG_EX = 274;//获取扩展DDNS参数
        public const int NET_DVR_SET_DDNSCFG_EX = 275;//设置扩展DDNS参数

        public const int NET_DVR_SET_PTZPOS = 292;//云台设置PTZ位置
        public const int NET_DVR_GET_PTZPOS = 293;//云台获取PTZ位置
        public const int NET_DVR_GET_PTZSCOPE = 294;//云台获取PTZ范围

        public const int NET_DVR_GET_AP_INFO_LIST = 305;//获取无线网络资源参数
        public const int NET_DVR_SET_WIFI_CFG = 306;//设置IP监控设备无线参数
        public const int NET_DVR_GET_WIFI_CFG = 307;//获取IP监控设备无线参数
        public const int NET_DVR_SET_WIFI_WORKMODE = 308;//设置IP监控设备网口工作模式参数
        public const int NET_DVR_GET_WIFI_WORKMODE = 309;//获取IP监控设备网口工作模式参数 
        public const int NET_DVR_GET_WIFI_STATUS = 310;	//获取设备当前wifi连接状态

        /***************************智能服务器 begin *****************************/
        //智能设备类型
        public const int DS6001_HF_B = 60;//行为分析：DS6001-HF/B
        public const int DS6001_HF_P = 61;//车牌识别：DS6001-HF/P
        public const int DS6002_HF_B = 62;//双机跟踪：DS6002-HF/B
        public const int DS6101_HF_B = 63;//行为分析：DS6101-HF/B
        public const int IDS52XX = 64;//智能分析仪IVMS
        public const int DS9000_IVS = 65;//9000系列智能DVR
        public const int DS8004_AHL_A = 66;//智能ATM, DS8004AHL-S/A
        public const int DS6101_HF_P = 67;//车牌识别：DS6101-HF/P

        //能力获取命令
        public const int VCA_DEV_ABILITY = 256;//设备智能分析的总能力
        public const int VCA_CHAN_ABILITY = 272;//行为分析能力
        public const int MATRIXDECODER_ABILITY = 512;//多路解码器显示、解码能力
        //获取/设置大接口参数配置命令
        //车牌识别（NET_VCA_PLATE_CFG）
        public const int NET_DVR_SET_PLATECFG = 150;//设置车牌识别参数
        public const int NET_DVR_GET_PLATECFG = 151;//获取车牌识别参数
        //行为对应（NET_VCA_RULECFG）
        public const int NET_DVR_SET_RULECFG = 152;//设置行为分析规则
        public const int NET_DVR_GET_RULECFG = 153;//获取行为分析规则

        //双摄像机标定参数（NET_DVR_LF_CFG）
        public const int NET_DVR_SET_LF_CFG = 160;//设置双摄像机的配置参数
        public const int NET_DVR_GET_LF_CFG = 161;//获取双摄像机的配置参数

        //智能分析仪取流配置结构
        public const int NET_DVR_SET_IVMS_STREAMCFG = 162;//设置智能分析仪取流参数
        public const int NET_DVR_GET_IVMS_STREAMCFG = 163;//获取智能分析仪取流参数

        //智能控制参数结构
        public const int NET_DVR_SET_VCA_CTRLCFG = 164;//设置智能控制参数
        public const int NET_DVR_GET_VCA_CTRLCFG = 165;//获取智能控制参数

        //屏蔽区域NET_VCA_MASK_REGION_LIST
        public const int NET_DVR_SET_VCA_MASK_REGION = 166;//设置屏蔽区域参数
        public const int NET_DVR_GET_VCA_MASK_REGION = 167;//获取屏蔽区域参数

        //ATM进入区域 NET_VCA_ENTER_REGION
        public const int NET_DVR_SET_VCA_ENTER_REGION = 168;//设置进入区域参数
        public const int NET_DVR_GET_VCA_ENTER_REGION = 169;//获取进入区域参数

        //标定线配置NET_VCA_LINE_SEGMENT_LIST
        public const int NET_DVR_SET_VCA_LINE_SEGMENT = 170;//设置标定线
        public const int NET_DVR_GET_VCA_LINE_SEGMENT = 171;//获取标定线

        // ivms屏蔽区域NET_IVMS_MASK_REGION_LIST
        public const int NET_DVR_SET_IVMS_MASK_REGION = 172;//设置IVMS屏蔽区域参数
        public const int NET_DVR_GET_IVMS_MASK_REGION = 173;//获取IVMS屏蔽区域参数
        // ivms进入检测区域NET_IVMS_ENTER_REGION
        public const int NET_DVR_SET_IVMS_ENTER_REGION = 174;//设置IVMS进入区域参数
        public const int NET_DVR_GET_IVMS_ENTER_REGION = 175;//获取IVMS进入区域参数

        public const int NET_DVR_SET_IVMS_BEHAVIORCFG = 176;//设置智能分析仪行为规则参数
        public const int NET_DVR_GET_IVMS_BEHAVIORCFG = 177;//获取智能分析仪行为规则参数

        // IVMS 回放检索
        public const int NET_DVR_IVMS_SET_SEARCHCFG = 178;//设置IVMS回放检索参数
        public const int NET_DVR_IVMS_GET_SEARCHCFG = 179;//获取IVMS回放检索参数     

        /***************************DS9000新增命令(_V30) begin *****************************/
        //网络(NET_DVR_NETCFG_V30结构)
        public const int NET_DVR_GET_NETCFG_V30 = 1000;//获取网络参数
        public const int NET_DVR_SET_NETCFG_V30 = 1001;//设置网络参数

        //图象(NET_DVR_PICCFG_V30结构)
        public const int NET_DVR_GET_PICCFG_V30 = 1002;//获取图象参数
        public const int NET_DVR_SET_PICCFG_V30 = 1003;//设置图象参数

        //图象(NET_DVR_PICCFG_V40结构)
        public const int NET_DVR_GET_PICCFG_V40 = 6179;//获取图象参数V40扩展
        public const int NET_DVR_SET_PICCFG_V40 = 6180;//设置图象参数V40扩展

        //录像时间(NET_DVR_RECORD_V30结构)
        public const int NET_DVR_GET_RECORDCFG_V30 = 1004;//获取录像参数
        public const int NET_DVR_SET_RECORDCFG_V30 = 1005;//设置录像参数

        public const int NET_DVR_GET_RECORDCFG_V40 = 1008; //获取录像参数(扩展)
        public const int NET_DVR_SET_RECORDCFG_V40 = 1009; //设置录像参数(扩展)

        //用户(NET_DVR_USER_V30结构)
        public const int NET_DVR_GET_USERCFG_V30 = 1006;//获取用户参数
        public const int NET_DVR_SET_USERCFG_V30 = 1007;//设置用户参数

        //9000DDNS参数配置(NET_DVR_DDNSPARA_V30结构)
        public const int NET_DVR_GET_DDNSCFG_V30 = 1010;//获取DDNS(9000扩展)
        public const int NET_DVR_SET_DDNSCFG_V30 = 1011;//设置DDNS(9000扩展)

        //EMAIL功能(NET_DVR_EMAILCFG_V30结构)
        public const int NET_DVR_GET_EMAILCFG_V30 = 1012;//获取EMAIL参数 
        public const int NET_DVR_SET_EMAILCFG_V30 = 1013;//设置EMAIL参数 

        //巡航参数 (NET_DVR_CRUISE_PARA结构)
        public const int NET_DVR_GET_CRUISE = 1020;
        public const int NET_DVR_SET_CRUISE = 1021;

        //报警输入结构参数 (NET_DVR_ALARMINCFG_V30结构)
        public const int NET_DVR_GET_ALARMINCFG_V30 = 1024;
        public const int NET_DVR_SET_ALARMINCFG_V30 = 1025;

        //报警输出结构参数 (NET_DVR_ALARMOUTCFG_V30结构)
        public const int NET_DVR_GET_ALARMOUTCFG_V30 = 1026;
        public const int NET_DVR_SET_ALARMOUTCFG_V30 = 1027;

        //视频输出结构参数 (NET_DVR_VIDEOOUT_V30结构)
        public const int NET_DVR_GET_VIDEOOUTCFG_V30 = 1028;
        public const int NET_DVR_SET_VIDEOOUTCFG_V30 = 1029;

        //叠加字符结构参数 (NET_DVR_SHOWSTRING_V30结构)
        public const int NET_DVR_GET_SHOWSTRING_V30 = 1030;
        public const int NET_DVR_SET_SHOWSTRING_V30 = 1031;

        //异常结构参数 (NET_DVR_EXCEPTION_V30结构)
        public const int NET_DVR_GET_EXCEPTIONCFG_V30 = 1034;
        public const int NET_DVR_SET_EXCEPTIONCFG_V30 = 1035;

        //串口232结构参数 (NET_DVR_RS232CFG_V30结构)
        public const int NET_DVR_GET_RS232CFG_V30 = 1036;
        public const int NET_DVR_SET_RS232CFG_V30 = 1037;

        //网络硬盘接入结构参数 (NET_DVR_NET_DISKCFG结构)
        public const int NET_DVR_GET_NET_DISKCFG = 1038;//网络硬盘接入获取
        public const int NET_DVR_SET_NET_DISKCFG = 1039;//网络硬盘接入设置

        //压缩参数 (NET_DVR_COMPRESSIONCFG_V30结构)
        public const int NET_DVR_GET_COMPRESSCFG_V30 = 1040;
        public const int NET_DVR_SET_COMPRESSCFG_V30 = 1041;

        //获取485解码器参数 (NET_DVR_DECODERCFG_V30结构)
        public const int NET_DVR_GET_DECODERCFG_V30 = 1042;//获取解码器参数
        public const int NET_DVR_SET_DECODERCFG_V30 = 1043;//设置解码器参数

        //获取预览参数 (NET_DVR_PREVIEWCFG_V30结构)
        public const int NET_DVR_GET_PREVIEWCFG_V30 = 1044;//获取预览参数
        public const int NET_DVR_SET_PREVIEWCFG_V30 = 1045;//设置预览参数

        //辅助预览参数 (NET_DVR_PREVIEWCFG_AUX_V30结构)
        public const int NET_DVR_GET_PREVIEWCFG_AUX_V30 = 1046;//获取辅助预览参数
        public const int NET_DVR_SET_PREVIEWCFG_AUX_V30 = 1047;//设置辅助预览参数

        //IP接入配置参数 （NET_DVR_IPPARACFG结构）
        public const int NET_DVR_GET_IPPARACFG = 1048; //获取IP接入配置信息 
        public const int NET_DVR_SET_IPPARACFG = 1049;//设置IP接入配置信息

        //IP接入配置参数 （NET_DVR_IPPARACFG_V40结构）
        public const int NET_DVR_GET_IPPARACFG_V40 = 1062; //获取IP接入配置信息 
        public const int NET_DVR_SET_IPPARACFG_V40 = 1063;//设置IP接入配置信息

        //IP报警输入接入配置参数 （NET_DVR_IPALARMINCFG结构）
        public const int NET_DVR_GET_IPALARMINCFG = 1050; //获取IP报警输入接入配置信息 
        public const int NET_DVR_SET_IPALARMINCFG = 1051; //设置IP报警输入接入配置信息

        //IP报警输出接入配置参数 （NET_DVR_IPALARMOUTCFG结构）
        public const int NET_DVR_GET_IPALARMOUTCFG = 1052;//获取IP报警输出接入配置信息 
        public const int NET_DVR_SET_IPALARMOUTCFG = 1053;//设置IP报警输出接入配置信息

        //硬盘管理的参数获取 (NET_DVR_HDCFG结构)
        public const int NET_DVR_GET_HDCFG = 1054;//获取硬盘管理配置参数
        public const int NET_DVR_SET_HDCFG = 1055;//设置硬盘管理配置参数

        //盘组管理的参数获取 (NET_DVR_HDGROUP_CFG结构)
        public const int NET_DVR_GET_HDGROUP_CFG = 1056;//获取盘组管理配置参数
        public const int NET_DVR_SET_HDGROUP_CFG = 1057;//设置盘组管理配置参数

        //设备编码类型配置(NET_DVR_COMPRESSION_AUDIO结构)
        public const int NET_DVR_GET_COMPRESSCFG_AUD = 1058;//获取设备语音对讲编码参数
        public const int NET_DVR_SET_COMPRESSCFG_AUD = 1059;//设置设备语音对讲编码参数

        //IP接入配置参数 （NET_DVR_IPPARACFG_V31结构）
        public const int NET_DVR_GET_IPPARACFG_V31 = 1060;//获取IP接入配置信息 
        public const int NET_DVR_SET_IPPARACFG_V31 = 1061; //设置IP接入配置信息

        //设备参数配置 （NET_DVR_DEVICECFG_V40结构）
        public const int NET_DVR_GET_DEVICECFG_V40 = 1100;//获取设备参数
        public const int NET_DVR_SET_DEVICECFG_V40 = 1101;//设置设备参数

        //多网卡配置(NET_DVR_NETCFG_MULTI结构)
        public const int NET_DVR_GET_NETCFG_MULTI = 1161;
        public const int NET_DVR_SET_NETCFG_MULTI = 1162;

        //BONDING网卡(NET_DVR_NETWORK_BONDING结构)
        public const int NET_DVR_GET_NETWORK_BONDING = 1254;
        public const int NET_DVR_SET_NETWORK_BONDING = 1255;

        //NAT映射配置参数 （NET_DVR_NAT_CFG结构）
        public const int NET_DVR_GET_NAT_CFG = 6111;    //获取NAT映射参数
        public const int NET_DVR_SET_NAT_CFG = 6112;    //设置NAT映射参数  

        //预置点名称获取与设置
        public const int NET_DVR_GET_PRESET_NAME = 3383;
        public const int NET_DVR_SET_PRESET_NAME = 3382;

        public const int NET_VCA_GET_RULECFG_V41 = 5011; //获取行为分析参数
        public const int NET_VCA_SET_RULECFG_V41 = 5012; //设置行为分析参数

        public const int NET_DVR_GET_TRAVERSE_PLANE_DETECTION = 3360; //获取越界侦测配置
        public const int NET_DVR_SET_TRAVERSE_PLANE_DETECTION = 3361; //设置越界侦测配置

        public const int NET_DVR_GET_THERMOMETRY_ALARMRULE = 3627; //获取预置点测温报警规则配置
        public const int NET_DVR_SET_THERMOMETRY_ALARMRULE = 3628; //设置预置点测温报警规则配置     
        public const int NET_DVR_GET_THERMOMETRY_TRIGGER = 3632; //获取测温联动配置
        public const int NET_DVR_SET_THERMOMETRY_TRIGGER = 3633; //设置测温联动配置

        public const int NET_DVR_SET_MANUALTHERM_BASICPARAM = 6716;  //设置手动测温基本参数
        public const int NET_DVR_GET_MANUALTHERM_BASICPARAM = 6717;  //获取手动测温基本参数

        public const int NET_DVR_SET_MANUALTHERM = 6708; //设置手动测温数据设置

        public const int NET_DVR_GET_MULTI_STREAM_COMPRESSIONCFG = 3216; //远程获取多码流压缩参数
        public const int NET_DVR_SET_MULTI_STREAM_COMPRESSIONCFG = 3217; //远程设置多码流压缩参数 

        public const int NET_DVR_VIDEO_CALL_SIGNAL_PROCESS = 16032;  //可视话对讲信令处理
        /*************************参数配置命令 end*******************************/

        /************************DVR日志 begin***************************/
        /* 报警 */
        //主类型
        public const int MAJOR_ALARM = 1;
        //次类型
        public const int MINOR_ALARM_IN = 1;/* 报警输入 */
        public const int MINOR_ALARM_OUT = 2;/* 报警输出 */
        public const int MINOR_MOTDET_START = 3; /* 移动侦测报警开始 */
        public const int MINOR_MOTDET_STOP = 4; /* 移动侦测报警结束 */
        public const int MINOR_HIDE_ALARM_START = 5;/* 遮挡报警开始 */
        public const int MINOR_HIDE_ALARM_STOP = 6;/* 遮挡报警结束 */
        public const int MINOR_VCA_ALARM_START = 7;/*智能报警开始*/
        public const int MINOR_VCA_ALARM_STOP = 8;/*智能报警停止*/

        /* 异常 */
        //主类型
        public const int MAJOR_EXCEPTION = 2;
        //次类型
        public const int MINOR_VI_LOST = 33;/* 视频信号丢失 */
        public const int MINOR_ILLEGAL_ACCESS = 34;/* 非法访问 */
        public const int MINOR_HD_FULL = 35;/* 硬盘满 */
        public const int MINOR_HD_ERROR = 36;/* 硬盘错误 */
        public const int MINOR_DCD_LOST = 37;/* MODEM 掉线(保留不使用) */
        public const int MINOR_IP_CONFLICT = 38;/* IP地址冲突 */
        public const int MINOR_NET_BROKEN = 39;/* 网络断开*/
        public const int MINOR_REC_ERROR = 40;/* 录像出错 */
        public const int MINOR_IPC_NO_LINK = 41;/* IPC连接异常 */
        public const int MINOR_VI_EXCEPTION = 42;/* 视频输入异常(只针对模拟通道) */
        public const int MINOR_IPC_IP_CONFLICT = 43;/*ipc ip 地址 冲突*/

        //视频综合平台
        public const int MINOR_FANABNORMAL = 49;/* 视频综合平台：风扇状态异常 */
        public const int MINOR_FANRESUME = 50;/* 视频综合平台：风扇状态恢复正常 */
        public const int MINOR_SUBSYSTEM_ABNORMALREBOOT = 51;/* 视频综合平台：6467异常重启 */
        public const int MINOR_MATRIX_STARTBUZZER = 52;/* 视频综合平台：dm6467异常，启动蜂鸣器 */

        /* 操作 */
        //主类型
        public const int MAJOR_OPERATION = 3;
        //次类型
        public const int MINOR_START_DVR = 65;/* 开机 */
        public const int MINOR_STOP_DVR = 66;/* 关机 */
        public const int MINOR_STOP_ABNORMAL = 67;/* 异常关机 */
        public const int MINOR_REBOOT_DVR = 68;/*本地重启设备*/

        public const int MINOR_LOCAL_LOGIN = 80;/* 本地登陆 */
        public const int MINOR_LOCAL_LOGOUT = 81;/* 本地注销登陆 */
        public const int MINOR_LOCAL_CFG_PARM = 82;/* 本地配置参数 */
        public const int MINOR_LOCAL_PLAYBYFILE = 83;/* 本地按文件回放或下载 */
        public const int MINOR_LOCAL_PLAYBYTIME = 84;/* 本地按时间回放或下载*/
        public const int MINOR_LOCAL_START_REC = 85;/* 本地开始录像 */
        public const int MINOR_LOCAL_STOP_REC = 86;/* 本地停止录像 */
        public const int MINOR_LOCAL_PTZCTRL = 87;/* 本地云台控制 */
        public const int MINOR_LOCAL_PREVIEW = 88;/* 本地预览 (保留不使用)*/
        public const int MINOR_LOCAL_MODIFY_TIME = 89;/* 本地修改时间(保留不使用) */
        public const int MINOR_LOCAL_UPGRADE = 90;/* 本地升级 */
        public const int MINOR_LOCAL_RECFILE_OUTPUT = 91;/* 本地备份录象文件 */
        public const int MINOR_LOCAL_FORMAT_HDD = 92;/* 本地初始化硬盘 */
        public const int MINOR_LOCAL_CFGFILE_OUTPUT = 93;/* 导出本地配置文件 */
        public const int MINOR_LOCAL_CFGFILE_INPUT = 94;/* 导入本地配置文件 */
        public const int MINOR_LOCAL_COPYFILE = 95;/* 本地备份文件 */
        public const int MINOR_LOCAL_LOCKFILE = 96;/* 本地锁定录像文件 */
        public const int MINOR_LOCAL_UNLOCKFILE = 97;/* 本地解锁录像文件 */
        public const int MINOR_LOCAL_DVR_ALARM = 98;/* 本地手动清除和触发报警*/
        public const int MINOR_IPC_ADD = 99;/* 本地添加IPC */
        public const int MINOR_IPC_DEL = 100;/* 本地删除IPC */
        public const int MINOR_IPC_SET = 101;/* 本地设置IPC */
        public const int MINOR_LOCAL_START_BACKUP = 102;/* 本地开始备份 */
        public const int MINOR_LOCAL_STOP_BACKUP = 103;/* 本地停止备份*/
        public const int MINOR_LOCAL_COPYFILE_START_TIME = 104;/* 本地备份开始时间*/
        public const int MINOR_LOCAL_COPYFILE_END_TIME = 105;/* 本地备份结束时间*/
        public const int MINOR_LOCAL_ADD_NAS = 106;/*本地添加网络硬盘*/
        public const int MINOR_LOCAL_DEL_NAS = 107;/* 本地删除nas盘*/
        public const int MINOR_LOCAL_SET_NAS = 108;/* 本地设置nas盘*/

        public const int MINOR_REMOTE_LOGIN = 112;/* 远程登录 */
        public const int MINOR_REMOTE_LOGOUT = 113;/* 远程注销登陆 */
        public const int MINOR_REMOTE_START_REC = 114;/* 远程开始录像 */
        public const int MINOR_REMOTE_STOP_REC = 115;/* 远程停止录像 */
        public const int MINOR_START_TRANS_CHAN = 116;/* 开始透明传输 */
        public const int MINOR_STOP_TRANS_CHAN = 117;/* 停止透明传输 */
        public const int MINOR_REMOTE_GET_PARM = 118;/* 远程获取参数 */
        public const int MINOR_REMOTE_CFG_PARM = 119;/* 远程配置参数 */
        public const int MINOR_REMOTE_GET_STATUS = 120;/* 远程获取状态 */
        public const int MINOR_REMOTE_ARM = 121;/* 远程布防 */
        public const int MINOR_REMOTE_DISARM = 122;/* 远程撤防 */
        public const int MINOR_REMOTE_REBOOT = 123;/* 远程重启 */
        public const int MINOR_START_VT = 124;/* 开始语音对讲 */
        public const int MINOR_STOP_VT = 125;/* 停止语音对讲 */
        public const int MINOR_REMOTE_UPGRADE = 126;/* 远程升级 */
        public const int MINOR_REMOTE_PLAYBYFILE = 127;/* 远程按文件回放 */
        public const int MINOR_REMOTE_PLAYBYTIME = 128;/* 远程按时间回放 */
        public const int MINOR_REMOTE_PTZCTRL = 129;/* 远程云台控制 */
        public const int MINOR_REMOTE_FORMAT_HDD = 130;/* 远程格式化硬盘 */
        public const int MINOR_REMOTE_STOP = 131;/* 远程关机 */
        public const int MINOR_REMOTE_LOCKFILE = 132;/* 远程锁定文件 */
        public const int MINOR_REMOTE_UNLOCKFILE = 133;/* 远程解锁文件 */
        public const int MINOR_REMOTE_CFGFILE_OUTPUT = 134;/* 远程导出配置文件 */
        public const int MINOR_REMOTE_CFGFILE_INTPUT = 135;/* 远程导入配置文件 */
        public const int MINOR_REMOTE_RECFILE_OUTPUT = 136;/* 远程导出录象文件 */
        public const int MINOR_REMOTE_DVR_ALARM = 137;/* 远程手动清除和触发报警*/
        public const int MINOR_REMOTE_IPC_ADD = 138;/* 远程添加IPC */
        public const int MINOR_REMOTE_IPC_DEL = 139;/* 远程删除IPC */
        public const int MINOR_REMOTE_IPC_SET = 140;/* 远程设置IPC */
        public const int MINOR_REBOOT_VCA_LIB = 141;/*重启智能库*/
        public const int MINOR_REMOTE_ADD_NAS = 142;/* 远程添加nas盘*/
        public const int MINOR_REMOTE_DEL_NAS = 143;/* 远程删除nas盘*/
        public const int MINOR_REMOTE_SET_NAS = 144;/* 远程设置nas盘*/

        //2009-12-16 增加视频综合平台日志类型
        public const int MINOR_SUBSYSTEMREBOOT = 160;/*视频综合平台：dm6467 正常重启*/
        public const int MINOR_MATRIX_STARTTRANSFERVIDEO = 161;	/*视频综合平台：矩阵切换开始传输图像*/
        public const int MINOR_MATRIX_STOPTRANSFERVIDEO = 162;	/*视频综合平台：矩阵切换停止传输图像*/
        public const int MINOR_REMOTE_SET_ALLSUBSYSTEM = 163;	/*视频综合平台：设置所有6467子系统信息*/
        public const int MINOR_REMOTE_GET_ALLSUBSYSTEM = 164;	/*视频综合平台：获取所有6467子系统信息*/
        public const int MINOR_REMOTE_SET_PLANARRAY = 165;	/*视频综合平台：设置计划轮询组*/
        public const int MINOR_REMOTE_GET_PLANARRAY = 166;	/*视频综合平台：获取计划轮询组*/
        public const int MINOR_MATRIX_STARTTRANSFERAUDIO = 167;	/*视频综合平台：矩阵切换开始传输音频*/
        public const int MINOR_MATRIX_STOPRANSFERAUDIO = 168;	/*视频综合平台：矩阵切换停止传输音频*/
        public const int MINOR_LOGON_CODESPITTER = 169;	/*视频综合平台：登陆码分器*/
        public const int MINOR_LOGOFF_CODESPITTER = 170;	/*视频综合平台：退出码分器*/

        /*日志附加信息*/
        //主类型
        public const int MAJOR_INFORMATION = 4;/*附加信息*/
        //次类型
        public const int MINOR_HDD_INFO = 161;/*硬盘信息*/
        public const int MINOR_SMART_INFO = 162;/*SMART信息*/
        public const int MINOR_REC_START = 163;/*开始录像*/
        public const int MINOR_REC_STOP = 164;/*停止录像*/
        public const int MINOR_REC_OVERDUE = 165;/*过期录像删除*/
        public const int MINOR_LINK_START = 166;//连接前端设备
        public const int MINOR_LINK_STOP = 167;//断开前端设备　
        public const int MINOR_NET_DISK_INFO = 168;//网络硬盘信息

        //当日志的主类型为MAJOR_OPERATION=03，次类型为MINOR_LOCAL_CFG_PARM=0x52或者MINOR_REMOTE_GET_PARM=0x76或者MINOR_REMOTE_CFG_PARM=0x77时，dwParaType:参数类型有效，其含义如下：
        public const int PARA_VIDEOOUT = 1;
        public const int PARA_IMAGE = 2;
        public const int PARA_ENCODE = 4;
        public const int PARA_NETWORK = 8;
        public const int PARA_ALARM = 16;
        public const int PARA_EXCEPTION = 32;
        public const int PARA_DECODER = 64;/*解码器*/
        public const int PARA_RS232 = 128;
        public const int PARA_PREVIEW = 256;
        public const int PARA_SECURITY = 512;
        public const int PARA_DATETIME = 1024;
        public const int PARA_FRAMETYPE = 2048;/*帧格式*/
        //vca
        public const int PARA_VCA_RULE = 4096;//行为规则
        /************************DVR日志 End***************************/


        /*******************查找文件和日志函数返回值*************************/
        public const int NET_DVR_FILE_SUCCESS = 1000;//获得文件信息
        public const int NET_DVR_FILE_NOFIND = 1001;//没有文件
        public const int NET_DVR_ISFINDING = 1002;//正在查找文件
        public const int NET_DVR_NOMOREFILE = 1003;//查找文件时没有更多的文件
        public const int NET_DVR_FILE_EXCEPTION = 1004;//查找文件时异常

        /*********************回调函数类型 begin************************/
        public const int COMM_ALARM = 0x1100;//8000报警信息主动上传，对应NET_DVR_ALARMINFO
        public const int COMM_ALARM_RULE = 0x1102;//行为分析报警信息，对应NET_VCA_RULE_ALARM
        public const int COMM_ALARM_PDC = 0x1103;//人流量统计报警上传，对应NET_DVR_PDC_ALRAM_INFO
        public const int COMM_ALARM_ALARMHOST = 0x1105;//网络报警主机报警上传，对应NET_DVR_ALARMHOST_ALARMINFO
        public const int COMM_ALARM_FACE = 0x1106;//人脸检测识别报警信息，对应NET_DVR_FACEDETECT_ALARM
        public const int COMM_RULE_INFO_UPLOAD = 0x1107;  // 事件数据信息上传
        public const int COMM_ALARM_AID = 0x1110;  //交通事件报警信息
        public const int COMM_ALARM_TPS = 0x1111;  //交通参数统计报警信息
        public const int COMM_UPLOAD_FACESNAP_RESULT = 0x1112;  //人脸识别结果上传
        public const int COMM_ALARM_FACE_DETECTION = 0x4010; //人脸侦测报警信息
        public const int COMM_ALARM_TFS = 0x1113;  //交通取证报警信息
        public const int COMM_ALARM_TPS_V41 = 0x1114;  //交通参数统计报警信息扩展
        public const int COMM_ALARM_AID_V41 = 0x1115;  //交通事件报警信息扩展
        public const int COMM_ALARM_VQD_EX = 0x1116;	 //视频质量诊断报警
        public const int COMM_SENSOR_VALUE_UPLOAD = 0x1120;  //模拟量数据实时上传
        public const int COMM_SENSOR_ALARM = 0x1121;  //模拟量报警上传
        public const int COMM_SWITCH_ALARM = 0x1122;	 //开关量报警
        public const int COMM_ALARMHOST_EXCEPTION = 0x1123; //报警主机故障报警
        public const int COMM_ALARMHOST_OPERATEEVENT_ALARM = 0x1124;  //操作事件报警上传
        public const int COMM_ALARMHOST_SAFETYCABINSTATE = 0x1125;	 //防护舱状态
        public const int COMM_ALARMHOST_ALARMOUTSTATUS = 0x1126;	 //报警输出口/警号状态
        public const int COMM_ALARMHOST_CID_ALARM = 0x1127;	 //CID报告报警上传
        public const int COMM_ALARMHOST_EXTERNAL_DEVICE_ALARM = 0x1128;	 //报警主机外接设备报警上传
        public const int COMM_ALARMHOST_DATA_UPLOAD = 0x1129;	 //报警数据上传
        public const int COMM_UPLOAD_VIDEO_INTERCOM_EVENT = 0x1132;  //可视对讲事件记录上传
        public const int COMM_ALARM_AUDIOEXCEPTION = 0x1150;	 //声音报警信息
        public const int COMM_ALARM_DEFOCUS = 0x1151;	 //虚焦报警信息
        public const int COMM_ALARM_BUTTON_DOWN_EXCEPTION = 0x1152;	 //按钮按下报警信息
        public const int COMM_ALARM_ALARMGPS = 0x1202; //GPS报警信息上传
        public const int COMM_TRADEINFO = 0x1500;  //ATMDVR主动上传交易信息
        public const int COMM_UPLOAD_PLATE_RESULT = 0x2800;	 //上传车牌信息
        public const int COMM_ITC_STATUS_DETECT_RESULT = 0x2810;  //实时状态检测结果上传(智能高清IPC)
        public const int COMM_IPC_AUXALARM_RESULT = 0x2820;  //PIR报警、无线报警、呼救报警上传
        public const int COMM_UPLOAD_PICTUREINFO = 0x2900;	 //上传图片信息
        public const int COMM_SNAP_MATCH_ALARM = 0x2902;  //黑名单比对结果上传
        public const int COMM_ITS_PLATE_RESULT = 0x3050;  //终端图片上传
        public const int COMM_ITS_TRAFFIC_COLLECT = 0x3051;  //终端统计数据上传
        public const int COMM_ITS_GATE_VEHICLE = 0x3052;  //出入口车辆抓拍数据上传
        public const int COMM_ITS_GATE_FACE = 0x3053; //出入口人脸抓拍数据上传
        public const int COMM_ITS_GATE_COSTITEM = 0x3054;  //出入口过车收费明细 2013-11-19
        public const int COMM_ITS_GATE_HANDOVER = 0x3055; //出入口交接班数据 2013-11-19
        public const int COMM_ITS_PARK_VEHICLE = 0x3056;  //停车场数据上传
        public const int COMM_ITS_BLACKLIST_ALARM = 0x3057;  //黑名单报警上传
        public const int COMM_ALARM_TPS_REAL_TIME = 0x3081;  //TPS实时过车数据上传
        public const int COMM_ALARM_TPS_STATISTICS = 0x3082;  //TPS统计过车数据上传
        public const int COMM_ALARM_V30 = 0x4000;	 //9000报警信息主动上传
        public const int COMM_IPCCFG = 0x4001;	 //9000设备IPC接入配置改变报警信息主动上传
        public const int COMM_IPCCFG_V31 = 0x4002;	 //9000设备IPC接入配置改变报警信息主动上传扩展 9000_1.1
        public const int COMM_IPCCFG_V40 = 0x4003; // IVMS 2000 编码服务器 NVR IPC接入配置改变时报警信息上传
        public const int COMM_ALARM_DEVICE = 0x4004;  //设备报警内容，由于通道值大于256而扩展
        public const int COMM_ALARM_CVR = 0x4005;  //CVR 2.0.X外部报警类型
        public const int COMM_ALARM_HOT_SPARE = 0x4006;  //热备异常报警（N+1模式异常报警）
        public const int COMM_ALARM_V40 = 0x4007;	//移动侦测，视频丢失，遮挡，IO信号量等报警信息主动上传，报警数据为可变长

        public const int COMM_ITS_ROAD_EXCEPTION = 0x4500;	 //路口设备异常报警
        public const int COMM_ITS_EXTERNAL_CONTROL_ALARM = 0x4520;  //外控报警
        public const int COMM_SCREEN_ALARM = 0x5000;  //多屏控制器报警类型
        public const int COMM_DVCS_STATE_ALARM = 0x5001;  //分布式大屏控制器报警上传
        public const int COMM_ALARM_VQD = 0x6000;  //VQD主动报警上传 
        public const int COMM_PUSH_UPDATE_RECORD_INFO = 0x6001;  //推模式录像信息上传
        public const int COMM_DIAGNOSIS_UPLOAD = 0x5100;  //诊断服务器VQD报警上传
        public const int COMM_ALARM_ACS = 0x5002;  //门禁主机报警
        public const int COMM_ID_INFO_ALARM = 0x5200;  //身份证信息上传
        public const int COMM_PASSNUM_INFO_ALARM = 0x5201;  //通行人数上报
        public const int COMM_ISAPI_ALARM = 0x6009;

        public const int COMM_UPLOAD_AIOP_VIDEO = 0x4021; //设备支持AI开放平台接入，上传视频检测数据
        public const int COMM_UPLOAD_AIOP_PICTURE = 0x4022; //设备支持AI开放平台接入，上传图片检测数据
        public const int COMM_UPLOAD_AIOP_POLLING_SNAP = 0x4023; //设备支持AI开放平台接入，上传轮巡抓图图片检测数据 对应的结构体(NET_AIOP_POLLING_SNAP_HEAD)
        public const int COMM_UPLOAD_AIOP_POLLING_VIDEO = 0x4024; //设备支持AI开放平台接入，上传轮巡视频检测数据 对应的结构体(NET_AIOP_POLLING_VIDEO_HEAD)


        /*************操作异常类型(消息方式, 回调方式(保留))****************/
        public const int EXCEPTION_EXCHANGE = 32768;//用户交互时异常
        public const int EXCEPTION_AUDIOEXCHANGE = 32769;//语音对讲异常
        public const int EXCEPTION_ALARM = 32770;//报警异常
        public const int EXCEPTION_PREVIEW = 32771;//网络预览异常
        public const int EXCEPTION_SERIAL = 32772;//透明通道异常
        public const int EXCEPTION_RECONNECT = 32773;//预览时重连
        public const int EXCEPTION_ALARMRECONNECT = 32774;//报警时重连
        public const int EXCEPTION_SERIALRECONNECT = 32775;//透明通道重连
        public const int EXCEPTION_PLAYBACK = 32784;//回放异常
        public const int EXCEPTION_DISKFMT = 32785;//硬盘格式化

        /********************预览回调函数*********************/
        public const int NET_DVR_SYSHEAD = 1;//系统头数据
        public const int NET_DVR_STREAMDATA = 2;//视频流数据（包括复合流和音视频分开的视频流数据）
        public const int NET_DVR_AUDIOSTREAMDATA = 3;//音频流数据
        public const int NET_DVR_STD_VIDEODATA = 4;//标准视频流数据
        public const int NET_DVR_STD_AUDIODATA = 5;//标准音频流数据

        //回调预览中的状态和消息
        public const int NET_DVR_REALPLAYEXCEPTION = 111;//预览异常
        public const int NET_DVR_REALPLAYNETCLOSE = 112;//预览时连接断开
        public const int NET_DVR_REALPLAY5SNODATA = 113;//预览5s没有收到数据
        public const int NET_DVR_REALPLAYRECONNECT = 114;//预览重连

        /********************回放回调函数*********************/
        public const int NET_DVR_PLAYBACKOVER = 101;//回放数据播放完毕
        public const int NET_DVR_PLAYBACKEXCEPTION = 102;//回放异常
        public const int NET_DVR_PLAYBACKNETCLOSE = 103;//回放时候连接断开
        public const int NET_DVR_PLAYBACK5SNODATA = 104;//回放5s没有收到数据

        /*********************回调函数类型 end************************/
        //设备型号(DVR类型)
        /* 设备类型 */
        public const int DVR = 1;/*对尚未定义的dvr类型返回NETRET_DVR*/
        public const int ATMDVR = 2;/*atm dvr*/
        public const int DVS = 3;/*DVS*/
        public const int DEC = 4;/* 6001D */
        public const int ENC_DEC = 5;/* 6001F */
        public const int DVR_HC = 6;/*8000HC*/
        public const int DVR_HT = 7;/*8000HT*/
        public const int DVR_HF = 8;/*8000HF*/
        public const int DVR_HS = 9;/* 8000HS DVR(no audio) */
        public const int DVR_HTS = 10; /* 8016HTS DVR(no audio) */
        public const int DVR_HB = 11; /* HB DVR(SATA HD) */
        public const int DVR_HCS = 12; /* 8000HCS DVR */
        public const int DVS_A = 13; /* 带ATA硬盘的DVS */
        public const int DVR_HC_S = 14; /* 8000HC-S */
        public const int DVR_HT_S = 15;/* 8000HT-S */
        public const int DVR_HF_S = 16;/* 8000HF-S */
        public const int DVR_HS_S = 17; /* 8000HS-S */
        public const int ATMDVR_S = 18;/* ATM-S */
        public const int LOWCOST_DVR = 19;/*7000H系列*/
        public const int DEC_MAT = 20; /*多路解码器*/
        public const int DVR_MOBILE = 21;/* mobile DVR */
        public const int DVR_HD_S = 22;   /* 8000HD-S */
        public const int DVR_HD_SL = 23;/* 8000HD-SL */
        public const int DVR_HC_SL = 24;/* 8000HC-SL */
        public const int DVR_HS_ST = 25;/* 8000HS_ST */
        public const int DVS_HW = 26; /* 6000HW */
        public const int DS630X_D = 27; /* 多路解码器 */
        public const int IPCAM = 30;/*IP 摄像机*/
        public const int MEGA_IPCAM = 31;/*X52MF系列,752MF,852MF*/
        public const int IPCAM_X62MF = 32;/*X62MF系列可接入9000设备,762MF,862MF*/
        public const int IPDOME = 40; /*IP 标清球机*/
        public const int IPDOME_MEGA200 = 41;/*IP 200万高清球机*/
        public const int IPDOME_MEGA130 = 42;/*IP 130万高清球机*/
        public const int IPMOD = 50;/*IP 模块*/
        public const int DS71XX_H = 71;/* DS71XXH_S */
        public const int DS72XX_H_S = 72;/* DS72XXH_S */
        public const int DS73XX_H_S = 73;/* DS73XXH_S */
        public const int DS76XX_H_S = 76;/* DS76XX_H_S */
        public const int DS81XX_HS_S = 81;/* DS81XX_HS_S */
        public const int DS81XX_HL_S = 82;/* DS81XX_HL_S */
        public const int DS81XX_HC_S = 83;/* DS81XX_HC_S */
        public const int DS81XX_HD_S = 84;/* DS81XX_HD_S */
        public const int DS81XX_HE_S = 85;/* DS81XX_HE_S */
        public const int DS81XX_HF_S = 86;/* DS81XX_HF_S */
        public const int DS81XX_AH_S = 87;/* DS81XX_AH_S */
        public const int DS81XX_AHF_S = 88;/* DS81XX_AHF_S */
        public const int DS90XX_HF_S = 90;  /*DS90XX_HF_S*/
        public const int DS91XX_HF_S = 91;  /*DS91XX_HF_S*/
        public const int DS91XX_HD_S = 92; /*91XXHD-S(MD)*/
        /**********************设备类型 end***********************/

        public const int MAX_SUBSYSTEM_NUM = 80;   //一个矩阵系统中最多子系统数量
        public const int MAX_SUBSYSTEM_NUM_V40 = 120;   //一个矩阵系统中最多子系统数量
        public const int MAX_SERIALLEN = 36;  //最大序列号长度
        public const int MAX_LOOPPLANNUM = 16;  //最大计划切换组
        public const int DECODE_TIMESEGMENT = 4;     //计划解码每天时间段数

        public const int MAX_DOMAIN_NAME = 64;  /* 最大域名长度 */
        public const int MAX_DISKNUM_V30 = 33; //9000设备最大硬盘数/* 最多33个硬盘(包括16个内置SATA硬盘、1个eSATA硬盘和16个NFS盘) */
        public const int MAX_DAYS = 7;       //每周天数
        public const int MAX_DISPNUM_V41 = 32;
        public const int MAX_WINDOWS_NUM = 12;
        public const int MAX_VOUTNUM = 32;
        public const int MAX_SUPPORT_RES = 32;
        public const int MAX_BIGSCREENNUM = 100;

        public const int VIDEOPLATFORM_ABILITY = 0x210; //视频综合平台能力集
        public const int MATRIXDECODER_ABILITY_V41 = 0x260; //解码器能力集

        public const int NET_DVR_MATRIX_BIGSCREENCFG_GET = 1140;//获取大屏拼接参数     


        //海康播放控制器宏定义及结构体
        #region PLAYM4

        //播放最大的通道数
        public const int PLAYM4_MAX_SUPPORTS = 500;
        //系数范围
        public const int MIN_WAVE_COEF = -100;
        public const int MAX_WAVE_COEF = 100;

        //计时器类型
        public const int TIMER_1 = 1;//Only 16 timers for every process.Default TIMER;
        public const int TIMER_2 = 2;//Not limit;But the precision less than TIMER_1;

        //缓冲或者是数据类型
        public const int BUF_VIDEO_SRC = 1;//混合输入，总资源缓冲区大小；分离输入，视频资源缓冲区大小
        public const int BUF_AUDIO_SRC = 2;//未定义很合输入；分离输入，音频资源缓冲大小
        public const int BUF_VIDEO_RENDER = 3;//视频渲染节点数
        public const int BUF_AUDIO_RENDER = 4;//音频渲染节点数
        public const int BUF_VIDEO_DECODED = 5;//要解码的视频解码节点数
        public const int BUF_AUDIO_DECODED = 6;//要解码的音频解码节点数

        //错误代码
        public const int PLAYM4_NOERROR = 0;//没有错误
        public const int PLAYM4_PARA_OVER = 1;//输入参数无效
        public const int PLAYM4_ORDER_ERROR = 2;//该函数调用顺序有误
        public const int PLAYM4_TIMER_ERROR = 3;//创建多媒体始终错误
        public const int PLAYM4_DEC_VIDEO_ERROR = 4;//解码视频数据失败
        public const int PLAYM4_DEC_AUDIO_ERROR = 5;//解码音频数据失败
        public const int PLAYM4_ALLOC_MEMORY_ERROR = 6;//申请内存时间失败
        public const int PLAYM4_OPEN_FILE_ERROR = 7;//打开文件失败
        public const int PLAYM4_CREATE_OBJ_ERROR = 8;//创建的线程或事件失败
        public const int PLAYM4_CREATE_DDRAW_ERROR = 9;//创建DirectDraw 对象失败
        public const int PLAYM4_CREATE_OFFSCREEN_ERROR = 10;//创建屏外资源失败
        public const int PLAYM4_BUF_OVER = 11;//缓冲区溢出
        public const int PLAYM4_CREATE_SOUND_ERROR = 12;//创建音频驱动时失败
        public const int PLAYM4_SET_VOLUME_ERROR = 13;//设定音量失败
        public const int PLAYM4_SUPPORT_FILE_ONLY = 14;//该功能仅支持播放文件
        public const int PLAYM4_SUPPORT_STREAM_ONLY = 15;//该功能仅支持播放流
        public const int PLAYM4_SYS_NOT_SUPPORT = 16;//系统不支持
        public const int PLAYM4_FILEHEADER_UNKNOWN = 17;//没有文件头
        public const int PLAYM4_VERSION_INCORRECT = 18;//解码器和编码器的版本不适用
        public const int PLAYM4_INIT_DECODER_ERROR = 19;//初始化解码器失败
        public const int PLAYM4_CHECK_FILE_ERROR = 20;//未知的文件数据
        public const int PLAYM4_INIT_TIMER_ERROR = 21;//初始化多媒体时钟失败
        public const int PLAYM4_BLT_ERROR = 22;//位拷贝失败(32位播放库下容易出现此问题，主要是渲染创建失败）
        public const int PLAYM4_UPDATE_ERROR = 23;// 显示overlay失败；
        public const int PLAYM4_OPEN_FILE_ERROR_MULTI = 24;//打开文件失败，流类型是复合流
        public const int PLAYM4_OPEN_FILE_ERROR_VIDEO = 25;//打开文件失败，流类型是视频流
        public const int PLAYM4_JPEG_COMPRESS_ERROR = 26;//JPEG压缩失败
        public const int PLAYM4_EXTRACT_NOT_SUPPORT = 27;//文件不支持
        public const int PLAYM4_EXTRACT_DATA_ERROR = 28;//数据错误
        public const int PLAYM4_SECRET_KEY_ERROR = 29;//解码关键帧失败
        public const int PLAYM4_DECODE_KEYFRAME_ERROR = 30;//解码关键帧失败
        public const int PLAYM4_NEED_MORE_DATA = 31;//数据不足
        public const int PLAYM4_INVALID_PORT = 32;//无效端口号;
        public const int PLAYM4_NOT_FIND = 33;//查找失败；
        public const int PLAYM4_NEED_LARGER_BUFFER = 34;//需要更大的缓冲区；
        public const int PLAYM4_FAIL_UNKNOWN = 99;//未知的错误

        //鱼眼部分错误码
        public const int PLAYM4_FEC_ERR_ENABLEFAIL = 100;//鱼眼模块加载失败;
        public const int PLAYM4_FEC_ERR_NOTENABLE = 101;//鱼眼模块没有加载;
        public const int PLAYM4_FEC_ERR_NOSUBPORT = 102;//子端口没有分配;
        public const int PLAYM4_FEC_ERR_PARAMNOTINIT = 103;//没有初始化对应端口的参数;
        public const int PLAYM4_FEC_ERR_SUBPORTOVER = 104;//子端口已经用完;
        public const int PLAYM4_FEC_ERR_EFFECTNOTSUPPORT = 105;//该安装方式下这种效果不支持;
        public const int PLAYM4_FEC_ERR_INVALIDWND = 106;//非法的窗口;
        public const int PLAYM4_FEC_ERR_PTZOVERFLOW = 107;//PTZ位置越界;
        public const int PLAYM4_FEC_ERR_RADIUSINVALID = 108;//圆心参数非法;
        public const int PLAYM4_FEC_ERR_UPDATENOTSUPPORT = 109;//指定的安装方式和矫正效果，该参数更新不支持;
        public const int PLAYM4_FEC_ERR_NOPLAYPORT = 110;//播放库端口没有启用;
        public const int PLAYM4_FEC_ERR_PARAMVALID = 111;//参数为空;
        public const int PLAYM4_FEC_ERR_INVALIDPORT = 112;//非法子窗口;
        public const int PLAYM4_FEC_ERR_PTZZOOMOVER = 113;//PTZ矫正范围越界;
        public const int PLAYM4_FEC_ERR_OVERMAXPORT = 114;//矫正通道饱和，最大支持的矫正通道为四个;
        public const int PLAYM4_FEC_ERR_ENABLED = 116;//D3D加速没有开启;
        public const int PLAYM4_FEC_ERR_PLACETYPE = 117;//安装方式不正确；一个播放库port需要对应一种安装方式;
        public const int PLAYM4_FEC_ERR_CorrectType = 118;//矫正方式错误：如矫正方式已有，则不能开多个；比如一个播放库port设定除了PTZ和鱼眼半球矫正方式外，其他的矫正方式则只能开一路；设置180度矫正不能和PTZ矫正仪器开，半球矫正与其他矫正则无关联性。;
        public const int PLAYM4_FEC_ERR_NULLWND = 119;//鱼眼窗口为NULL;
        public const int PLAYM4_FEC_ERR_PARA = 120;//鱼眼参数错误;

        public const int MAX_DISPLAY_WND = 4;//最大显示区域

        public const int DISPLAY_NORMAL = 0x00000001;
        public const int DISPLAY_QUARTER  =   0x00000002;
        public const int DISPLAY_YC_SCALE =   0x00000004;
        public const int DISPLAY_NOTEARING =  0x00000008;

        //展示缓存
        public const int MAX_DIS_FRAMES = 50;
        public const int MIN_DIS_FRAMES = 1;

        //流的定位方式
        public const int BY_FRAMENUM = 1;   //帧数
        public const int BY_FRAMETIME = 2;  //帧时间
        //资源缓存
        public const int SOURCE_BUF_MAX = 1024 * 100000;
        public const int SOURCE_BUF_MIN = 1024 * 50;

        //流的类型
        public const int STREAME_REALTIME = 0;  //实时流
        public const int STREAME_FILE = 1;//从文件读取

        //帧格式
        public const int T_AUDIO16 = 101;//音频16位采样
        public const int T_AUDIO8 = 100;    //音频8位采样
        public const int T_UYVY = 1;//视频UYVY格式
        public const int T_YV12 = 3;//YV12格式
        public const int T_REG32 = 7;   //RGB格式

        //性能
        public const int SUPPORT_DDRAW = 1;//支持DIRECTDRAW；如果不支持，则播放器不能工作。
        public const int SUPPORT_BLT = 2;//显卡支持BLT操作；如果不支持，则播放器不能工作。
        public const int SUPPORT_BLTFOURCC = 4;//显卡BLT支持颜色转换；如果不支持，播放器会使用软件方式作RGB转换。
        public const int SUPPORT_BLTSHRINKX = 8;//显卡BLT支持X轴缩小；如果不支持，系统使用软件方式转换。
        public const int SUPPORT_BLTSHRINKY = 16;//显卡BLT支持Y轴缩小；如果不支持，系统使用软件方式转换。
        public const int SUPPORT_BLTSTRETCHX = 32;//显卡BLT支持X轴放大；如果不支持，系统使用软件方式转换。
        public const int SUPPORT_BLTSTRETCHY = 64;//显卡BLT支持Y轴放大；如果不支持，系统使用软件方式转换。
        public const int SUPPORT_SSE = 128;//CPU支持SSE指令,Intel Pentium3以上支持SSE指令。
        public const int SUPPORT_MMX = 256;//CPU支持MMX指令集。

        public const int FOURCC_HKMI = 0x484B4D49; //"HKMI" HIK_MEDIAINFO结构标记

        //系统封装格式
        public const int SYSTEM_NULL = 0x0;//没有系统层，纯音频流或视频流
        public const int SYSTEM_HIK = 0x1;//海康文件层
        public const int SYSTEM_MPEG2_PS = 0x2;//PS封装
        public const int SYSTEM_MPEG2_TS = 0x3;//TS封装
        public const int SYSTEM_RTP = 0x4;//rtp封装
        public const int SYSTEM_AVC264 = 0x401;//AVC 264封装

        //视频编码类型
        public const int VIDEO_NULL = 0x0;//没有视频
        public const int VIDEO_H264 = 0x1;//海康H.264
        public const int VIDEO_MPEG2 = 0x2;//标准MPEG2
        public const int VIDEO_MPEG4 = 0x3;//标准MPEG4
        public const int VIDEO_MGPEG = 0x4;
        public const int VIDEO_AVC264 = 0x0100;

        //音频编码类型
        public const int AUDIO_NULL = 0x0;//没有音频
        public const int AUDIO_ADPCM = 0x1000;//ADPCM
        public const int AUDIO_MPEG = 0x2000;//MPEG系列音频
        public const int AUDIO_AAC = 0x2001;//AAC编码
        public const int AUDIO_RAW_DATA8 = 0x7000;//采样率为8k的原始数据
        public const int AUDIO_RAW_UDATA16 = 0x7001;//采样率为16k的原始数据，即L16

        //G系列音频
        public const int AUDIO_G711_U = 0x7110;
        public const int AUDIO_G711_A = 0x7111;
        public const int AUDIO_G722_1 = 0x7221;
        public const int AUDIO_G723_1 = 0x7231;
        public const int AUDIO_G726_U = 0x7260;
        public const int AUDIO_G726_A = 0x7261;
        public const int AUDIO_G726_16 = 0x7262;
        public const int AUDIO_G729 = 0x7290;
        public const int AIDIO_AMR_NB = 0x3000;

        public const int SYNCDATA_VEH = 1;//同步数据：车载信息
        public const int SYNCDATA_IVS = 2;//同步数据：智能信息

        //动态流类型
        public const int MOTION_FLOW_NONE = 0;
        public const int MOTION_FLOW_CPU = 1;
        public const int MOTION_FLOW_GPU = 2;

        //音视频加密模式
        public const int ENCRYPT_AES_3R_VIDEO = 1;
        public const int ENCRYPT_AES_10R_VIDEO = 2;
        public const int ENCRYPT_AES_3R_AUDIO = 1;
        public const int ENCRYPT_AES_10R_AUDIO = 2;

        //旋转角度
        public const int R_ANGLE_0 = -1;    //不旋转
        public const int R_ANGLE_L90 = 0;   //左旋90度
        public const int R_ANGLE_R90 = 1;//右旋90度
        public const int R_ANGLE_180 = 2;//旋转180度


        #endregion
    }
}
