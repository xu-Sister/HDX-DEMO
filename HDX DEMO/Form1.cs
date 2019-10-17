using System;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;

namespace HDX_DEMO
{
    /// <summary>
    /// 读卡后最好是有每读一张卡能叠加数量、显示卡号、显示日期时间，数据可清空、可保存。模块与读卡器波特率不同，也要可选波特率，新增连接网口功能
    /// </summary>

    public partial class Form1 : Form
    {
        UInt64 Time_NR;

        int RX_DATA_NN;

        int RX_DATA_SP = 0;

        private static string Transfer;

        HashSet<string> cardSet = new HashSet<string> { }; 

        private static byte[] RecData = new byte[500];

        private static byte[] Rx_Data = new byte[500];

        private static byte[] RX_temp_H = new byte[30];

        Socket socket;

        int ConnTypes = 0; 

        public Form1()
        {
            InitializeComponent();

            myPort.DataReceived += new SerialDataReceivedEventHandler(MyPort_DataReceived);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SearchAddPort();

            ruteCom.Items.Add("1200");
            ruteCom.Items.Add("2400");
            ruteCom.Items.Add("4800");
            ruteCom.Items.Add("9600");
            ruteCom.Items.Add("19200");
            ruteCom.Items.Add("38400");
            ruteCom.Items.Add("56000");
            ruteCom.Items.Add("57600");
            ruteCom.Items.Add("115200");

            ruteCom.SelectedIndex = 3;

            proCom.Items.Add("TCP Server");
            //proCom.Items.Add("TCP Client");
            //proCom.Items.Add("UDP");

            chsBtn.Checked = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Time_NR = 5;            
            try
            {
                for (; Time_NR > 0; Time_NR--)
                {
                    Thread.Sleep(10);
                    RX_DATA_NN = myPort.BytesToRead;

                    if (RX_DATA_NN > 0)
                    {
                        //if (RX_DATA_NN > RecData.Length) RX_DATA_NN = RecData.Length;
                        Byte[] buf = new Byte[RX_DATA_NN];
                        myPort.Read(buf, 0, RX_DATA_NN);

                        for (int i = 0; i < RX_DATA_NN; i++)
                        {
                            RX_temp_H[2] = RX_temp_H[1];
                            RX_temp_H[1] = RX_temp_H[0];
                            RX_temp_H[0] = buf[i];

                            if (RX_temp_H[0] == 0x24)
                            {
                                RX_DATA_SP = 0;
                            }
                            RecData[RX_DATA_SP] = buf[i];
                            RX_DATA_SP++;

                            if (((buf[i] == 0x23) && (RecData[0] == 0x24) && RecData[1] == 0x52))   //显示问题
                            {
                                //当有一包完整的数据进来的时候      
                                if (RecData[0] == 0x24 && RecData[1] == 0x52 )   //当有为数据卡的时候输出
                                {
                                    string transf = Encoding.ASCII.GetString(RecData);                    //$R383E7006581D71767#$T026836B#
                                    string AString = Encoding.ASCII.GetString(RecData).Substring(4, 13);  //得出卡号                                    
                                    if (AString.Length != 14)
                                    {
                                        AString = AString.PadLeft(14, '0');
                                        byte[] toByte = new byte[7];
                                        transf = null;
                                        for (int j = 0; j < toByte.Length; j++)
                                        {
                                            toByte[j] = Convert.ToByte(AString.Substring(j * 2, 2), 16);
                                            transf += toByte[j].ToString("X2");
                                        }
                                        counBtn.Text = long.Parse(transf.Substring(0, 4), System.Globalization.NumberStyles.HexNumber).ToString();
                                        cardBtn.Text = long.Parse(transf.Substring(4, 10), System.Globalization.NumberStyles.HexNumber).ToString();
                                        if ((Transfer != cardBtn.Text))
                                        {
                                            Transfer = cardBtn.Text;
                                            outputBox.Text += DateTime.Now.ToString() + "  " + counBtn.Text + " " + cardBtn.Text.PadLeft(12,'0') + "\r\n";   //时间加卡号                        
                                        }
                                    }
                                    cardSet.Add((counBtn.Text + cardBtn.Text).ToString());

                                    string sigText = Encoding.ASCII.GetString(RecData);
                                    string Sigstring = Encoding.ASCII.GetString(RecData).Substring(22, 5);
                                    if (Sigstring.Length != 6)
                                    {
                                        Sigstring = Sigstring.Substring(0, 4) + "0" + Sigstring.Substring(4, 1);
                                    }
                                    byte[] sigtoBye = new byte[3];
                                    sigText = null;
                                    for (int j = 0; j < sigtoBye.Length; j++)
                                    {
                                        sigtoBye[j] = Convert.ToByte(Sigstring.Substring(j * 2, 2), 16);
                                        sigText += sigtoBye[j].ToString("X2");
                                    }

                                    sig1Btn.Text = long.Parse(sigText.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                                    sig2Btn.Text = long.Parse(sigText.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                                    synBtn.Text = long.Parse(sigText.Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                                    countBtn.Text = cardSet.Count.ToString();
                                }
                                else if (RecData[0] == 0x24 && RecData[1] == 0x54)
                                {
                                    string sigText = Encoding.ASCII.GetString(RecData);   //$T0262163#
                                    string Sigstring = Encoding.ASCII.GetString(RecData).Substring(2, 5);
                                    if (Sigstring.Length != 6)
                                    {
                                        Sigstring = Sigstring.Substring(0, 4) + "0" + Sigstring.Substring(4, 1);
                                    }
                                    byte[] sigtoBye = new byte[3];
                                    sigText = null;
                                    for (int j = 0; j < sigtoBye.Length; j++)
                                    {
                                        sigtoBye[j] = Convert.ToByte(Sigstring.Substring(j * 2, 2), 16);
                                        sigText += sigtoBye[j].ToString("X2");
                                    }
                                    //string sigText = AsciiToString(RecData, 2, 5);
                                    sig1Btn.Text = long.Parse(sigText.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                                    sig2Btn.Text = long.Parse(sigText.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                                    synBtn.Text = long.Parse(sigText.Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                                }
                                RX_DATA_SP = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        void SocketRecive()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[100];
                    int r = socket.Receive(buffer);

                    string transf = Encoding.UTF8.GetString(buffer, 0, r);
                    string AString = Encoding.ASCII.GetString(buffer).Substring(4, 13);  //得出卡号                                    
                    if (AString.Length != 14)
                    {
                        AString = AString.PadLeft(14, '0');
                        byte[] toByte = new byte[7];
                        transf = null;
                        for (int j = 0; j < toByte.Length; j++)
                        {
                            toByte[j] = Convert.ToByte(AString.Substring(j * 2, 2), 16);
                            transf += toByte[j].ToString("X2");
                        }
                        counBtn.Text = long.Parse(transf.Substring(0, 4), System.Globalization.NumberStyles.HexNumber).ToString();
                        cardBtn.Text = long.Parse(transf.Substring(4, 10), System.Globalization.NumberStyles.HexNumber).ToString();
                        if ((Transfer != cardBtn.Text))
                        {
                            Transfer = cardBtn.Text;
                            Console.WriteLine(Transfer);
                            outputBox.Text += DateTime.Now.ToString() + "  " + counBtn.Text + " " + cardBtn.Text.PadLeft(12, '0') + "\r\n";   //时间加卡号                        
                        }
                    }
                    cardSet.Add((counBtn.Text + cardBtn.Text).ToString());

                    string sigText = Encoding.ASCII.GetString(buffer);
                    string Sigstring = Encoding.ASCII.GetString(buffer).Substring(22, 5);
                    if (Sigstring.Length != 6)
                    {
                        Sigstring = Sigstring.Substring(0, 4) + "0" + Sigstring.Substring(4, 1);
                    }
                    byte[] sigtoBye = new byte[3];
                    sigText = null;
                    for (int j = 0; j < sigtoBye.Length; j++)
                    {
                        sigtoBye[j] = Convert.ToByte(Sigstring.Substring(j * 2, 2), 16);
                        sigText += sigtoBye[j].ToString("X2");
                    }

                    sig1Btn.Text = long.Parse(sigText.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                    sig2Btn.Text = long.Parse(sigText.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                    synBtn.Text = long.Parse(sigText.Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                    countBtn.Text = cardSet.Count.ToString();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            string nCom = portCom.SelectedItem.ToString();
            string temp = ruteCom.SelectedItem.ToString();
            if (nCom == null || temp == null)
            {
                MessageBox.Show("请选择串口和波特率", "Error");
            }
            else 
            {
                OpenCom(nCom, int.Parse(temp));
                if (myPort.IsOpen)
                {
                    openBtn.Enabled = false;
                    ConnTypes = 1;
                }
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)             //关闭串口
        {
            CloseCom();
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (proCom.Text.Trim() != "" && ipText.Text.Trim() != "" && poText.Text.Trim() != "")
            {
                try
                {
                    //创建负责通信socket
                    if (proCom.Text == "TCP Server")
                    {
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    }
                    IPAddress ip = IPAddress.Parse(ipText.Text);
                    IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(poText.Text));

                    Console.WriteLine(ipText.Text + poText);
                    socket.Connect(point);

                    bool State = IsSocketConnected(socket);  //判断Socket是否连接成功
                    if (State == true)
                    {
                        outputBox.AppendText("连接成功" + "\r\n");
                        ConnTypes = 2;
                    }
                    else if (State == false)
                        outputBox.AppendText("连接失败" + "\r\n");

                    //单独的收发线程
                    Thread thread = new Thread(SocketRecive);
                    thread.IsBackground = true;
                    thread.Start();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Parameters cannot be null", "Error");
            }
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            bool State = IsSocketConnected(socket);
            if (State == true)
            {
                socket.Close(); 
                outputBox.AppendText("断开监听" + "\r\n");
                ConnTypes = 0;
            }
        }
        private bool IsSocketConnected(Socket socket)
        {
            bool blockingState = socket.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                socket.Blocking = false;
                socket.Send(tmp, 0, 0);
                return true;
            }
            catch (SocketException ex)
            {
                if (ex.NativeErrorCode.Equals(10035))
                {
                    return false;
                }
                else
                    return true;
            }
            finally
            {
                socket.Blocking = blockingState;
            }
        }
        private void EnBtn_CheckedChanged(object sender, EventArgs e)       //转换语言-英文
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            UpDataMainFormUILanguage();
        }
        private void ChsBtn_CheckedChanged(object sender, EventArgs e)      //转换语言-中文
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
            UpDataMainFormUILanguage();
        }
        private void ClearBtn_Click(object sender, EventArgs e)             //清空数据
        {
            outputBox.Clear();
        }
        private void CcrdBtn_Click(object sender, EventArgs e)               //清空卡数量
        {
            countBtn.Text = "";
            cardSet.Clear();
        }
        private void OutDataBtn_Click(object sender, EventArgs e)          //导出数据
        {
            OutPut();
        }
        private void OpenAnBtn_Click(object sender, EventArgs e)           //打开天线
        {
            byte[] OpenAn = new byte[4];
            OpenAn[0] = (byte)'$';
            OpenAn[1] = (byte)'C';
            OpenAn[2] = (byte)'A';
            OpenAn[3] = (byte)'#';
            if (ConnTypes == 1)
            {
                DisOrder(OpenAn);
            }
            else if (ConnTypes == 2)
            {
                socket.Send(OpenAn);
            }
            else if (ConnTypes == 0)
            {
                MessageBox.Show("Please connect first", "Error");
            }
            outputBox.Text += "$" + "C" + "A" + "#" + "\r\n";
        }
        private void CloseAnBtn_Click(object sender, EventArgs e)         //关闭天线
        {
            byte[] CloseAn = new byte[4];
            CloseAn[0] = (byte)'$';
            CloseAn[1] = (byte)'C';
            CloseAn[2] = (byte)'B';
            CloseAn[3] = (byte)'#';
            if (ConnTypes == 1)
            {
                DisOrder(CloseAn);
            }
            else if (ConnTypes == 2)
            {
                socket.Send(CloseAn);
            }
            else if (ConnTypes == 0)
            {
                MessageBox.Show("Please connect first", "Error");
            }
            outputBox.Text += "$" + "C" + "B" + "#" + "\r\n";
        }
        private void UpDataMainFormUILanguage()
        {
            ResourceManager manager = new ResourceManager(typeof(Form1));
            UpDataMainFormMenuLanguage(manager);
        }
        private void UpDataMainFormMenuLanguage(ResourceManager manager)
        {
            portLabel.Text = manager.GetString("portLabel");
            ruteLabel.Text = manager.GetString("ruteLabel");
            openBtn.Text = manager.GetString("openBtn");
            closeBtn.Text = manager.GetString("closeBtn");
            sig1Label.Text = manager.GetString("sig1Label");
            sig2Label.Text = manager.GetString("sig2Label");
            synLabel.Text = manager.GetString("synLabel");
            countLabel.Text = manager.GetString("countLabel");
            counLabel.Text = manager.GetString("counLabel");
            cardLabel.Text = manager.GetString("cardLabel");
            clearBtn.Text = manager.GetString("clearBtn");
            ccardBtn.Text = manager.GetString("ccardBtn");
            outDataBtn.Text = manager.GetString("outDataBtn");
            openAnBtn.Text = manager.GetString("openAnBtn");
            closeAnBtn.Text = manager.GetString("closeAnBtn");

            startBtn.Text = manager.GetString("startBtn");
            poLabel.Text = manager.GetString("poLabel");
            ipLabel.Text = manager.GetString("ipLabel");
            proLabel.Text = manager.GetString("proLabel");
            stopBtn.Text = manager.GetString("stopBtn");
            return;
        }
        private void SearchAddPort()    //查找串口
        {
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口", "Error");
                return;
            }
            foreach (string s in SerialPort.GetPortNames())
            {
                portCom.Items.Add(s);
            }
            try
            {
                //portCom.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("插入串口", "Error");
                throw new Exception(ex.Message);
            }
        }
        private void OpenCom(string nCom ,int bRute) //打开串口
        {
            try
            {
                myPort.PortName = nCom;
                myPort.BaudRate = bRute;
                myPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
                throw new Exception(ex.Message);
            }
        }
        private void CloseCom()
        {
            try
            {
                if (myPort.IsOpen)
                {
                    myPort.Close();
                    openBtn.Enabled = true;
                    ConnTypes = 0;
                }
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }
        private void OutPut()  //导出txt
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            //按日期作为文件名
            saveFileDialog.FileName = "文件 - " + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);
                streamWriter.Write(this.outputBox.Text);
                streamWriter.Close();
            }
        }
        private string AsciiToString(byte[] recvData, int start, int len1)
        {
            string transf = Encoding.ASCII.GetString(recvData);
            string recvTransf = Encoding.ASCII.GetString(recvData).Substring(start, len1);
            byte[] Ascii = new byte[len1 + 1];
            if (recvTransf.Length != 14)
            {
                recvTransf = recvTransf.PadLeft(14, '0');
            }
            else if (recvTransf.Length != 6)
            {
                recvTransf = recvTransf.Substring(0, 4) + "0" + recvTransf.Substring(4, 1);
            }
            transf = null;
            for (int i = 0; i < Ascii.Length; i++)
            {
                Ascii[i] = Convert.ToByte(recvTransf.Substring(i * 2, 2), 16);
                transf += Ascii[i].ToString("X2");
            }
            return transf;
        }
        private void DisOrder(byte[] transf)
        {
            if (myPort.IsOpen)
            {
                myPort.Write(transf, 0, transf.Length);
                Thread.Sleep(50);
            }
        }
        private void Tool3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();

            Environment.Exit(0);
        }
    }
}
