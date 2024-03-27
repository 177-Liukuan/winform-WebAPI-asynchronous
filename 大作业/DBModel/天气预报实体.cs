using Newtonsoft.Json;

public class 天气预报
{
    [JsonProperty("status")]
    public string 状态 { get; set; }

    [JsonProperty("count")]
    public string 数量 { get; set; }

    [JsonProperty("info")]
    public string 信息 { get; set; }

    [JsonProperty("infocode")]
    public string 信息代码 { get; set; }

    [JsonProperty("forecasts")]
    public 预报[] 预测 { get; set; }
}

public class 预报
{
    [JsonProperty("city")]
    public string 城市 { get; set; }

    [JsonProperty("adcode")]
    public string 行政编码 { get; set; }

    [JsonProperty("province")]
    public string 省份 { get; set; }

    [JsonProperty("reporttime")]
    public string 报告时间 { get; set; }

    [JsonProperty("casts")]
    public List<天气预测> 预测详情 { get; set; }

}

public class 天气预测
{
    [JsonProperty("date")]
    public string 日期 { get; set; }

    [JsonProperty("week")]
    public string 星期 { get; set; }

    [JsonProperty("dayweather")]
    public string 白天天气 { get; set; }

    [JsonProperty("nightweather")]
    public string 夜晚天气 { get; set; }

    [JsonProperty("daytemp")]
    public string 白天温度 { get; set; }

    [JsonProperty("nighttemp")]
    public string 夜晚温度 { get; set; }

    [JsonProperty("daywind")]
    public string 白天风向 { get; set; }

    [JsonProperty("nightwind")]
    public string 夜晚风向 { get; set; }

    [JsonProperty("daypower")]
    public string 白天风力 { get; set; }

    [JsonProperty("nightpower")]
    public string 夜晚风力 { get; set; }
}

