using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CSharpTcpDemo.com.dobot.api.com.dobot.api.bean;

namespace CSharpTcpDemo.com.dobot.api
{
    class ErrorInfoHelper
    {
        private static Dictionary<int, ErrorInfoBean> mAllBeans = new Dictionary<int, ErrorInfoBean>();
        public static void AddJsonFromFile(string strFullFile, string strType)
        {
            try
            {
                string strJson = System.IO.File.ReadAllText(strFullFile);
                List<ErrorInfoBean> result = JsonConvert.DeserializeObject<List<ErrorInfoBean>>(strJson);
                foreach (var bean in result)
                {
                    bean.Type = strType;
                    mAllBeans.Add(bean.id, bean);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static ErrorInfoBean Find(int id)
        {
            if (mAllBeans.ContainsKey(id))
            {
                return mAllBeans[id];
            }
            return null;
        }
    }
}
