using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 大作业.DBModel
{
    public class 药品实体
    {
        public int 药品ID { get; set; }

        public string? 药品名称 { get; set; }

        public string? 批准文号 { get; set; }

        public int? OTC { get; set; }

        public string? 成分 { get; set; }

        public string? 性状 { get; set; }

        public string? 功能 { get; set; }

        public string? 规格 { get; set; }

        public string? 使用方法 { get; set; }

        public string? 不良反应 { get; set; }

        public string? 警告 { get; set; }

        public string? 药物相互作用 { get; set; }

        public string? 药理作用 { get; set; }

        public string? 有效期 { get; set; }

        public string? 保存 { get; set; }

        public string? 批准 { get; set; }

        public DateTime? 创建时间 { get; set; }

        public DateTime? 修改时间 { get; set; }

        public int? 状态 { get; set; }

        public int 信息录入者 { get; set; }
    }
}
