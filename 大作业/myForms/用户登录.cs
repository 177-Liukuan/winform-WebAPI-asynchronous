
using AutoScaleHelper;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using 大作业;
using 大作业.DBModel;
using 大作业.myForms;

namespace 窗体实验
{

    public partial class 用户登录 : Form
    {
        //记录登录错误次数
        private int cnt = 0;
        //存储天气详情
        private List<天气预测> casts;
        //记录换页情况，点击button3减去1，点击button4加上1
        private int castIndex = 0;

        //静态实例，用于全局共享
        public static readonly HttpClient clientInstance = new HttpClient();

        AutoScale autoScale = new AutoScale();


        public 用户登录()
        {
            InitializeComponent();
            textBox1.Focus();
            autoScale.SetContainer(this);

            // 设置ToolTip的初始延迟时间为0，以便立即显示
            toolTip1.InitialDelay = 1;
            // 设置ToolTip的内容
            toolTip1.SetToolTip(label10, "该功能暂未实现！");
        }


        private void 用户登录_Resize(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //点击按钮后退出程序
            Application.Exit();
        }
        private async Task<用户实体> checkUserAsync(string name)
        {

            try
            {
                // URL
                string url = "API'URL";


                // 设置请求头，这里假设服务器期望的是JSON格式的内容
                clientInstance.DefaultRequestHeaders.Accept.Clear();
                clientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // 创建POST请求的内容
                var jsonContent = new StringContent(JsonConvert.SerializeObject(new { 用户名 = name }), Encoding.UTF8, "application/json");

                // 发送POST请求
                HttpResponseMessage response = await clientInstance.PostAsync(url, jsonContent);

                // 确保响应成功
                response.EnsureSuccessStatusCode();

                // 读取响应内容
                string responseBody = await response.Content.ReadAsStringAsync();

                // 反序列化JSON响应到用户实体类
                var datas = JsonConvert.DeserializeObject<APIDataResult<用户实体[]>>(responseBody);


                // 返回用户实体
                return datas.Data[0];


            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("获取用户信息失败，请检查网络连接！");

                return null;
            }
            catch (System.IndexOutOfRangeException e)
            {
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("未知错误！");
                return null;
            }

        }



        //引入异步编程，实现连续错误3次后禁止点击“登录”按钮3s
        private async void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                textBox1.Focus();
                cnt++;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                textBox2.Focus();
                cnt++;
            }
            else
            {
                //调用异步方法获取用户密码，是I/O密集型操作，不用开启新线程
                var user = await checkUserAsync(textBox1.Text);

                if (user == null)
                {

                    MessageBox.Show("用户名不存在！");
                    cnt++;
                }
                else
                {
                    //如果错误3次，则在3s内禁止点击“登录”按钮
                    if (textBox2.Text == user.密码)
                    {
                        MessageBox.Show("登录成功！");
                        soleUser.OperatorName = textBox1.Text;
                        soleUser.PassWord = textBox2.Text;
                        await ShowMainForm();
                    }
                    else
                    {
                        cnt++;
                        MessageBox.Show("密码错误！");
                        textBox1.Focus();
                    }
                }


            }





            //每一次按钮的点击事件都会检查错误次数，如果错误次数超过3次，则禁止点击“登录”按钮3s

            if (cnt >= 3)
            {
                button1.Enabled = false;
                Color co = button1.BackColor;

                MessageBox.Show("错误次数过多，请3s后再试！");
                button1.BackColor = Color.Red;

                await Task.Delay(3000);
                button1.BackColor = co;
                button1.Enabled = true;
                cnt = 0;
                textBox1.Focus();


            }
        }

        // 在this窗体中订阅事件并处理关闭逻辑
        private async Task ShowMainForm()
        {
            var main = new 主页();
            main.MainClosed += () =>
            {
                try
                {
                    this.Close();
                }
                catch (Exception ex)
                {
                    // 处理异常，例如记录日志
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            };
            main.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // 当用户名输入文本框内容输入完成后回车，聚焦到口令输入文本框textBox2
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // 当口令输入文本框内容输入完成后回车，聚焦到登录按钮button1
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }



        private void 用户登录_Load(object sender, EventArgs e)
        {
            //设置button3和4的边框隐藏
            setMyButton();

            //加载天气
            setGaoDeWeatherAsync();

        }

        private void setMyButton()
        {
            // 将button3和4的边框隐藏
            button3.FlatStyle = FlatStyle.Flat; // 设置按钮为扁平样式以便更改边框大小
            button3.FlatAppearance.BorderSize = 0; // 设置按钮边框大小为像素
            button4.FlatStyle = FlatStyle.Flat; // 设置按钮为扁平样式以便更改边框大小
            button4.FlatAppearance.BorderSize = 0; // 设置按钮边框大小为像素
        }

        private async Task setGaoDeWeatherAsync()
        {

            HttpResponseMessage response = await clientInstance.GetAsync("API’S URL");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // responseBody变量中将包含WebApi的响应数据
            var Weather = JsonConvert.DeserializeObject<天气预报>(responseBody);

            // 首先，解析JSON以获取"forecasts"部分
            var forecasts = Weather.预测;

            //然后，将报道时间、城市复制给label13和label17
            label13.Text = forecasts[0].报告时间;
            label17.Text = forecasts[0].城市;

            //接着，存储casts部分的天气预测，作为一个列表
            casts = forecasts[0].预测详情;

            //默认显示第一个天气预测
            label19.Text = casts[0].日期;
            label15.Text = casts[0].星期;
            label16.Text = casts[0].白天天气;
            label12.Text = casts[0].白天风向;
            label14.Text = casts[0].白天温度;




        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        //利用取模运算和按钮的点击事件实现天气预报的切换
        private void button3_Click_1(object sender, EventArgs e)
        {
            castIndex = (castIndex - 1 + casts.Count) % casts.Count;
            label19.Text = casts[castIndex].日期;
            label15.Text = casts[castIndex].星期;
            label16.Text = casts[castIndex].白天天气;
            label12.Text = casts[castIndex].白天风向;
            label14.Text = casts[castIndex].白天温度;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            castIndex = (castIndex + 1) % casts.Count;
            label19.Text = casts[castIndex].日期;
            label15.Text = casts[castIndex].星期;
            label16.Text = casts[castIndex].白天天气;
            label12.Text = casts[castIndex].白天风向;
            label14.Text = casts[castIndex].白天温度;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 用户登录_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private async void label11_Click_1(object sender, EventArgs e)
        {
            //点击后转入注册页面
            await ShowRegisterForm();



        }

        // 在this窗体中订阅事件并处理关闭逻辑
        private async Task ShowRegisterForm()
        {
            var register = new Register();
            register.RegisterClosed += () =>
            {
                try
                {
                    this.Show();
                }
                catch (Exception ex)
                {
                    // 处理异常，例如记录日志
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            };
            register.Show();
            this.Hide();
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            // 当鼠标进入Label时，改变字体为斜体
            label11.Font = new Font(label11.Font, FontStyle.Italic);
            // 当鼠标进入Label时，改变鼠标形状为手指
            label11.Cursor = Cursors.Hand;
            // 设置label11的前景色为红色
            label11.ForeColor = Color.Red;


        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            // 当鼠标离开Label时，恢复字体为正常样式
            label11.Font = new Font(label11.Font, FontStyle.Regular);
            // 当鼠标离开Label时，恢复鼠标形状为默认
            label11.Cursor = Cursors.Default;
            // 设置label11的前景色为黑色
            label11.ForeColor = Color.Black;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
