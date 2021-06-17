using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  //기본 패키지에는 제공되어있지 않아서 Nuget 패키지에서 설치해야됨

namespace Time_Synch_Program
{
    public partial class Main : Form
    {
        SerialPort m_sp1;

        public Main()
        {
            InitializeComponent();

            //Timer를 이용하여 현재 PC의 시간을 계속해서 갱신한다.
            PC_Timer.Enabled = true;
            PC_Timer.Tick += PC_Timer_Tick;
        }

        private void PC_Timer_Tick(object sender, EventArgs e)
        {
            //현재 PC의 시간정보를 문자열 형식으로 변환하여 텍스트에 넣어줌 -> 텍스트 아니어도 라벨에 넣으면 더 이쁠듯
            PC_Hour.Text = System.DateTime.Now.ToString("HH");
            PC_Min.Text = System.DateTime.Now.ToString("mm");
            PC_Sec.Text = System.DateTime.Now.ToString("ss");
            PC_Time.Text = Properties.Settings.Default.Last_Server_Time;             //시간이 지날때마다 PC_Time을 갱신 -> RX 버튼을 누르거나 데이터를 받아왔을 때 갱신하면 됨
            PC_Time_Delayed.Text = Properties.Settings.Default.Last_Server_Time_Delayed;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtComNum.Text = "COM3";
            txtBaudRate.Text = "115200";
            PC_Time.Text = Properties.Settings.Default.Last_Server_Time;             //속성에 저장되어있는 Last_Server_Time을 불러와서 Text에 저장
            PC_Time_Delayed.Text = Properties.Settings.Default.Last_Server_Time_Delayed;
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_sp1)
                {
                    m_sp1 = new SerialPort();
                    m_sp1.PortName = txtComNum.Text;    //컴포트명
                    m_sp1.BaudRate = Convert.ToInt32(txtBaudRate.Text); //바우드레이트

                    m_sp1.Open();
                }

                btn_Open.Enabled = !m_sp1.IsOpen;   //Open Button Disable
                btn_Close.Enabled = m_sp1.IsOpen;    //Close Button Enable
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Last_Server_Time = System.DateTime.Now.ToString();  //Close 버튼 누를때마다 바뀐 시간 설정을 저장
            DateTime temp = System.DateTime.Now.AddSeconds(1);  //시간 지연
            Properties.Settings.Default.Last_Server_Time_Delayed = temp.ToString(); //Close 버튼 누를때마다 바뀐 시간 설정을 저장
            Properties.Settings.Default.Save(); //설정 저장

            if(null != m_sp1)
            {
                if (m_sp1.IsOpen)
                {
                    m_sp1.Close();
                    m_sp1.Dispose();
                    m_sp1 = null;
                }
                btn_Open.Enabled = true;
                btn_Close.Enabled = false;
            }

        }

        private void btn_RX_Click(object sender, EventArgs e)
        {
            int iRecSize = m_sp1.BytesToRead;   //수신된 데이터 갯수
            string strRxData;   //수신된 데이터를 문자열로 변환
            //받아온 데이터를 시 분 초로 변환하여 저장하고 지연시간을 확인해서 그만큼 추가해주면 됨

            try
            {
                if(iRecSize != 0)
                {
                    strRxData = "";
                    byte[] buff = new byte[iRecSize];

                    m_sp1.Read(buff, 0, iRecSize);
                    for(int iTemp = 0; iTemp < iRecSize; iTemp++)
                    {
                        strRxData += Convert.ToChar(buff[iTemp]);
                    }
                    MessageBox.Show(strRxData);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Time_Apply_Click(object sender, EventArgs e)
        {
            //System.DateTime.Now.Minute = 
        }
    }
}
