
using SkyWar;
using SkyWar.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace EleCho.ScratchGame
{
    public partial class MainForm : Form
    {
        Game game;
        GameScene startScene;
        GameScene mainScene;

        public MainForm()
        {
            InitializeComponent();

            game = new(gamePanel, 480, 700)
            {
                CanvasColor = Color.Pink
            };

            GameSound gs = new GameSound();                     // ��������
            Background bg1 = new Background();                  // ����1
            Background bg2 = new Background();                  // ����2  (����1��2�������ʵ�����޵ı���)
            Warplane player = new Warplane();                   // ���
            ScoreBoard scoreboard = new ScoreBoard();           // �Ʒְ�
            FpsBoard fpsBoard = new FpsBoard();                 // ֡����
            EnermyGen enermyGen = new EnermyGen(scoreboard);    // �������� (���Ƶ������ɵ�


            bg2.Position = new PointF(0, bg2.Sprite!.Height);

            startScene = new GameScene()
            {
                CanvasColor = Color.Pink
            };

            startScene.AddObject(fpsBoard);
            startScene.AddObject(new RotatingText()
            {
                Text = "Hello world",
                Background = new SolidBrush(Color.Cyan),
                BorderRadius = 100,
                BorderExpansion = 30,
                Scale = 3,
                Rotation = 45
            });

            mainScene = new GameScene();

            mainScene.AddObject(gs);
            mainScene.AddObject(bg1);
            mainScene.AddObject(bg2);
            mainScene.AddObject(player);
            mainScene.AddObject(scoreboard);
            mainScene.AddObject(fpsBoard);
            mainScene.AddObject(enermyGen);
        }

        /// <summary>
        /// ����������ʱ������Ϸ�߼�����Ⱦ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Resize(this, null!);

            game.StartGame();
            gamePanel.StartRender();

            game.UpdateDelay = 1;
            gamePanel.RenderDelay = 1;

            game.LoadScene(startScene);
        }

        /// <summary>
        /// ʹ��Ϸ���ʼ���ڴ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            Point center = (Point)((ClientSize - gamePanel.Size) / 2);
            gamePanel.Location = center;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            game.LoadScene(mainScene);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (game.IsRunning)
                game.StopGame();
        }
    }
}