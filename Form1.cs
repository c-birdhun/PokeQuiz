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
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public readonly int WM_NLBUTTONDOWN = 0xA1;
        public readonly int HT_CAPTION = 0x2;
  
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 다른 컨트롤에 묶여있을 수 있을 수 있으므로 마우스캡쳐 해제
                ReleaseCapture();

                // 타이틀 바의 다운 이벤트처럼 보냄
                SendMessage(this.Handle, WM_NLBUTTONDOWN, HT_CAPTION, 0);
            }
            base.OnMouseDown(e);
        }


        Form2 man = new Form2();
        //Form2를 열기위해 Form2 객체 man를 생성

        private int imageIndex = 0;
        private List<Image> imageList = null;
        private Timer timer = null;
        //imageList, timer 초기화시켜줌

        public Form1()
        {
            InitializeComponent();
            button4.Hide();
            //처음에 SKIP버튼 숨김
            this.button1.TabStop = false;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button2.TabStop = false;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0; 
            this.button3.TabStop = false;
            this.button3.FlatStyle = FlatStyle.Flat;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button4.TabStop = false;
            this.button4.FlatStyle = FlatStyle.Flat;
            this.button4.FlatAppearance.BorderSize = 0;
            //각 버튼의 TABSTOP 활성화, 버튼 테두리 사이즈 0으로 제거

            this.FormBorderStyle = FormBorderStyle.None;  
            //폼 테두리 제거
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //혀재 폼의 배경레이아웃을 STRETCH를 이용해 화면에 늘림
            
            this.imageList = new List<Image>();
            //오프닝 이미지에 사용할 리소스 이미지를 넣음
            this.imageList.Add(Properties.Resources.op0);
            this.imageList.Add(Properties.Resources.op1);
            this.imageList.Add(Properties.Resources.op2);
            this.imageList.Add(Properties.Resources.op3);
            this.imageList.Add(Properties.Resources.op4);
            this.imageList.Add(Properties.Resources.op5);
            this.imageList.Add(Properties.Resources.op7);
            this.timer = new Timer();
            //타이머 시작
            this.timer.Interval = 2000;
            //2초마다 넘어감
            this.timer.Tick += new EventHandler(timer_Tick);
            //timer 2초마다 timer Tick 메서드 호출한다.

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.ChangeImage();
            //ChangeImage 메서드 호출
        }

    
        private void ChangeImage()
        {
            
            this.imageIndex++;
            if (this.imageIndex >= this.imageList.Count)
            {//imageIndex 즉, changeImage가 실행된 경우가 list의 요소의 수보다 같거나 많게되면
             //imageindex를 0으로 초기화 시키고 폼을 숨기고 Form2를 실행시키며 timer를 종료시킨다.
                this.imageIndex = 0;
                       this.Hide();
                        man.Show();
                timer.Stop();


            }
            this.BackgroundImage = this.imageList[this.imageIndex];
        }//한번 실행될때마다 imageindex값이 1씩 증가하며 그 값들은 imagelist의 순서 0부터 6까지 나타내며
        //값이 바뀔때마다 BackgroundImage는 순서대로 변경된다.

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // 종료버튼
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 manl = new Form3();
            manl.ShowDialog();
            
        }//도움말에 들어가기 위한 버튼

      

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Show();
            button3.Hide();
            this.button1.BackgroundImage = Properties.Resources.x1;
            this.button2.BackgroundImage = Properties.Resources.q1;
            this.timer.Stop();
            this.timer.Start();
            this.ChangeImage();
        }//start 버튼 클릭시 skip버튼를 보이고 start버튼을 숨김. 버튼1,2는 x와 ? 의 색을 변경하기위해 사용
        //타이머 시작되고 ChangImage() 메서드 호출

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            man.Show();
            timer.Stop();
        }
        //skip버튼을 숨기고 다음 폼(Form2)로 이동하며 timer를 멈춘다.
    }
    
}
