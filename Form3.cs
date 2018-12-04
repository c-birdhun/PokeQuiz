using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{

    public partial class Form3 : Form
    {

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public readonly int WM_NLBUTTONDOWN = 0xA1;
        public readonly int HT_CAPTION = 0x2;

        public Form3()
        {
            InitializeComponent();

            this.button4.TabStop = false;
            this.button4.FlatStyle = FlatStyle.Flat;
            this.button4.FlatAppearance.BorderSize = 0;
             //폼종료 버튼 (x)테두리 제거

            this.FormBorderStyle = FormBorderStyle.None;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               
                ReleaseCapture();
                // 다른 컨트롤에 묶여있을 수 있을 수 있으므로 마우스캡쳐 해제
               
                SendMessage(this.Handle, WM_NLBUTTONDOWN, HT_CAPTION, 0);
            } // 타이틀 바의 다운 이벤트처럼 보냄

            base.OnMouseDown(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }//도움말 폼 종료

        
    }
}
