using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;                  //기본 패키지에는 제공되어있지 않아서 Nuget 패키지에서 설치해야됨
using System.Runtime.InteropServices;   //시스템 시간 변경을 위해서 참조

namespace Time_Synch_Program
{
    public partial class Main : Form
    {
        SerialPort m_sp1;   //시리얼포트 변수

        public struct SYSTEMTIME    //public 선언안하고 쓰면 CS0051 오류 발생
        {
            public ushort wYear; 
            public ushort wMonth; 
            public ushort wDayOfWeek;
            public ushort wDay; 
            public ushort wHour; 
            public ushort wMinute; 
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        [DllImport("kernel32.dll")] //SetSystemTime API를 이용하기 위한 연관 시스템 파일
        public extern static uint SetSystemTime(ref SYSTEMTIME IpSystemTime);   //시스템 시간을 변경하는 API

        public Main()
        {
            InitializeComponent();

            //Timer를 이용하여 현재 PC의 시간을 계속해서 갱신한다.
            PC_Timer.Enabled = true;
            PC_Timer.Tick += PC_Timer_Tick;
            /*
             Properties 안에 있는 Last_Server_Time은 DateTime 형식으로 바꿔서 사용하는게 훨씬 편할 듯 
             */
        }

        private void PC_Timer_Tick(object sender, EventArgs e)
        {
            //현재 PC의 시간정보를 문자열 형식으로 변환하여 텍스트에 넣어줌 -> 텍스트 아니어도 라벨에 넣으면 더 이쁠듯
            PC_Hour.Text = System.DateTime.Now.ToString("HH");
            PC_Min.Text = System.DateTime.Now.ToString("mm");
            PC_Sec.Text = System.DateTime.Now.ToString("ss");
            PC_Time.Text = Properties.Settings.Default.Last_Server_Time.ToString();             //시간이 지날때마다 PC_Time을 갱신 -> RX 버튼을 누르거나 데이터를 받아왔을 때 갱신하면 됨
            PC_Time_Delayed.Text = Properties.Settings.Default.Last_Server_Time_Delayed.ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtComNum.Text = "COM3";
            txtBaudRate.Text = "115200";
            PC_Time.Text = Properties.Settings.Default.Last_Server_Time.ToString();                //속성에 저장되어있는 Last_Server_Time을 불러와서 Text에 저장
            PC_Time_Delayed.Text = Properties.Settings.Default.Last_Server_Time_Delayed.ToString();//속성에 저장되어있는 Last_Server_Time_Delayed을 불러와서 Text에 저장
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
            Properties.Settings.Default.Last_Server_Time = System.DateTime.Now;  //Close 버튼 누를때마다 바뀐 시간 설정을 저장
            DateTime temp = System.DateTime.Now.AddSeconds(1);  //시간 지연
            Properties.Settings.Default.Last_Server_Time_Delayed = temp; //Close 버튼 누를때마다 바뀐 시간 설정을 저장
            Properties.Settings.Default.Save(); //설정 저장

            if(null != m_sp1)
            {
                if (m_sp1.IsOpen)
                {
                    m_sp1.Close();
                    m_sp1.Dispose();
                    m_sp1 = null;
                }
                btn_Open.Enabled = true;    //Open Button Enable
                btn_Close.Enabled = false;  //Close Button Disable
            }

        }

        private void btn_RX_Click(object sender, EventArgs e)
        {
            int iRecSize = m_sp1.BytesToRead;   //수신된 데이터 갯수
            string strRxData;   //수신된 데이터를 문자열로 변환
            //받아온 데이터를 시 분 초로 변환하여 저장하고 지연시간을 확인해서 그만큼 추가해주면 됨

            //strRxData 변수에다 수신된 데이터를 문자열로 변환하고 메세지 박스로 보여준다.
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

        //관리자 설정을 안해서 그렇지 빌드하면 될듯... 안된다 개빡치네
        private void btn_Time_Apply_Click(object sender, EventArgs e)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            //DateTime tmpdate = new DateTime(st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond);    //tmpdata 안에 변경할 시간 정보들을 변수로 넘겨주면 된다.
            DateTime tmpdate = Properties.Settings.Default.Last_Server_Time_Delayed;
            tmpdate = tmpdate.AddMinutes(-9); //KOR timezone adjust
            st.wDayOfWeek = (ushort)tmpdate.DayOfWeek; 
            st.wMonth = (ushort)tmpdate.Month; 
            st.wDay = (ushort)tmpdate.Day; 
            st.wHour = (ushort)tmpdate.Hour; 
            st.wMinute = (ushort)tmpdate.Minute; 
            st.wSecond = (ushort)tmpdate.Second; 
            st.wMilliseconds = 0; 
            SetSystemTime(ref st);
            MessageBox.Show(tmpdate.ToString());
        }
    }
}
