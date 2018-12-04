using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Media;



namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public readonly int WM_NLBUTTONDOWN = 0xA1;
        public readonly int HT_CAPTION = 0x2;
        //테두리 삭제

        SoundPlayer xx = new SoundPlayer(Properties.Resources.오답);
        SoundPlayer oo = new SoundPlayer(Properties.Resources.정답);
        SoundPlayer win = new SoundPlayer(Properties.Resources.happy);
        SoundPlayer lose = new SoundPlayer(Properties.Resources.fail);
        SoundPlayer hint = new SoundPlayer(Properties.Resources.shint);
        SoundPlayer st = new SoundPlayer(Properties.Resources.stage);

        //정답, 오답 , 각 엔딩, 힌트, 스테이지 변경시 음악 파일 

        private List<Image> imageList=null;//초급 그림자
        private List<Image> imageList2=null;//중급 그림자
        private List<Image> imageList3=null;//고급 그림자

        private List<Image> imageList4=null;//초급 사진
        private List<Image> imageList5=null;//중급 사진
        private List<Image> imageList6=null;//고급 사진
                                        
       
        private List<string> name= null;//초급 포켓몬이름
        private List<string> name1 = null;//중급 포켓몬 이름
        private List<string> name2 = null;//고급 포켓몬 이름
       
        private List<int> num = null;
        //stage마다 랜덤값이 저장될 공간

        private int one = 0;
        private int two = 0;
        private int three = 0;
        private int four = 0;
        //label 들어갈 값

        //public static int pic = 0; //랜덤값 저장 변수
        private int pic = 0;
        private int Life = 3;
        private int Stage = 0;
        private int Point = 0;
        public static int Stagee = 0;
        public static int picc = 0;
        // 전역 변수를 초기화. 
        //Form5에서 값을 끌어쓰기위해서 static사용. 처음 선언시 pic이나 stage의 값을 public static int로 한다면, 오류가 나타난다.

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        //랜덤 메서드를 위해 선언.
        
        public static int GetMyRandomNumber(int min, int max)
        {//랜덤값의 중복을 막기위해 랜덤 범위를 입력받아 값을 출력
            lock (syncLock)
                //lock 키워드는 한 스레드가 임계 영역에 있는 동안 다른 스레드가 코드의 임계
           //영역에 들어오지 않도록 막음 . 들어오려고하면 개체가 해제될따까지 대기및 차단
            {//syncLock 모니터개체에 대한 액세스를 단수화 시킴
                return random.Next(min, max+1);
                //받아온 값들에서 랜덤값을 더해준다. +1을 안해주면 중복값이 출력됨.
            }
        }
        
        

        private Timer timer = null;
        //엔딩때 사용될 gif파일의 시간을 맞춰줄 타이머
        Image animatedImage;
        Image aanimatedImage;
        //gif구현을 위하여 선언 각 end1 end2

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               
                ReleaseCapture();
                // 다른 컨트롤에 묶여있을 수 있을 수 있으므로 마우스캡쳐 해제
              
                SendMessage(this.Handle, WM_NLBUTTONDOWN, HT_CAPTION, 0);
            }  // 타이틀 바의 다운 이벤트처럼 보냄

            base.OnMouseDown(e);
        }
        //테두리제거 코드

        public void easy() {
            this.imageList4 = new List<Image>();
            this.imageList4.Add(Properties.Resources._001_이상해씨);
            this.imageList4.Add(Properties.Resources._002_이상해풀);
            this.imageList4.Add(Properties.Resources._003_이상해꽃);
            this.imageList4.Add(Properties.Resources._004_파이리);
            this.imageList4.Add(Properties.Resources._005_리자드);
            this.imageList4.Add(Properties.Resources._006_리자몽);
            this.imageList4.Add(Properties.Resources._007_꼬부기);
            this.imageList4.Add(Properties.Resources._008_어니부기);
            this.imageList4.Add(Properties.Resources._009_거북왕);
            this.imageList4.Add(Properties.Resources._010_캐터피);
            this.imageList4.Add(Properties.Resources._011_단데기);
            this.imageList4.Add(Properties.Resources._012_버터플);
            this.imageList4.Add(Properties.Resources._013_뿔충이);
            this.imageList4.Add(Properties.Resources._014_딱충이);
            this.imageList4.Add(Properties.Resources._015_독침붕);
            this.imageList4.Add(Properties.Resources._016_구구);
            this.imageList4.Add(Properties.Resources._017_피죤);
            this.imageList4.Add(Properties.Resources._018_피죤투);
            this.imageList4.Add(Properties.Resources._019_꼬렛);
            this.imageList4.Add(Properties.Resources._020_레트라);
            this.imageList4.Add(Properties.Resources._021_깨비참);
            this.imageList4.Add(Properties.Resources._022_깨비드릴조);
            this.imageList4.Add(Properties.Resources._023_아보);
            this.imageList4.Add(Properties.Resources._024_아보크);
            this.imageList4.Add(Properties.Resources._025_피카츄);
            this.imageList4.Add(Properties.Resources._026_라이츄);
            this.imageList4.Add(Properties.Resources._027_모래두지);
            this.imageList4.Add(Properties.Resources._028_고지);
            this.imageList4.Add(Properties.Resources._029_니드런_암_);
            this.imageList4.Add(Properties.Resources._030_니드리나);
            this.imageList4.Add(Properties.Resources._031_니드퀸);
            this.imageList4.Add(Properties.Resources._032_니드런_수_);
            this.imageList4.Add(Properties.Resources._033_니드리노);
            this.imageList4.Add(Properties.Resources._034_니드킹);
            this.imageList4.Add(Properties.Resources._035_삐삐);
            this.imageList4.Add(Properties.Resources._036_픽시);
            this.imageList4.Add(Properties.Resources._037_식스테일);
            this.imageList4.Add(Properties.Resources._038_나인테일);
            this.imageList4.Add(Properties.Resources._039_푸린);
            this.imageList4.Add(Properties.Resources._040_푸크린);
            this.imageList4.Add(Properties.Resources._041_주뱃);
            this.imageList4.Add(Properties.Resources._042_골뱃);
            this.imageList4.Add(Properties.Resources._043_뚜벅쵸);
            this.imageList4.Add(Properties.Resources._044_냄새꼬);
            this.imageList4.Add(Properties.Resources._045_라플레시아);
            this.imageList4.Add(Properties.Resources._046_파라스);
            this.imageList4.Add(Properties.Resources._047_파라섹트);
            this.imageList4.Add(Properties.Resources._048_콘팡);
            this.imageList4.Add(Properties.Resources._049_도나리);
            this.imageList4.Add(Properties.Resources._050_디그다);
            this.imageList4.Add(Properties.Resources._051_닥트리오);
            this.imageList4.Add(Properties.Resources._052_나옹);
            this.imageList4.Add(Properties.Resources._053_페르시온);
            this.imageList4.Add(Properties.Resources._054_고라파덕);
            this.imageList4.Add(Properties.Resources._055_골덕);
            this.imageList4.Add(Properties.Resources._056_망키);
            this.imageList4.Add(Properties.Resources._057_성원숭);
            this.imageList4.Add(Properties.Resources._058_가디);
            this.imageList4.Add(Properties.Resources._059_윈디);
            this.imageList4.Add(Properties.Resources._060_발챙이);
            this.imageList4.Add(Properties.Resources._061_슈륙챙이);
            this.imageList4.Add(Properties.Resources._062_강챙이);
            this.imageList4.Add(Properties.Resources._063_케이시);
            this.imageList4.Add(Properties.Resources._064_윤겔라);
            this.imageList4.Add(Properties.Resources._065_후딘);
            this.imageList4.Add(Properties.Resources._066_알통몬);
            this.imageList4.Add(Properties.Resources._067_근육몬);
            this.imageList4.Add(Properties.Resources._068_괴력몬);
            this.imageList4.Add(Properties.Resources._069_모다피);
            this.imageList4.Add(Properties.Resources._070_우츠동);
            this.imageList4.Add(Properties.Resources._071_우츠보트);
            this.imageList4.Add(Properties.Resources._072_왕눈해);
            this.imageList4.Add(Properties.Resources._073_독파리);
            this.imageList4.Add(Properties.Resources._074_꼬마돌);
            this.imageList4.Add(Properties.Resources._075_데구리);
            this.imageList4.Add(Properties.Resources._076_딱구리);
            this.imageList4.Add(Properties.Resources._077_포니타);
            this.imageList4.Add(Properties.Resources._078_날쌩마);
            this.imageList4.Add(Properties.Resources._079_야돈);
            //정답시 나올 사진들




            this.imageList = new List<Image>();
            this.imageList.Add(Properties.Resources._001_이상해씨1);
            this.imageList.Add(Properties.Resources._002_이상해풀1);
            this.imageList.Add(Properties.Resources._003_이상해꽃1);
            this.imageList.Add(Properties.Resources._004_파이리1);
            this.imageList.Add(Properties.Resources._005_리자드1);
            this.imageList.Add(Properties.Resources._006_리자몽1);
            this.imageList.Add(Properties.Resources._007_꼬부기1);
            this.imageList.Add(Properties.Resources._008_어니부기1);
            this.imageList.Add(Properties.Resources._009_거북왕1);
            this.imageList.Add(Properties.Resources._010_캐터피1);
            this.imageList.Add(Properties.Resources._011_단데기1);
            this.imageList.Add(Properties.Resources._012_버터플1);
            this.imageList.Add(Properties.Resources._013_뿔충이1);
            this.imageList.Add(Properties.Resources._014_딱충이1);
            this.imageList.Add(Properties.Resources._015_독침붕1);
            this.imageList.Add(Properties.Resources._016_구구1);
            this.imageList.Add(Properties.Resources._017_피죤1);
            this.imageList.Add(Properties.Resources._018_피죤투1);
            this.imageList.Add(Properties.Resources._019_꼬렛1);
            this.imageList.Add(Properties.Resources._020_레트라1);
            this.imageList.Add(Properties.Resources._021_깨비참1);
            this.imageList.Add(Properties.Resources._022_깨비드릴조1);
            this.imageList.Add(Properties.Resources._023_아보1);
            this.imageList.Add(Properties.Resources._024_아보크1);
            this.imageList.Add(Properties.Resources._025_피카츄1);
            this.imageList.Add(Properties.Resources._026_라이츄1);
            this.imageList.Add(Properties.Resources._027_모래두지1);
            this.imageList.Add(Properties.Resources._028_고지1);
            this.imageList.Add(Properties.Resources._029_니드런_암_1);
            this.imageList.Add(Properties.Resources._030_니드리나1);
            this.imageList.Add(Properties.Resources._031_니드퀸1);
            this.imageList.Add(Properties.Resources._032_니드런_수_1);
            this.imageList.Add(Properties.Resources._033_니드리노1);
            this.imageList.Add(Properties.Resources._034_니드킹1);
            this.imageList.Add(Properties.Resources._035_삐삐1);
            this.imageList.Add(Properties.Resources._036_픽시1);
            this.imageList.Add(Properties.Resources._037_식스테일1);
            this.imageList.Add(Properties.Resources._038_나인테일1);
            this.imageList.Add(Properties.Resources._039_푸린1);
            this.imageList.Add(Properties.Resources._040_푸크린1);
            this.imageList.Add(Properties.Resources._041_주뱃1);
            this.imageList.Add(Properties.Resources._042_골뱃1);
            this.imageList.Add(Properties.Resources._043_뚜벅쵸1);
            this.imageList.Add(Properties.Resources._044_냄새꼬1);
            this.imageList.Add(Properties.Resources._045_라플레시아1);
            this.imageList.Add(Properties.Resources._046_파라스1);
            this.imageList.Add(Properties.Resources._047_파라섹트1);
            this.imageList.Add(Properties.Resources._048_콘팡1);
            this.imageList.Add(Properties.Resources._049_도나리1);
            this.imageList.Add(Properties.Resources._050_디그다1);
            this.imageList.Add(Properties.Resources._051_닥트리오1);
            this.imageList.Add(Properties.Resources._052_나옹1);
            this.imageList.Add(Properties.Resources._053_페르시온1);
            this.imageList.Add(Properties.Resources._054_고라파덕1);
            this.imageList.Add(Properties.Resources._055_골덕1);
            this.imageList.Add(Properties.Resources._056_망키1);
            this.imageList.Add(Properties.Resources._057_성원숭1);
            this.imageList.Add(Properties.Resources._058_가디1);
            this.imageList.Add(Properties.Resources._059_윈디1);
            this.imageList.Add(Properties.Resources._060_발챙이1);
            this.imageList.Add(Properties.Resources._061_슈륙챙이1);
            this.imageList.Add(Properties.Resources._062_강챙이1);
            this.imageList.Add(Properties.Resources._063_케이시1);
            this.imageList.Add(Properties.Resources._064_윤겔라1);
            this.imageList.Add(Properties.Resources._065_후딘1);
            this.imageList.Add(Properties.Resources._066_알통몬1);
            this.imageList.Add(Properties.Resources._067_근육몬1);
            this.imageList.Add(Properties.Resources._068_괴력몬1);
            this.imageList.Add(Properties.Resources._069_모다피1);
            this.imageList.Add(Properties.Resources._070_우츠동1);
            this.imageList.Add(Properties.Resources._071_우츠보트1);
            this.imageList.Add(Properties.Resources._072_왕눈해1);
            this.imageList.Add(Properties.Resources._073_독파리1);
            this.imageList.Add(Properties.Resources._074_꼬마돌1);
            this.imageList.Add(Properties.Resources._075_데구리1);
            this.imageList.Add(Properties.Resources._076_딱구리1);
            this.imageList.Add(Properties.Resources._077_포니타1);
            this.imageList.Add(Properties.Resources._078_날쌩마1);
            this.imageList.Add(Properties.Resources._079_야돈1);
            //그림자 사진

            if (this.num == null)
                this.num = new List<int>();
            //num리스트의 값이 null 이면 리스트 클래스의 인스턴스 생성.

            while (this.num.Count < 79)
                //num의 list요소 갯수만큼 반복
            {
                this.pic = GetMyRandomNumber(0, 78);

                //pic에 GetMyRandomNumber 메서드 호출한 후, 랜덤값 초기화
                if (this.num.Contains(pic) == false)
                {//num에 pic의 값이 포함되어있다면
                    this.num.Add(pic);
                    //pic값을 num에 추가시켜준다.
                    break;
                }
            }
            this.pictureBox1.Image = imageList[pic];
       //picturebox에 imageList의 pic번째 그림을 넣는다.
            


            this.name = new List<string>();   //label에 추가될 포켓몬스터 이름
            name.Add("이상해씨");
            name.Add("이상해풀");
            name.Add("이상해꽃");
            name.Add("파이리");
            name.Add("리자드");
            name.Add("리자몽");
            name.Add("꼬부기");
            name.Add("어니부기");
            name.Add("거북왕");
            name.Add("캐터피");//10
            name.Add("단데기");
            name.Add("버터플");
            name.Add("뿔충이");
            name.Add("딱충이");
            name.Add("독침붕");
            name.Add("구구");
            name.Add("피죤");
            name.Add("피죤투");
            name.Add("꼬렛");
            name.Add("레트라");//20
            name.Add("깨비참");
            name.Add("깨비드릴조");
            name.Add("아보");
            name.Add("아보크");
            name.Add("피카츄");
            name.Add("라이츄");
            name.Add("모래두지");
            name.Add("고지");
            name.Add("니드런(암)");
            name.Add("니드리나");//30
            name.Add("니드퀸");
            name.Add("니드런(수)");
            name.Add("니드리노");
            name.Add("니드킹");
            name.Add("삐삐");
            name.Add("픽시");
            name.Add("식스테일");
            name.Add("나인테일");
            name.Add("푸린");
            name.Add("푸크린");//40
            name.Add("주뱃");
            name.Add("골뱃");
            name.Add("뚜벅초");
            name.Add("냄새꼬");
            name.Add("라플레시아");
            name.Add("파라스");
            name.Add("파라섹트");
            name.Add("콘팡");
            name.Add("도나리");
            name.Add("디그다");//50
            name.Add("닥트리오");
            name.Add("냐옹");
            name.Add("페르시온");
            name.Add("고라파덕");
            name.Add("골덕");
            name.Add("망키");
            name.Add("성원숭");
            name.Add("가디");
            name.Add("윈디");
            name.Add("발챙이");//60
            name.Add("수륙챙이");
            name.Add("강챙이");
            name.Add("케이시");
            name.Add("윤겔라");
            name.Add("후딘");
            name.Add("알통몬");
            name.Add("근육몬");
            name.Add("괴력몬");
            name.Add("모다피");
            name.Add("우츠동");//70
            name.Add("우츠보트");
            name.Add("왕눈해");
            name.Add("독파리");
            name.Add("꼬마돌");
            name.Add("데구리");
            name.Add("딱구리");
            name.Add("포니타");
            name.Add("날쌩마");
            name.Add("야돈");//79
           
            int[] rand4 = GetRandoms(pic, 4);
            //rand4에 pic의값과, 4를 인수로 줌
            this.one = rand4[0];
            this.two = rand4[1];
            this.three = rand4[2];
            this.four = rand4[3];
            //getRandoms에서 반환된 값들을 one,two, three, for에 초기화 시켜준다.
            label1.Text = name[one];
            label2.Text = name[two];
            label7.Text = name[three];
            label9.Text = name[four];
            //name 리스트에서 one, two, three, four 번째의 값들을 각각 label에 초기화 시켜줌
        }
        //middle(), hard() 와 숫자, 리스트의 내용만 다르고 같은 코딩이라서 나머지 코딩은 생략.
     



        public void middle()
        {
            this.imageList5 = new List<Image>();
            this.imageList5.Add(Properties.Resources._080_야도란);
            this.imageList5.Add(Properties.Resources._081_코일);
            this.imageList5.Add(Properties.Resources._082_레어코일);
            this.imageList5.Add(Properties.Resources._083_파오리);
            this.imageList5.Add(Properties.Resources._084_두두);
            this.imageList5.Add(Properties.Resources._085_두트리오);
            this.imageList5.Add(Properties.Resources._086_쥬쥬);
            this.imageList5.Add(Properties.Resources._087_쥬레곤);
            this.imageList5.Add(Properties.Resources._088_질퍽이);
            this.imageList5.Add(Properties.Resources._089_질뻐기);//10
            this.imageList5.Add(Properties.Resources._090_셀러);
            this.imageList5.Add(Properties.Resources._091_파르셀);
            this.imageList5.Add(Properties.Resources._092_고오스);
            this.imageList5.Add(Properties.Resources._093_고우스트);
            this.imageList5.Add(Properties.Resources._094_팬텀);
            this.imageList5.Add(Properties.Resources._095_롱스톤);
            this.imageList5.Add(Properties.Resources._096_슬리프);
            this.imageList5.Add(Properties.Resources._097_슬리퍼);
            this.imageList5.Add(Properties.Resources._098_크랩);
            this.imageList5.Add(Properties.Resources._099_킹크랩);//20
            this.imageList5.Add(Properties.Resources._100_찌리리공);
            this.imageList5.Add(Properties.Resources._101_붐볼);
            this.imageList5.Add(Properties.Resources._102_아라리);
            this.imageList5.Add(Properties.Resources._103_나시);
            this.imageList5.Add(Properties.Resources._104_탕구리);
            this.imageList5.Add(Properties.Resources._105_텅구리);
            this.imageList5.Add(Properties.Resources._106_시라소몬);
            this.imageList5.Add(Properties.Resources._107_홍수몬);
            this.imageList5.Add(Properties.Resources._108_내루미);
            this.imageList5.Add(Properties.Resources._109_또가스);//30
            this.imageList5.Add(Properties.Resources._110_또도가스);
            this.imageList5.Add(Properties.Resources._111_뿔카노);
            this.imageList5.Add(Properties.Resources._112_코뿌리);
            this.imageList5.Add(Properties.Resources._113_럭키);
            this.imageList5.Add(Properties.Resources._114_덩쿠리);
            this.imageList5.Add(Properties.Resources._115_캥카);
            this.imageList5.Add(Properties.Resources._116_쏘드라);
            this.imageList5.Add(Properties.Resources._117_시드라);
            this.imageList5.Add(Properties.Resources._118_콘치);
            this.imageList5.Add(Properties.Resources._119_왕콘치);//40
            this.imageList5.Add(Properties.Resources._120_별가사리);
            this.imageList5.Add(Properties.Resources._121_아쿠스타);
            this.imageList5.Add(Properties.Resources._122_마임맨);
            this.imageList5.Add(Properties.Resources._123_스라크);
            this.imageList5.Add(Properties.Resources._124_루주라);
            this.imageList5.Add(Properties.Resources._125_에레브);
            this.imageList5.Add(Properties.Resources._126_마그마);
            this.imageList5.Add(Properties.Resources._127_쁘사이저);
            this.imageList5.Add(Properties.Resources._128_켄타로스);
            this.imageList5.Add(Properties.Resources._129_잉어킹);//50
            this.imageList5.Add(Properties.Resources._130_갸라도스);
            this.imageList5.Add(Properties.Resources._131_라프라스);
            this.imageList5.Add(Properties.Resources._132_메타몽);
            this.imageList5.Add(Properties.Resources._133_이브이);
            this.imageList5.Add(Properties.Resources._134_샤미드);
            this.imageList5.Add(Properties.Resources._135_쥬피썬더);
            this.imageList5.Add(Properties.Resources._136_부스터);
            this.imageList5.Add(Properties.Resources._137_폴리곤);
            this.imageList5.Add(Properties.Resources._138_암나이트);
            this.imageList5.Add(Properties.Resources._139_암스타);//60
            this.imageList5.Add(Properties.Resources._140_투구);
            this.imageList5.Add(Properties.Resources._141_투구푸스);
            this.imageList5.Add(Properties.Resources._142_프테라);
            this.imageList5.Add(Properties.Resources._143_잠만보);
            this.imageList5.Add(Properties.Resources._144_프리져);
            this.imageList5.Add(Properties.Resources._145_썬더);
            this.imageList5.Add(Properties.Resources._146_미뇽);
            this.imageList5.Add(Properties.Resources._147_파이어);
            this.imageList5.Add(Properties.Resources._148_신뇽);
            this.imageList5.Add(Properties.Resources._149_망나뇽);//70
            this.imageList5.Add(Properties.Resources._150_뮤츠);
            this.imageList5.Add(Properties.Resources._151_뮤);
            this.imageList5.Add(Properties.Resources._152_치코리타);
            this.imageList5.Add(Properties.Resources._153_베이리프);
            this.imageList5.Add(Properties.Resources._154_메가니움);
            this.imageList5.Add(Properties.Resources._155_브케인);
            this.imageList5.Add(Properties.Resources._156_마그케인);
            this.imageList5.Add(Properties.Resources._157_블레이범);
            this.imageList5.Add(Properties.Resources._158_리아코);
            this.imageList5.Add(Properties.Resources._159_엘리게이);//80
          


            this.imageList2 = new List<Image>();
            this.imageList2.Add(Properties.Resources._080_야도란1);
            this.imageList2.Add(Properties.Resources._081_코일1);
            this.imageList2.Add(Properties.Resources._082_레어코일1);
            this.imageList2.Add(Properties.Resources._083_파오리1);
            this.imageList2.Add(Properties.Resources._084_두두1);
            this.imageList2.Add(Properties.Resources._085_두트리오1);
            this.imageList2.Add(Properties.Resources._086_쥬쥬1);
            this.imageList2.Add(Properties.Resources._087_쥬레곤1);
            this.imageList2.Add(Properties.Resources._088_질퍽이1);
            this.imageList2.Add(Properties.Resources._089_질뻐기1);
            this.imageList2.Add(Properties.Resources._090_셀러1);
            this.imageList2.Add(Properties.Resources._091_파르셀1);
            this.imageList2.Add(Properties.Resources._092_고오스1);
            this.imageList2.Add(Properties.Resources._093_고우스트1);
            this.imageList2.Add(Properties.Resources._094_팬텀1);
            this.imageList2.Add(Properties.Resources._095_롱스톤1);
            this.imageList2.Add(Properties.Resources._096_슬리프1);
            this.imageList2.Add(Properties.Resources._097_슬리퍼1);
            this.imageList2.Add(Properties.Resources._098_크랩1);
            this.imageList2.Add(Properties.Resources._099_킹크랩1);
            this.imageList2.Add(Properties.Resources._100_찌리리공1);
            this.imageList2.Add(Properties.Resources._101_붐볼1);
            this.imageList2.Add(Properties.Resources._102_아라리1);
            this.imageList2.Add(Properties.Resources._103_나시1);
            this.imageList2.Add(Properties.Resources._104_탕구리1);
            this.imageList2.Add(Properties.Resources._105_텅구리1);
            this.imageList2.Add(Properties.Resources._106_시라소몬1);
            this.imageList2.Add(Properties.Resources._107_홍수몬1);
            this.imageList2.Add(Properties.Resources._108_내루미1);
            this.imageList2.Add(Properties.Resources._109_또가스1);
            this.imageList2.Add(Properties.Resources._110_또도가스1);
            this.imageList2.Add(Properties.Resources._111_뿔카노1);
            this.imageList2.Add(Properties.Resources._112_코뿌리1);
            this.imageList2.Add(Properties.Resources._113_럭키1);
            this.imageList2.Add(Properties.Resources._114_덩쿠리1);
            this.imageList2.Add(Properties.Resources._115_캥카1);
            this.imageList2.Add(Properties.Resources._116_쏘드라1);
            this.imageList2.Add(Properties.Resources._117_시드라1);
            this.imageList2.Add(Properties.Resources._118_콘치1);
            this.imageList2.Add(Properties.Resources._119_왕콘치1);
            this.imageList2.Add(Properties.Resources._120_별가사리1);
            this.imageList2.Add(Properties.Resources._121_아쿠스타1);
            this.imageList2.Add(Properties.Resources._122_마임맨1);
            this.imageList2.Add(Properties.Resources._123_스라크1);
            this.imageList2.Add(Properties.Resources._124_루주라1);
            this.imageList2.Add(Properties.Resources._125_에레브1);
            this.imageList2.Add(Properties.Resources._126_마그마1);
            this.imageList2.Add(Properties.Resources._127_쁘사이저1);
            this.imageList2.Add(Properties.Resources._128_켄타로스1);
            this.imageList2.Add(Properties.Resources._129_잉어킹1);
            this.imageList2.Add(Properties.Resources._130_갸라도스1);
            this.imageList2.Add(Properties.Resources._131_라프라스1);
            this.imageList2.Add(Properties.Resources._132_메타몽1);
            this.imageList2.Add(Properties.Resources._133_이브이1);
            this.imageList2.Add(Properties.Resources._134_샤미드1);
            this.imageList2.Add(Properties.Resources._135_쥬피썬더1);
            this.imageList2.Add(Properties.Resources._136_부스터1);
            this.imageList2.Add(Properties.Resources._137_폴리곤1);
            this.imageList2.Add(Properties.Resources._138_암나이트1);
            this.imageList2.Add(Properties.Resources._139_암스타1);
            this.imageList2.Add(Properties.Resources._140_투구1);
            this.imageList2.Add(Properties.Resources._141_투구푸스1);
            this.imageList2.Add(Properties.Resources._142_프테라1);
            this.imageList2.Add(Properties.Resources._143_잠만보1);
            this.imageList2.Add(Properties.Resources._144_프리져1);
            this.imageList2.Add(Properties.Resources._145_썬더1);
            this.imageList2.Add(Properties.Resources._146_미뇽1);
            this.imageList2.Add(Properties.Resources._147_파이어1);
            this.imageList2.Add(Properties.Resources._148_신뇽1);
            this.imageList2.Add(Properties.Resources._149_망나뇽1);
            this.imageList2.Add(Properties.Resources._150_뮤츠1);
            this.imageList2.Add(Properties.Resources._151_뮤1);
            this.imageList2.Add(Properties.Resources._152_치코리타1);
            this.imageList2.Add(Properties.Resources._153_베이리프1); 
            this.imageList2.Add(Properties.Resources._154_메가니움1);
            this.imageList2.Add(Properties.Resources._155_브케인1);
            this.imageList2.Add(Properties.Resources._156_마그케인1);
            this.imageList2.Add(Properties.Resources._157_블레이범1);
            this.imageList2.Add(Properties.Resources._158_리아코1);
            this.imageList2.Add(Properties.Resources._159_엘리게이1);

            if (this.num == null)
                this.num = new List<int>();

            while (this.num.Count < 80)
            {
                pic = GetMyRandomNumber(0, 79);

                if (this.num.Contains(pic) == false)
                {
                    this.num.Add(pic);
                    break;
                }
            }


            this.pictureBox1.Image = imageList2[pic];
            //10개 랜덤 박스에 표시.   

            this.name1 = new List<string>();
            name1.Add("야도란");
            name1.Add("코일");
            name1.Add("레어코일");
            name1.Add("파오리");
            name1.Add("두두");
            name1.Add("두트리오");
            name1.Add("쥬쥬");
            name1.Add("쥬레곤");
            name1.Add("질퍽이");
            name1.Add("질뻐기");//10
            name1.Add("셀러");
            name1.Add("파르셀");
            name1.Add("고오스");
            name1.Add("고우스트");
            name1.Add("팬텀");
            name1.Add("롱스톤");
            name1.Add("슬리프");
            name1.Add("슬리퍼");
            name1.Add("크랩");
            name1.Add("킹크랩");//20
            name1.Add("찌리리공");
            name1.Add("붐볼");
            name1.Add("아라리");
            name1.Add("나시");
            name1.Add("탕구리");
            name1.Add("텅구리");
            name1.Add("시라소몬");
            name1.Add("홍수몬");
            name1.Add("내루미");
            name1.Add("또가스");//30
            name1.Add("또도가스");
            name1.Add("뿔카노");
            name1.Add("코뿌리");
            name1.Add("럭키");
            name1.Add("덩쿠리");
            name1.Add("캥카");
            name1.Add("쏘드라");
            name1.Add("시드라");
            name1.Add("콘치");
            name1.Add("왕콘치");//40
            name1.Add("별가사리");
            name1.Add("아쿠스타");
            name1.Add("마임맨");
            name1.Add("스라크");
            name1.Add("루주라");
            name1.Add("에레브");
            name1.Add("마그마");
            name1.Add("쁘사이저");
            name1.Add("켄타로스");
            name1.Add("잉어킹");//50
            name1.Add("갸라도스");
            name1.Add("라프라스");
            name1.Add("메타몽");
            name1.Add("이브이");
            name1.Add("샤미드");
            name1.Add("쥬피썬더");
            name1.Add("부스터");
            name1.Add("폴리곤");
            name1.Add("암나이트");
            name1.Add("암스타");//60
            name1.Add("투구");
            name1.Add("투구푸스");
            name1.Add("프테라");
            name1.Add("잠만보");
            name1.Add("프리져");
            name1.Add("썬더");
            name1.Add("미뇽");
            name1.Add("파이어");
            name1.Add("신뇽");
            name1.Add("망나뇽");//70
            name1.Add("뮤츠");
            name1.Add("뮤");
            name1.Add("치코리타");
            name1.Add("베이리프");
            name1.Add("메가니움");
            name1.Add("브케인");
            name1.Add("마그케인");
            name1.Add("블레이범");
            name1.Add("리아코");
            name1.Add("엘리게이");//80
          
            int[] rand4 = GetRandoms1(pic, 4);
            this.one = rand4[0];
            this.two = rand4[1];
            this.three = rand4[2];
            this.four = rand4[3];
            label1.Text = name1[one];
            label2.Text = name1[two];
            label7.Text = name1[three];
            label9.Text = name1[four];
        }

        //중급
        public void hard()
        {
            this.imageList6 = new List<Image>();
            this.imageList6.Add(Properties.Resources._160_장크로다일);
            this.imageList6.Add(Properties.Resources._161_꼬리선);
            this.imageList6.Add(Properties.Resources._162_다꼬리);
            this.imageList6.Add(Properties.Resources._163_부우부);
            this.imageList6.Add(Properties.Resources._164_야부엉);
            this.imageList6.Add(Properties.Resources._165_레디바);
            this.imageList6.Add(Properties.Resources._166_레디안);
            this.imageList6.Add(Properties.Resources._167_페이검);
            this.imageList6.Add(Properties.Resources._168_아리아도스);
            this.imageList6.Add(Properties.Resources._169_크로뱃);
            this.imageList6.Add(Properties.Resources._170_초라기);
            this.imageList6.Add(Properties.Resources._171_랜턴);
            this.imageList6.Add(Properties.Resources._172_피츄);
            this.imageList6.Add(Properties.Resources._173_삐);
            this.imageList6.Add(Properties.Resources._174_푸푸린);
            this.imageList6.Add(Properties.Resources._175_토게피);
            this.imageList6.Add(Properties.Resources._176_토게틱);
            this.imageList6.Add(Properties.Resources._177_네이티);
            this.imageList6.Add(Properties.Resources._178_네이티오);
            this.imageList6.Add(Properties.Resources._179_메리프);
            this.imageList6.Add(Properties.Resources._180_보송송);
            this.imageList6.Add(Properties.Resources._181_전룡);
            this.imageList6.Add(Properties.Resources._182_아르코);
            this.imageList6.Add(Properties.Resources._183_마릴);
            this.imageList6.Add(Properties.Resources._184_마릴리);
            this.imageList6.Add(Properties.Resources._185_꼬지모);
            this.imageList6.Add(Properties.Resources._186_왕구리);
            this.imageList6.Add(Properties.Resources._187_통통코);
            this.imageList6.Add(Properties.Resources._188_두코);
            this.imageList6.Add(Properties.Resources._189_솜솜코);
            this.imageList6.Add(Properties.Resources._190_에이팜);
            this.imageList6.Add(Properties.Resources._191_해너츠);
            this.imageList6.Add(Properties.Resources._192_해루미);
            this.imageList6.Add(Properties.Resources._193_왕자리);
            this.imageList6.Add(Properties.Resources._194_우파);
            this.imageList6.Add(Properties.Resources._195_누오);
            this.imageList6.Add(Properties.Resources._196_에브이);
            this.imageList6.Add(Properties.Resources._197_블래키);
            this.imageList6.Add(Properties.Resources._198_니로우);
            this.imageList6.Add(Properties.Resources._199_야도킹);
            this.imageList6.Add(Properties.Resources._200_무우마);
            this.imageList6.Add(Properties.Resources._201_안농);
            this.imageList6.Add(Properties.Resources._202_마자용);
            this.imageList6.Add(Properties.Resources._203_키링키);
            this.imageList6.Add(Properties.Resources._204_피콘);
            this.imageList6.Add(Properties.Resources._205_쏘콘);
            this.imageList6.Add(Properties.Resources._206_노고치);
            this.imageList6.Add(Properties.Resources._207_글라이거);
            this.imageList6.Add(Properties.Resources._208_강철톤);
            this.imageList6.Add(Properties.Resources._209_블루);
            this.imageList6.Add(Properties.Resources._210_그랑블루);
            this.imageList6.Add(Properties.Resources._211_침바루);
            this.imageList6.Add(Properties.Resources._212_핫삼);
            this.imageList6.Add(Properties.Resources._213_단단지);
            this.imageList6.Add(Properties.Resources._214_헤라크로스);
            this.imageList6.Add(Properties.Resources._215_포푸니);
            this.imageList6.Add(Properties.Resources._216_깜지곰);
            this.imageList6.Add(Properties.Resources._217_링곰);
            this.imageList6.Add(Properties.Resources._218_마그마그);
            this.imageList6.Add(Properties.Resources._219_마그카르고);
            this.imageList6.Add(Properties.Resources._220_꾸꾸리);
            this.imageList6.Add(Properties.Resources._221_메꾸리);
            this.imageList6.Add(Properties.Resources._222_코산호);
            this.imageList6.Add(Properties.Resources._223_총어);
            this.imageList6.Add(Properties.Resources._224_대포무노);
            this.imageList6.Add(Properties.Resources._225_딜리버드);
            this.imageList6.Add(Properties.Resources._226_만타인);
            this.imageList6.Add(Properties.Resources._227_무장조);
            this.imageList6.Add(Properties.Resources._228_델빌);
            this.imageList6.Add(Properties.Resources._229_헬가);
            this.imageList6.Add(Properties.Resources._230_킹드라);
            this.imageList6.Add(Properties.Resources._231_코코리);
            this.imageList6.Add(Properties.Resources._232_코리갑);
            this.imageList6.Add(Properties.Resources._233_폴리곤2);
            this.imageList6.Add(Properties.Resources._234_노라키);
            this.imageList6.Add(Properties.Resources._235_루브도);
            this.imageList6.Add(Properties.Resources._236_배루키);
            this.imageList6.Add(Properties.Resources._237_카포에라);
            this.imageList6.Add(Properties.Resources._238_뽀뽀라);
            this.imageList6.Add(Properties.Resources._239_에레키드);
            this.imageList6.Add(Properties.Resources._240_마그비);
            this.imageList6.Add(Properties.Resources._241_밀탱크);
            this.imageList6.Add(Properties.Resources._242_해피너스);
            this.imageList6.Add(Properties.Resources._243_라이코);
            this.imageList6.Add(Properties.Resources._244_앤테이);
            this.imageList6.Add(Properties.Resources._245_스이쿤);
            this.imageList6.Add(Properties.Resources._246_애버라스);
            this.imageList6.Add(Properties.Resources._247_데기라스);
            this.imageList6.Add(Properties.Resources._248_마기라스);
            this.imageList6.Add(Properties.Resources._249_루기아);
            this.imageList6.Add(Properties.Resources._250_칠색조);
            this.imageList6.Add(Properties.Resources._251_세레비);


            this.imageList3 = new List<Image>();
            this.imageList3.Add(Properties.Resources._160_장크로다일1);
            this.imageList3.Add(Properties.Resources._161_꼬리선1);
            this.imageList3.Add(Properties.Resources._162_다꼬리1);
            this.imageList3.Add(Properties.Resources._163_부우부1);
            this.imageList3.Add(Properties.Resources._164_야부엉1);
            this.imageList3.Add(Properties.Resources._165_레디바1);
            this.imageList3.Add(Properties.Resources._166_레디안1);
            this.imageList3.Add(Properties.Resources._167_페이검1);
            this.imageList3.Add(Properties.Resources._168_아리아도스1);
            this.imageList3.Add(Properties.Resources._169_크로뱃1);
            this.imageList3.Add(Properties.Resources._170_초라기1);
            this.imageList3.Add(Properties.Resources._171_랜턴1);
            this.imageList3.Add(Properties.Resources._172_피츄1);
            this.imageList3.Add(Properties.Resources._173_삐1);
            this.imageList3.Add(Properties.Resources._174_푸푸린1);
            this.imageList3.Add(Properties.Resources._175_토게피1);
            this.imageList3.Add(Properties.Resources._176_토게틱1);
            this.imageList3.Add(Properties.Resources._177_네이티1);
            this.imageList3.Add(Properties.Resources._178_네이티오1);
            this.imageList3.Add(Properties.Resources._179_메리프1);
            this.imageList3.Add(Properties.Resources._180_보송송1);
            this.imageList3.Add(Properties.Resources._181_전룡1);
            this.imageList3.Add(Properties.Resources._182_아르코1);
            this.imageList3.Add(Properties.Resources._183_마릴1);
            this.imageList3.Add(Properties.Resources._184_마릴리1);
            this.imageList3.Add(Properties.Resources._185_꼬지모1);
            this.imageList3.Add(Properties.Resources._186_왕구리1);
            this.imageList3.Add(Properties.Resources._187_통통코1);
            this.imageList3.Add(Properties.Resources._188_두코1);
            this.imageList3.Add(Properties.Resources._189_솜솜코1);
            this.imageList3.Add(Properties.Resources._190_에이팜1);
            this.imageList3.Add(Properties.Resources._191_해너츠1);
            this.imageList3.Add(Properties.Resources._192_해루미1);
            this.imageList3.Add(Properties.Resources._193_왕자리1);
            this.imageList3.Add(Properties.Resources._194_우파1);
            this.imageList3.Add(Properties.Resources._195_누오1);
            this.imageList3.Add(Properties.Resources._196_에브이1);
            this.imageList3.Add(Properties.Resources._197_블래키1);
            this.imageList3.Add(Properties.Resources._198_니로우1);
            this.imageList3.Add(Properties.Resources._199_야도킹1);
            this.imageList3.Add(Properties.Resources._200_무우마1);
            this.imageList3.Add(Properties.Resources._201_안농1);
            this.imageList3.Add(Properties.Resources._202_마자용1);
            this.imageList3.Add(Properties.Resources._203_키링키1);
            this.imageList3.Add(Properties.Resources._204_피콘1);
            this.imageList3.Add(Properties.Resources._205_쏘콘1);
            this.imageList3.Add(Properties.Resources._206_노고치1);
            this.imageList3.Add(Properties.Resources._207_글라이거1);
            this.imageList3.Add(Properties.Resources._208_강철톤1);
            this.imageList3.Add(Properties.Resources._209_블루1);
            this.imageList3.Add(Properties.Resources._210_그랑블루1);
            this.imageList3.Add(Properties.Resources._211_침바루1);
            this.imageList3.Add(Properties.Resources._212_핫삼1);
            this.imageList3.Add(Properties.Resources._213_단단지1);
            this.imageList3.Add(Properties.Resources._214_헤라크로스1);
            this.imageList3.Add(Properties.Resources._215_포푸니1);
            this.imageList3.Add(Properties.Resources._216_깜지곰1);
            this.imageList3.Add(Properties.Resources._217_링곰1);
            this.imageList3.Add(Properties.Resources._218_마그마그1);
            this.imageList3.Add(Properties.Resources._219_마그카르고1);
            this.imageList3.Add(Properties.Resources._220_꾸꾸리1);
            this.imageList3.Add(Properties.Resources._221_메꾸리1);
            this.imageList3.Add(Properties.Resources._222_코산호1);
            this.imageList3.Add(Properties.Resources._223_총어1);
            this.imageList3.Add(Properties.Resources._224_대포무노1);
            this.imageList3.Add(Properties.Resources._225_딜리버드1);
            this.imageList3.Add(Properties.Resources._226_만타인1);
            this.imageList3.Add(Properties.Resources._227_무장조1);
            this.imageList3.Add(Properties.Resources._228_델빌1);
            this.imageList3.Add(Properties.Resources._229_헬가1);
            this.imageList3.Add(Properties.Resources._230_킹드라1);
            this.imageList3.Add(Properties.Resources._231_코코리1);
            this.imageList3.Add(Properties.Resources._232_코리갑1);
            this.imageList3.Add(Properties.Resources._233_폴리곤21);
            this.imageList3.Add(Properties.Resources._234_노라키1);
            this.imageList3.Add(Properties.Resources._235_루브도1);
            this.imageList3.Add(Properties.Resources._236_배루키1);
            this.imageList3.Add(Properties.Resources._237_카포에라1);
            this.imageList3.Add(Properties.Resources._238_뽀뽀라1);
            this.imageList3.Add(Properties.Resources._239_에레키드1);
            this.imageList3.Add(Properties.Resources._240_마그비1);
            this.imageList3.Add(Properties.Resources._241_밀탱크1);
            this.imageList3.Add(Properties.Resources._242_해피너스1);
            this.imageList3.Add(Properties.Resources._243_라이코1);
            this.imageList3.Add(Properties.Resources._244_앤테이1);
            this.imageList3.Add(Properties.Resources._245_스이쿤1);
            this.imageList3.Add(Properties.Resources._246_애버라스1);
            this.imageList3.Add(Properties.Resources._247_데기라스1);
            this.imageList3.Add(Properties.Resources._248_마기라스1);
            this.imageList3.Add(Properties.Resources._249_루기아1);
            this.imageList3.Add(Properties.Resources._250_칠색조1);
            this.imageList3.Add(Properties.Resources._251_세레비1);

            if (this.num == null)
                this.num = new List<int>();

            while (this.num.Count < 92)
            {
                pic = GetMyRandomNumber(0, 91);

                if (this.num.Contains(pic) == false)
                {
                    this.num.Add(pic);
                    break;
                }
            }
            
            this.pictureBox1.Image = imageList3[pic];
            //10개 랜덤 박스에 표시.   

            this.name2 = new List<string>();
            name2.Add("장크로다일");
            name2.Add("꼬리선");
            name2.Add("다꼬리");
            name2.Add("부우부");
            name2.Add("야부엉");
            name2.Add("레디바");
            name2.Add("레디안");
            name2.Add("페이검");
            name2.Add("아리아도스");
            name2.Add("크로뱃");
            name2.Add("초라기");
            name2.Add("랜턴");
            name2.Add("피츄");
            name2.Add("삐");
            name2.Add("푸푸린");
            name2.Add("토게피");
            name2.Add("토게틱");
            name2.Add("네이티");
            name2.Add("네이티오");
            name2.Add("메리프");
            name2.Add("보송소");
            name2.Add("전룡");
            name2.Add("아르코");
            name2.Add("마릴");
            name2.Add("마릴리");
            name2.Add("꼬지모");
            name2.Add("왕구리");
            name2.Add("통통코");
            name2.Add("두코");
            name2.Add("솜솜코");
            name2.Add("에이팜");
            name2.Add("해너츠");
            name2.Add("해루미");
            name2.Add("왕자리");
            name2.Add("우파");
            name2.Add("누오");
            name2.Add("에브이");
            name2.Add("블래키");
            name2.Add("니로우");
            name2.Add("야도킹");
            name2.Add("무우마");
            name2.Add("안농");
            name2.Add("마자용");
            name2.Add("키링키");
            name2.Add("피콘");
            name2.Add("쏘콘");
            name2.Add("노고치");
            name2.Add("글라이거");
            name2.Add("강철톤");
            name2.Add("블루");
            name2.Add("그랑블루");
            name2.Add("침바루");
            name2.Add("핫삼");
            name2.Add("단단지");
            name2.Add("헤라크로스");
            name2.Add("포푸니");
            name2.Add("깜지곰");
            name2.Add("링곰");
            name2.Add("마그마그");
            name2.Add("마그카르고");
            name2.Add("꾸꾸리");
            name2.Add("메꾸리");
            name2.Add("코산호");
            name2.Add("총어");
            name2.Add("대포무노");
            name2.Add("딜리버드");
            name2.Add("만타인");
            name2.Add("무장조");
            name2.Add("델빌");
            name2.Add("헬가");
            name2.Add("킹드라");
            name2.Add("코코리");
            name2.Add("코리갑");
            name2.Add("폴리곤2");
            name2.Add("노라키");
            name2.Add("루브도");
            name2.Add("배루키");
            name2.Add("카포에라");
            name2.Add("뽀뽀라");
            name2.Add("에레키드");
            name2.Add("마그비");
            name2.Add("밀탱크");
            name2.Add("해피너스");
            name2.Add("라이코");
            name2.Add("앤테이");
            name2.Add("스이쿤");
            name2.Add("애버라스");
            name2.Add("데기라스");
            name2.Add("마기라스");
            name2.Add("루기아");
            name2.Add("칠색조");
            name2.Add("세레비");
         
            int[] rand4 = GetRandoms2(pic, 4);
            this.one = rand4[0];
            this.two = rand4[1];
            this.three = rand4[2];
            this.four = rand4[3];
            label1.Text = name2[one];
            label2.Text = name2[two];
            label7.Text = name2[three];
            label9.Text = name2[four];
        }
        //고급


        public Form2()
        {
            InitializeComponent();
            // 디자인한 내용을 적용 시키기 위해서는 cs의 생성자에 InitializeComponent() 함수를 호출 하여 정의된 내용 대로 표시

            button12.Hide();

           // 엔딩시 출력될 버튼 숨김
         
            this.FormBorderStyle = FormBorderStyle.None;
            //폼 테두리 제거를 위한 코딩

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // gif 깜빡임을 줄이기 위해 메시지를 통해 페인트를 활성화합니다. 

            easy();
          //easy 메서드 실행
        }







        public static int[] GetRandoms(int defaultValue, int count)
        {//pic값과 count값 4를 인자로 받아옴
            Random a = new Random();
            List<int> randomList = new List<int>();
            //랜덤 생성 후, int 자료형 리스트 생성
            randomList.Add(defaultValue);
            //randomList에 pic값을 추가 해준다.
            while (randomList.Count < count)
            {//리스트의 요소가 count 즉 4보다 작을동안만 진행된다.
                //
                int newRandom = a.Next(0,78 );
                //랜덤값은 0부터 78까지 
                if (!randomList.Contains(newRandom))
                    //리스트에 newRandom이 포함되어있지 않으면 다시 newRandom의 값을 추가한다.
                    randomList.Add(newRandom);
            }
            return randomList.OrderBy(newRandom => Guid.NewGuid()).ToArray();
            //랜덤리스트의 값들을 초기화하여 반환해줌 . 
            // 초급 중급 고급 마다 리스트와 개수가 달라 3개로 만들었음.
        }

        public static int[] GetRandoms1(int defaultValue, int count)
        {
            Random a = new Random();
            List<int> randomList2 = new List<int>();
            randomList2.Add(defaultValue);
            while (randomList2.Count < count)
            {
                int newRandom = a.Next(0, 79);
                if (!randomList2.Contains(newRandom))
                    randomList2.Add(newRandom);
            }
            return randomList2.OrderBy(newRandom => Guid.NewGuid()).ToArray();

        }//중급용

        public static int[] GetRandoms2(int defaultValue, int count)
        {
            Random a = new Random();
            List<int> randomList3 = new List<int>();
            randomList3.Add(defaultValue);
            while (randomList3.Count < count)
            {
                int newRandom = a.Next(0, 91);
                if (!randomList3.Contains(newRandom))
                    randomList3.Add(newRandom);
            }
            return randomList3.OrderBy(newRandom => Guid.NewGuid()).ToArray();
        }//고급용



        private void main_Shown(object sender, EventArgs e)
        {
            Point = 0;
            picc = 0;
            Stage = 0;
            Stagee = 0;
            //폼이 처음 등장할 때 값들을 초기화 시켜줌.
            //게임을 재시작 했을경우 오류 방지

            this.button1.TabStop = false;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;

            this.button2.TabStop = false;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;

            this.button3.TabStop = false;
            this.button3.FlatStyle = FlatStyle.Flat;
            this.button3.FlatAppearance.BorderSize = 0;
            // 1~3까지 힌트
           
            this.button4.TabStop = false;
            this.button4.FlatStyle = FlatStyle.Flat;
            this.button4.FlatAppearance.BorderSize = 0;//x박스

            this.button5.TabStop = false;
            this.button5.FlatStyle = FlatStyle.Flat;
            this.button5.FlatAppearance.BorderSize = 0;// ?박스

            this.button6.TabStop = false;
            this.button6.FlatStyle = FlatStyle.Flat;
            this.button6.FlatAppearance.BorderSize = 0;// stage text박스

            this.button7.TabStop = false;
            this.button7.FlatStyle = FlatStyle.Flat;
            this.button7.FlatAppearance.BorderSize = 0;//point 박스

            this.button8.TabStop = false;
            this.button8.FlatStyle = FlatStyle.Flat;
            this.button8.FlatAppearance.BorderSize = 0;// stage박스


            this.button9.TabStop = false;
            this.button9.FlatStyle = FlatStyle.Flat;
            this.button9.FlatAppearance.BorderSize = 0;// 하트
            this.button10.TabStop = false;
            this.button10.FlatStyle = FlatStyle.Flat;
            this.button10.FlatAppearance.BorderSize = 0;// 하트
            this.button11.TabStop = false;
            this.button11.FlatStyle = FlatStyle.Flat;
            this.button11.FlatAppearance.BorderSize = 0;//  하트           

            this.button12.TabStop = false;
            this.button12.FlatStyle = FlatStyle.Flat;
            this.button12.FlatAppearance.BorderSize = 0; //엔딩시 출력 버튼 !congraturation
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //x버튼 폼 종료
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 man = new Form3();
            man.ShowDialog();
            
        }//도움말 모달형식으로 열어, 폼을 연상태로 아무것도 못함!


        private void label1_Click(object sender, EventArgs e)
        {//label1 클릭시
            if (pic == this.one)
            {//pic의값과 this.one은 각 easy,middle, hard 메서드를 실행했을 때, string 리스트의 값이 저장됨 (two,three,four 마찬가지)
                lev();
                //lev 메서드 실행
            }
            else
            {//값들이 일치하지 않을경우 ( 오답 클릭)
                Life--;
                //life -1
                xx.PlaySync(); // 오답소리  
                liff(Life); //liff메서드 실행
            }
        }
        //각 라벨을 클릭했을경우 같은 코드를 사용하여 생략하겠음.

        private void label2_Click(object sender, EventArgs e)
        {
            if (pic == this.two)
            {
                lev();
            }
            else
            {
                Life--;
                xx.PlaySync();
                liff(Life);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (pic == this.three)
            { 
                lev();
            }
            else
            {
                Life--;
                xx.PlaySync();
                liff(Life);
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {
            if (pic == this.four)
            {
                lev();
            }
            else
            {
                Life--;
                xx.PlaySync();
                liff(Life);
            }
        }

        public void endd()
        {
            if (Life <= 0)
            { //Life값이 0보다 작거나 같을경우 (게임종료)
                pictureBox1.Hide();
                button1.Hide();
                button2.Hide();
                button3.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
                button8.Hide();
                button9.Hide();
                button10.Hide();
                button11.Hide();
                label1.Hide();
                label2.Hide();
                label7.Hide();
                label9.Hide();
                //gif화면 출력을 위해 내용들을 모두 hide로 숨겨준다.
                this.backgroundWorker1.RunWorkerAsync();
                //backgroundworker를 사용하는 이유는 gif가 실행되는동안 그냥 일반적으로 사운드 실행시킬시 소리먼저 실행후, gif가 출력됨
                //동시에 실행시키기 위해 backgroundworker를 사용한다.
                animatedImage = Properties.Resources.fa;
                //animatedImage에 fa.gif 초기화
                this.BackgroundImage = animatedImage;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                //배경 설정
                AnimateImage();
              //AnimateImage메서드 호출

                this.timer = new Timer();
                this.timer.Interval = 4000;
                //타이머 4초
                this.timer.Start();
                //타이머 시작
                this.timer.Tick += new EventHandler(timer_Tick);
                //타이머 시작하고 4초후 다음 동작을 위해 timer_Tick 을 사용
            }
        }
       
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ff = new Form1();
            ff.Show();
            this.timer.Stop();
            //4초가 지나면 현재 폼을 숨기고 Form1 즉, 처음으로 가고 timer 를 종료시킴

        }



        public void AnimateImage()
        {
            //Begin the animation only once. 
            ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
            //gif 구동을 위한 코드.
        }


        public void OnFrameChanged(object o, EventArgs e)
        {
                ImageAnimator.UpdateFrames();
            //현재 애니메이션 효과를 주는 모든 이미지에서 프레임을 앞으로 이동함
                BackgroundImage = this.animatedImage;
            //배경화면 초기화
                this.Invalidate();
            // Paint 이벤트 핸들러에 대한 호출을 강제 실행합니다.
        }//https://msdn.microsoft.com/ko-kr/library/system.drawing.imageanimator.animate(v=vs.110).aspx 참조






        public void liff(int y)
        {//life 버튼에 관한 이벤트
            switch (y)
            {
                case 2:
                    button9.Hide();
                    break;
                    
                case 1:
                    button10.Hide();
                    break;
                case 0:
                    button11.Hide();
                    endd();
                    
                    break;
            }//life의 값이 2,1,0 일때마다 버튼을 숨김 0이되면 endd메서드 실행

        }



        public void swii(int x)
        { //point값을 인자로 받아 메서드 실행
            switch (x)
            {
                case 1:
                   
                    button7.BackgroundImage = Properties.Resources._2;
                    break;
                case 2:
                    button7.BackgroundImage = Properties.Resources._3;
                    break;
                case 3:
                    button7.BackgroundImage = Properties.Resources._4;
                    break;
                case 4:
                    button7.BackgroundImage = Properties.Resources._5;
                    break;
                case 5:
                    button7.BackgroundImage = Properties.Resources._6;
                    break;
                case 6:
                    button7.BackgroundImage = Properties.Resources._7;
                    break;
                case 7:
                    button7.BackgroundImage = Properties.Resources._8;
                    break;
                case 8:
                    button7.BackgroundImage = Properties.Resources._9;
                    break;
                case 9:
                    button7.BackgroundImage = Properties.Resources._10;
                    break;
                    //버튼 7은 포인트의 이미지가 저장됨. 포인트가 올라갈 때 마다 button7의 이미지도 변경시킴
                case 10:          
                        Stage++;
                    Stagee++;
                   //point값이 10이된다면 stage에 +1을 해준다.
                    switch (Stage)
                    {//그 후, stage별 button 8 의 stage 표시를 easy 에서 MIDDLE, HARD로 변경해주고,
                        //stage이동을 할때 num안에 저장된 pic값들을 clear키워드로 초기화시켜준다.
                        case 1:
                            
                            button8.BackgroundImage = Properties.Resources.MIDDLE;
                            this.num.Clear();

                            break;
                        case 2:
                       
                            button8.BackgroundImage = Properties.Resources.HARD;
                            this.num.Clear();
                            break;
                    }

                    if ((Stage >= 3) && (Point >= 10))
                    {//stage가 3이상이고 point 가 10이상이면 stage, point , stage 버튼을 숨긴다. button4가 잘 나오기위해
                        button6.Hide();
                        button7.Hide();
                        button8.Hide();
                    }
                    else
                    {
                        Point = 0;
                        button7.BackgroundImage = Properties.Resources._1;
                    }//stage가 변경될때 point를 0으로 초기화 시켜주고 button의 이미지도 0으로 변경시켜준다.
                
                    break;
            }
        }


        public void lev() {
            
            switch (Stage)
            {//stage의 값에따라 실행됨
                case 0:
                    //stage 0 즉 초급 stage일때
                    
                    Point++;
                    pictureBox1.Image = imageList4[pic];
                    Application.DoEvents();
                    
                    //point 를 +1해주고 imageLIST4의 pic번째의 사진(imageList4,5,6은 그냥 사진임)을 불러온다.
                    //doevents를 제거하면 전 코드가 너무빨리 지나가서 보이질 않는다.(바로 다음 그림자로 넘어감)
                    swii(Point);
                  //point를 인자로 swii메서드 실행

                    oo.PlaySync();
                    //정답 소리 호출
                    System.Threading.Thread.Sleep(800);
                    // 너무 빨리 넘어가는 경우를 대비해 1초 대기
                    if (Stage == 0)
                        easy();
                   
                    if (Stage == 1)
                    {
                        this.backgroundWorker3.RunWorkerAsync();
                        middle();
                    }
                    //stage가 그대로 0이면 다시 easy메서드 실행하고 변경되어 값이 1이 된다면 
                    //stage변경 소리를 출력한다. backgroundWorker를 사용하지않으면 시간을 너무 잡아먹어, 백그라운드로 동시에 실행시킴
                    break;
                   
                case 1:

                    Point++;
                  ;
                    pictureBox1.Image = imageList5[pic];
                    Application.DoEvents();
                   
                    swii(Point);
                    oo.PlaySync();
                    System.Threading.Thread.Sleep(800);
                    if (Stage == 1)
                        middle();

                    if (Stage == 2)
                    {
                        this.backgroundWorker3.RunWorkerAsync();
                        hard();
                      }
                    break;
                    //case0과 동일하다.
                case 2:
                   
                    Point++;
                    pictureBox1.Image = imageList6[pic];
                    Application.DoEvents();
                   
                    swii(Point);
                    oo.PlaySync();
                    System.Threading.Thread.Sleep(800);
                    //case 0,1과 동일하다.
                    if (Stage >= 3)
                    {
                //stage의 값이 3이상이되면 stage>=3일때의 소리파일을 backgroundWorker로 실행시킨다.
                //gif와 동일하게 시작하고 종료시키기 위해. 
                        this.backgroundWorker1.RunWorkerAsync();
                        button12.Show();//콩그래츄레이션~
                        label1.Hide();
                        label2.Hide();
                        label7.Hide();
                        label9.Hide();
                        //label 숨김
                        this.num.Clear();// num을 초기화 시켜준다. 게임을 모두 마치고 다시 시작할 경우를 위해.
                        aanimatedImage = Properties.Resources.endh;
                     //end happy를 줄여서 endh로 지정했음ㅎㅎ
                     //endh.gif 파일을 초기화시켜준다.
                        this.pictureBox1.Image = aanimatedImage;
                      //picturebox에 초기화시켜줌
                        AnimateImage();
                        //AnimateImage메서드 호출


                        this.timer = new Timer();
                        this.timer.Interval = 7200;

                        this.timer.Start();
                        this.timer.Tick += new EventHandler(timer_Tick);
                        //endd메서드와 같은 방식.
                        //차이점은 background에서의 gif구현과
                        //picturebox에서의 gif구현 차이.
                    }
                    else
                    //stage가 2일 경우 계속 hard 메서드 실행
                    {
                        hard();
                    }
                    break;
            }
        }




        
        public void hintt()  //힌트사용 메서드
        {
          
            switch (Stage)
            {
                case 0:
                    this.backgroundWorker2.RunWorkerAsync();
                    picc=pic;
                    Form5 frm = new Form5();
                    frm.ShowDialog();
                   //클릭과 동시에 소리와 폼을 열기위해 backgroundworker를 사용함.
                   //모달폼 형식으로 폼을 열어줌. case별 코드 동일.
                    break;
               case 1:
                    this.backgroundWorker2.RunWorkerAsync();
                    picc = pic;
                    Form5 frm1 = new Form5();
                    frm1.ShowDialog();
              
                    break;
                 
                case 2:
                    this.backgroundWorker2.RunWorkerAsync();
                    picc = pic;
                    Form5 frm2 = new Form5();
                    frm2.ShowDialog();
                    
                    break;
              }

        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //엔딩
            if (Life <= 0)
                lose.PlaySync();
            if (Stage>=3)
                win.PlaySync();
          //조건에 맞는 엔딩 사운드 호출
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            hint.PlaySync();
        }
        //hint버튼 클릭 사운드호출
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
             st.PlaySync();
        }//stage 변경시 사운드 호출

      

    

        private void button1_Click(object sender, EventArgs e)
        {
            hintt();
            button1.Hide();
            //button1~3 까지 힌트 .
            //hintt메서드 호출후 hide
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hintt();
            button2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hintt();
            button3.Hide();

        }


       
       
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & Keys.Enter) == Keys.Enter)
                return true;
            if ((keyData & Keys.Space) == Keys.Space )
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //space나 enter를누를경우 힌트가 나오는 버그가 생기는데 hint가 버튼으로 만들어져서 그러함.
        //윈폼에서 button은' Button 컨트롤을 사용하는 경우 단추 활성화를 위해 스페이스바 키나 Enter 키를 이미 처리합니다.'
        //라고 MSDN에 나와있다.
        //그래서 키를 못쓰게 막아버림!
    }
}
