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
        //SerialPort m_sp1';

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
        }
    }
}
