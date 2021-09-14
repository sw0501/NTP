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
using System.Diagnostics;               //디버깅용

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

        [DllImport("kernel32.dll",SetLastError = true)] //SetSystemTime API를 이용하기 위한 연관 시스템 파일
        public extern static bool SetSystemTime(ref SYSTEMTIME st); //시스템 시간을 변경하는 API

        public Main()
        {
            InitializeComponent();

            //Timer를 이용하여 현재 PC의 시간을 계속해서 갱신한다.
            PC_Timer.Enabled = true;
            PC_Timer.Tick += PC_Timer_Tick;

        }

        //시간이 지날때마다 PC_Timer_Tick 가 갱신됨
        private void PC_Timer_Tick(object sender, EventArgs e)
        {
            //현재 PC의 시간정보 갱신 -> 동기화가 풀려도 PC 자체 클럭으로 돌아감
            Voip_Server_Time.Text = System.DateTime.Now.ToString();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //사용자가 세팅에서 Port 이름과 BaudRate 입력하고 그 값을 받아와야함
            //전에 사용했던 값 입력 받으면 될 듯
            Serial_Port.Text = "COM5";
            BaudRate.Text = "9600";
            Delayed_Time.Text = Properties.Settings.Default.Delay.ToString();


            //속성에 저장되어있는 Last_Server_Time을 불러와서 Text에 저장
            Intranet_Server_Time.Text = Properties.Settings.Default.Last_Server_Time.ToString();

            //초기 상태 표시
            Port_Connect_Status.Image = Properties.Resources.RC1;
            Sync_Status.Image = Properties.Resources.RC1;
            TX_Status.Image = Properties.Resources.RC1;
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                //포트이름이 비어있거나 바우드레이트가 입력이 안되어있는 경우 오류 메세지 표시
                if (Serial_Port.Text.Equals("") || BaudRate.Text.Equals("") || Convert.ToInt32(BaudRate.Text.ToString())<=0)
                {
                    MessageBox.Show("올바른 Port와 Baud를 입력해주세요");
                }
                else
                {
                    if (null == m_sp1)
                    {
                        //포트가 열렸을 경우
                        Port_Connect_Status.Image = Properties.Resources.GC1;
                        Sync_Status.Image = Properties.Resources.GC1;
                        TX_Status.Image = Properties.Resources.YC1;

                        m_sp1 = new SerialPort();
                        m_sp1.PortName = Serial_Port.Text;    //컴포트명
                        m_sp1.BaudRate = Convert.ToInt32(BaudRate.Text); //바우드레이트
                        m_sp1.Parity = Parity.None;
                        m_sp1.DataBits = 8;
                        m_sp1.StopBits = StopBits.One;

                        //포트에 남아있는 데이터를 읽어서 처리
                        m_sp1.DataReceived += new SerialDataReceivedEventHandler(EventDataReceived);
                        m_sp1.Open();
                        
                    }

                    btn_Open.Enabled = false;   //Open Button Disable
                    btn_Close.Enabled = true;    //Close Button Enable
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {

            if (null != m_sp1)
            {
                if (m_sp1.IsOpen)
                {
                    //포트가 닫혔을 경우
                    Port_Connect_Status.Image = Properties.Resources.RC1;
                    Sync_Status.Image = Properties.Resources.RC1;
                    TX_Status.Image = Properties.Resources.RC1;

                    m_sp1.Close();
                    m_sp1.Dispose();
                    m_sp1 = null;
                }
                btn_Open.Enabled = true;    //Open Button Enable
                btn_Close.Enabled = false;  //Close Button Disable
            }


        }

        private void EventDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        
            int iRecSize = m_sp1.BytesToRead; // 수신된 데이터 갯수
            string strRxData;   //수신 데이터 문자열

            try
            {
                if (iRecSize != 0) // 수신된 데이터의 수가 0이 아닐때만 처리하자
                {
                    strRxData = "";

                    //이벤트가 발생할때마다 m_spl에 저장된 수신데이터를 저장
                    strRxData = m_sp1.ReadExisting();

                    //저장된 수신데이터에서 원하는 값을 추출
                    pharsingMsg(strRxData);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            //이벤트가 끝난 경우 대기상태 표시
            TX_Status.Image = Properties.Resources.YC1;

        }

        //수신된 GPS 데이터에서 원하는 데이터 추출
        private void pharsingMsg(string Msg)
        {
            int GPS_year = 0;           //연도
            int GPS_month = 0;          //월
            int GPS_day = 0;            //일
            int GPS_hour = 0;           //시
            int GPS_minute = 0;         //분
            int GPS_second = 0;         //초
            int GPS_milliseconds = 0;   //밀리초


            string[] ChkMsg = null;     //
            string temp = "";           //

            //Msg가 비어있거나 공백인 경우 추출하지 않는다
            if(Msg == null || Msg.Equals(""))
            {

            }
            else
            {
                try
                {
                    Msg.Replace("\n\r", "");
                    int selectIDX = -1;
                    string[] strArr = Msg.Split('$');
                    //최근의 GPRMC 문자열 찾기
                    for(int i = strArr.Length - 1; i >= 0; i--)
                    {
                        if (strArr[i].ToString().Substring(0, 5).Equals("GPRMC"))
                        {
                            //수신 문자열이 유효하고 필요한 정보를 가지고 있는지 확인
                            ChkMsg = strArr[i].ToString().Split(',');
                            if(ChkMsg[2] == null || ChkMsg[3] == null)
                            {
                                continue;
                            }
                            else if(ChkMsg[2].ToString().Replace(" ","").Equals("")|| ChkMsg[3].ToString().Replace(" ", "").Equals(""))
                            {
                                continue;
                            }
                            else
                            {
                                selectIDX = i;
                                break;
                            }
                        }
                    }

                    //수신 문자열중 GPRMC가 없을 때 기존 값들 초기화
                    if(selectIDX < 0)
                    {
                        GPS_year = 0;          
                        GPS_month = 0;
                        GPS_day = 0;           
                        GPS_hour = 0;          
                        GPS_minute = 0;         
                        GPS_second = 0;        
                        GPS_milliseconds = 0;
                    }
                    else
                    {
                        //이벤트가 발생했을 상태 표시
                        TX_Status.Image = Properties.Resources.GC1;

                        string[] ArrMsg = ChkMsg;
                        temp = ArrMsg[1].ToString();    //시간데이터

                        //SetSystemTime 이 그리니치 표준시를 사용하기 때문에 시간조정 필요 X
                        GPS_hour = Convert.ToInt16(temp.Substring(0, 2));
                        
                        if (GPS_hour > 24)
                        {
                            GPS_hour = GPS_hour - 24;
                        }

                        //string 대신 datatime 형식으로 변환해서 사용하면 될 듯
                        GPS_minute = Convert.ToInt16(temp.Substring(2, 2));
                        GPS_second = Convert.ToInt16(temp.Substring(4, 2));
                        GPS_milliseconds = Convert.ToInt16(temp.Substring(7, 3));
                        GPS_year = 2000 + Convert.ToInt16(ArrMsg[9].Substring(4, 2));
                        GPS_month = Convert.ToInt16(ArrMsg[9].Substring(2, 2));
                        GPS_day = Convert.ToInt16(ArrMsg[9].Substring(0, 2));

                        //tmpdata 안에 변경할 시간 정보들을 변수로 넘겨주면 된다.
                        DateTime GPS_Time = new DateTime(GPS_year,GPS_month,GPS_day,GPS_hour,GPS_minute,GPS_second,GPS_milliseconds);

                        //그리니치 표준시 적용을 위해 + 9H
                        //Last_Server_Time에 가장 최근에 받은 GPS_Time 저장 후 설정 저장
                        Properties.Settings.Default.Last_Server_Time = GPS_Time.AddHours(9);

                        //지연시간 저장
                        Properties.Settings.Default.Delay = Convert.ToInt16(Delayed_Time.Text);

                        //SetSystemTime이 한국시간 변환을 위해 자동으로 9H 더해주기때문에 그냥 지연시간만 더해주면 됨 (나중에 필요할때 millisecond로 변경하면 됨)
                        Properties.Settings.Default.Last_Server_Time_Delayed = GPS_Time.AddSeconds(Properties.Settings.Default.Delay);

                        //사용자가 입력한 지연시간만큼 더한후에 저장
                        Properties.Settings.Default.Save(); //설정 저장

                        //이벤트가 생기면 갱신
                        Intranet_Server_Time.Text = Properties.Settings.Default.Last_Server_Time.ToString();
                        
                        //SetSystemTime을 이용하기 위해 선언 후 Last_Server_Time_Delayed 데이터 저장
                        SYSTEMTIME st = new SYSTEMTIME();

                        st.wYear = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.Year;
                        st.wDayOfWeek = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.DayOfWeek;
                        st.wMonth = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.Month;
                        st.wDay = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.Day;
                        st.wHour = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.Hour;
                        st.wMinute = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.Minute;
                        st.wSecond = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.Second;
                        st.wMilliseconds = (ushort)Properties.Settings.Default.Last_Server_Time_Delayed.Millisecond;


                        //컴퓨터의 시간 변경
                        bool E = SetSystemTime(ref st);

                        //에러 체크 -> 1314 : 관리자 권한 -> 빌드하고 관리자 권한으로 열기하면 됨
                        if (E == false)
                        {
                            int lastError = Marshal.GetLastWin32Error();
                            Debug.WriteLine(lastError.ToString());
                        }

                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
