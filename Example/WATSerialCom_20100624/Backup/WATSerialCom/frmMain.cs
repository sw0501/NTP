using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace WATSerialCom
{
    public partial class frmMain : Form
    {
        SerialPort m_sp1;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtComNum.Text = "COM3";
            txtBaudRate.Text = "115200";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                // m_sp1 ���� null �϶��� ���ο� SerialPort �� �����մϴ�.
                if (null == m_sp1)
                {
                    m_sp1 = new SerialPort();
                    m_sp1.PortName = txtComNum.Text;   // ����Ʈ��
                    m_sp1.BaudRate = Convert.ToInt32(txtBaudRate.Text);   // ������Ʈ

                    m_sp1.DataReceived += new SerialDataReceivedEventHandler(EventDataReceived);
                    m_sp1.Open();
                }

                btnOpen.Enabled = !m_sp1.IsOpen;    // OPEN BUTTON Disable
                btnClose.Enabled = m_sp1.IsOpen;     // CLOSE BUTTON Enable
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_sp1.Dispose();
                m_sp1 = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // m_sp1 �� null �ƴҶ��� close ó���� ���ش�.
            if (null != m_sp1)
            {
                if (m_sp1.IsOpen)
                {
                    m_sp1.Close();
                    m_sp1.Dispose();
                    m_sp1 = null;
                }

            }
            btnOpen.Enabled = true;
            btnClose.Enabled = false;         
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                m_sp1.Write("ABC");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Serial Port Event
        void EventDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int iRecSize = m_sp1.BytesToRead; // ���ŵ� ������ ����
            string strRxData;

            if (iRecSize != 0) // ���ŵ� �������� ���� 0�� �ƴҶ��� ó������
            {
                strRxData = "";
                byte[] buff = new byte[iRecSize];

                m_sp1.Read(buff, 0, iRecSize);

                for (int iTemp = 0; iTemp < iRecSize; iTemp++)
                {
                    if (chkRxHexa.Checked)
                        strRxData += " " + buff[iTemp].ToString("X2");
                    else
                        strRxData += Convert.ToChar(buff[iTemp]);
                }
                txtRxData.Text += strRxData;
            }
        }

    }
}