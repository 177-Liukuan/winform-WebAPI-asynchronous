using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 大作业.DBModel
{
    public class 用户实体
    {
        public int 系统用户ID { get; set; }

        public string? 用户名 { get; set; }

        public string? 密码 { get; set; }

        public string? 手机号 { get; set; }

        public string? 邮箱 { get; set; }

        public int? 性别 { get; set; }

        public int? 年龄 { get; set; }

        public string? 头像URL { get; set; }

        public DateTime? 注册时刻 { get; set; }

        public DateTime? 最后登陆时刻 { get; set; }

        public int? 状态 { get; set; }

        public string? 其他 { get; set; }

        public string? 角色ID { get; set; }

        public string? WeChatOpenID { get; set; }
    }
}
