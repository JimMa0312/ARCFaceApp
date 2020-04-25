using ArcSoftFace.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARCSoftFaceApp.Util.ARCFace
{
    public class ARCFaceEngineUtils
    {
        /// <summary>
        /// 注册并激活 虹软人脸识别SDK引擎
        /// 
        /// 需要获取APP_ID，SDKKEY64(从虹软官网申请)
        /// </summary>
        /// <returns>返回执行结果</returns>
        public static int InitARCFaceEngine()
        {
            //读取App.config文件
            AppSettingsReader appSetting = new AppSettingsReader();
            string appId = (string)appSetting.GetValue("APP_ID", typeof(string));
            string sdkKey64 = (string)appSetting.GetValue("SDKKEY64", typeof(string));
            string sdkKet32 = (string)appSetting.GetValue("SDKKEY32", typeof(string));

            //判断运行的CPU位数
            var is64CPU = Environment.Is64BitProcess;
            if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(is64CPU?sdkKey64:sdkKet32))
            {
                MessageBox.Show($"请在App.Config配置文件中先配置APP_ID和SDKKEY{(is64CPU ? 64:32)}");
                return -1;
            }

            //用来存储 人脸识别SDK 申请激活后的结果
            int result = 0;
            try
            {
                result = ASFFunctions.ASFActivation(appId, is64CPU ? sdkKey64 : sdkKet32);
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("无法加载DLL"))
                {
                    MessageBox.Show("请将sdk相关DLL放入bin对应的x86或x64下的文件夹中!");
                }
                else
                {
                    MessageBox.Show("引擎初始化失败！");
                }

                return -2;
            }

            LoggerService.logger.Info("人脸识别引擎激活成功。");

            return result;
        }
    }
}
