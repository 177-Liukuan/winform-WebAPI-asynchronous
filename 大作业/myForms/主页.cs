using AutoScaleHelper;
using Newtonsoft.Json;
using 大作业.DBModel;
using 窗体实验;
using static System.Net.Http.HttpClient;
using static System.Net.HttpWebRequest;

// 天气API:https://restapi.amap.com/v3/weather/weatherInfo?city=%E6%00d232e40907be8fe4a298&extensions=all&output=json

namespace 大作业
{
    public partial class 主页 : Form
    {

        public event Action MainClosed;
        AutoScale autoScale = new AutoScale();

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            MainClosed?.Invoke();
        }
        public 主页()
        {
            InitializeComponent();
            autoScale.SetContainer(this);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 使用HttpClient发送GET请求
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://xxxx/api/Drug/GetAllDrugsInfo");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // responseBody变量中将包含WebApi的响应数据


            // 首先，解析JSON以获取"data"部分
            var dataObject = JsonConvert.DeserializeObject<APIDataResult<List<药品实体>>>(responseBody);

            // 然后，将"data"部分设置为dataGridView1的数据源
            dataGridView1.DataSource = dataObject.Data;

        }

        private void 大作业_Load(object sender, EventArgs e)
        {
            MessageBox.Show("不引入异步编程技术，在进行网络I/O或磁盘I/O（数据库）会阻塞UI线程，即窗体会被“卡住”，用户进行不了其他操作。如果IO数据量很大，卡住的时间很长，用户将会很“难受”。引入后，在数据显示之前也可以进行其他操作，可以点击下方橙色验证按钮验证", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //按钮2的点击时间用于获取 GET API数据，并且将数据显示在dataGridView2中







        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 主页_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //异步验证按钮，在进行网络I/O时不阻塞UI线程
            MessageBox.Show("验证成功!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //清空dataGridView1
            dataGridView1.DataSource = null;
        }

        private void 主页_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }
    }
}

