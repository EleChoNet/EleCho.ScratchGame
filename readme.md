# EleCho.ScratchGame

һ��С�͵ĵ�, ���� GDI+ �� 2D ��Ϸ����. [����鿴Ԥ����Ƶ](resrc/videos/preview.mp4)

> ���������: MIT �� [Scratch](https://scratch.mit.edu/)

## ���� / Features

- [x] ��Ϸ����
- [x] ��������
- [x] ��Ϸ��ɫ��������ת

## ���� / Get started

Ҫ������Ϸ������߼�����, ����Ҫ����һ�� Game ����, �������������е���Ϸ����(GameObject)

```csharp
Game game = new Game();
```

������, ���������Ϸ�����һ����򵥵���ͼ:

```csharp
Bitmap bmp;  // ������������Ҫ��ʾ����ͼ
game.AddSprite(new GameSprite()
{
    Sprite = bmp    // Ϊ GameSprite ����ͼ
});
```

Ϊ���� WinForm �����н�����Ϸ��Ⱦ, ����Ҫһ�� GamePanel, �����϶�������, Ȼ����ָ����Ҫ��Ⱦ����Ϸ

```csharp
void Load(object sender, EventArgs args)
{
    gamePanel.Game = game;    // Ϊ GamePanel ָ��Ҫ��Ⱦ����Ϸ
}
```

Ҫ������Ϸ�߼�����ѭ���Լ���Ⱦѭ��, �����䷽������:

```csharp
game.StartGame();
gamePanel.StartRender();
```

## ʹ�� / Usage

### �Զ�����Ϸ����

ʵ�ָ��ӵĹ���, �����ʹ�ö����Լ�������, �̳� GameSprite ���� GameText, ����д��ط���.

������һ�����������ƶ�����Ϸ������:

```csharp
class MoveRightForever : GameSprite
{
    public float Speed { get; set; } = 1f;
    public override void Update()
    {
        // SizeF ��ʾλ��, ���� Game.DeltaTime ��ʹ���ٶȲ���֡�ʱ仯��Ӱ��
        Position += new SizeF(Speed, 0) * Game.DeltaTime;
    }
}
```