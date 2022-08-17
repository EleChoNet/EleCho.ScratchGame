
using SkyWar;
using SkyWar.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace EleCho.ScratchGame
{
    public partial class MainForm : Form
    {
        Game game;
        public MainForm()
        {
            InitializeComponent();

            game = new(gamePanel, 480, 700)
            {
                CanvasColor = Color.Pink
            };

            gamePanel.Game = game;

            GameSound gs = new GameSound();           // ��������
            GameSprite bg1 = new Background();        // ����1
            GameSprite bg2 = new Background();        // ����2  (����1��2�������ʵ�����޵ı���)
            GameSprite player = new Warplane();       // ���
            EnermyGen enermyGen = new EnermyGen();    // �������� (���Ƶ������ɵ�

            bg2.Position = new PointF(0, bg2.Sprite!.Height);

            game.AddObject(gs);
            game.AddObject(bg1);
            game.AddObject(bg2);
            game.AddObject(player);
            game.AddObject(enermyGen);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Resize(this, null!);

            game.StartGame();
            gamePanel.StartRender();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Point center = (Point)((ClientSize - gamePanel.Size) / 2);
            gamePanel.Location = center;
        }
    }
}