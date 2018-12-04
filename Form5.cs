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
    public partial class Form5 : Form
    {
        private List<Image> imageList4 = null;//초급 사진
        private List<Image> imageList5 = null;//중급 사진
        private List<Image> imageList6 = null;//고급 사진

        private List<string> name = null;//초급 포켓몬 이름
        private List<string> name1 = null;//중급 포켓몬 이름
        private List<string> name2 = null;// 고급 포켓몬 이름
        


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
                ReleaseCapture();
                // 다른 컨트롤에 묶여있을 수 있을 수 있으므로 마우스캡쳐 해제        
                SendMessage(this.Handle, WM_NLBUTTONDOWN, HT_CAPTION, 0);
                // 타이틀 바의 다운 이벤트처럼 보냄
            }
            base.OnMouseDown(e);
        }

        private int a,b = 0;
        //a,b값 초기화 각 picc값과 stagee의 값이 저장될 공간.
        public Form5()
        {
            InitializeComponent();
           
            this.FormBorderStyle = FormBorderStyle.None; 
            //폼 테두리 제거

            this.button1.TabStop = false;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            // 종료 버튼
            this.button2.TabStop = false;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            //포켓몬 이름 표시될 BUTTON

            a = Form2.picc;         
            b = Form2.Stagee;
            //각 값들을 Form2에서 끌어다 초기화 시킨다.
            switch (b) {
                case 0:
                    easy();
                    break;
                case 1:
                    middle();
                    break;
                case 2:
                    hard();
                    break;
            }
        }
        //Form2의 구현방식과 같은형식이다. stage의 값의 변경에 따라
        //easy, middle, hard 값이 호출된다.

        public void easy()
        {
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

            this.pictureBox1.Image = imageList4[a];
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.name = new List<string>();
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

            this.button2.Text = name[a];
        }
 //초급인 경우의 코드. a의 값에 따라 list의 a번째에 있는 image와 string 값을 출력한다.
 //middle , hard 메서드 모두 동일하다.
    

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

            this.pictureBox1.Image = imageList5[a];
            this.BackgroundImageLayout = ImageLayout.Stretch;

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
            this.button2.Text = name1[a];
        }


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
            this.pictureBox1.Image = imageList6[a];
            this.BackgroundImageLayout = ImageLayout.Stretch;

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
            this.button2.Text = name2[a];
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
        //아무 버튼이나 눌러도 종료되게 만듬.
        //귀찮다는 사람이 있어서..

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//x버튼 누르면 종료


      
    }
    }