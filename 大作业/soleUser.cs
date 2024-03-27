using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大作业
{
    //创建一个静态的类，用于存储当前登录的用户
    public static class soleUser
    {
        private static string m_OperatorName;
        /// 操作员名称
        public static string OperatorName
        {
            get
            {
                return m_OperatorName;
            }
            set
            {
                m_OperatorName = value;
            }
        }

        private static string m_PassWord;
        /// 操作员密码
        public static string PassWord
        {
            get
            {
                return m_PassWord;
            }
            set
            {
                m_PassWord = value;
            }
        }

    }


}
