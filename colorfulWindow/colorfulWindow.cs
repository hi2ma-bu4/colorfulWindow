using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

struct Program
{
	[STAThread]
	static void Main()
	{
		Application.Run(new WindowTest());
	}
}
class WindowTest : Form
{

	public Color[] rain;
	private int colCou;
	private float OpacityCou;
	private static Timer timer1 = new Timer();
	private int mw, mh;
	private int xp, yp;
	private int nx, ny;
	private int wws = 155, whs = 155;
	private Random rnd = new System.Random();


	public WindowTest()
	{
		this.FormBorderStyle = FormBorderStyle.None;
		this.Opacity = 0;
		this.TopMost = true;
		this.ShowInTaskbar = false;
		this.Click += new EventHandler(form_Click);

		timer1.Interval = 10;
		timer1.Enabled = true;
		timer1.Tick += new EventHandler(timer1_Tick);

		rain = CreatePalette();

		mw = Screen.PrimaryScreen.Bounds.Width;
		mh = Screen.PrimaryScreen.Bounds.Height;

		nx = rnd.Next(0, mw - wws);
		ny = rnd.Next(0, mh - whs);
		colCou = rnd.Next(0, 511);
		OpacityCou = rnd.Next(-10, 0);
		xp = rnd.Next(1, 10);
		yp = rnd.Next(1, 10);
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		//loopCou++;
		colCou++;

		if (OpacityCou > 0)
		{
			if (OpacityCou > 0.3)
			{
				OpacityCou = 0.3F;
			}
			this.Opacity = OpacityCou;
		}
		else
		{
			this.Opacity = 0;
		}
		OpacityCou += 0.01F;

		if (colCou >= 510)
		{
			colCou = 0;
		}
		this.BackColor = rain[colCou > 255 ? 510 - colCou : colCou];

		nx += xp;
		ny += yp;
		if (nx >= mw * 2 - wws * 2)
		{
			nx = 0;
		}
		if (ny >= mh * 2 - whs * 2)
		{
			ny = 0;
		}

		this.SetDesktopBounds(nx >= mw - wws ? mw * 2 - wws * 2 - nx : nx, ny >= mh - whs ? mh * 2 - whs * 2 - ny : ny, wws, whs);
	}

	void form_Click(object sender, System.EventArgs e)
	{
		OpacityCou = -2;
	}

	public static Color[] CreatePalette()
	{
		Color[] _ans = new Color[256];
		// 青→緑
		for (int i = 0; i < 64; i++)
		{
			int _green = i * 4;
			_ans[i] = Color.FromArgb(255, 0, _green, 255 - _green);
		}
		// 緑→黄
		for (int i = 0; i < 64; i++)
		{
			int _red = i * 4;
			_ans[i + 64] = Color.FromArgb(255, _red, 255, 0);
		}
		// 黄→赤
		for (int i = 0; i < 128; i++)
		{
			int _green = 255 - i * 2;
			_ans[i + 128] = Color.FromArgb(255, 255, _green, 0);
		}

		return _ans;
	}

	protected override CreateParams CreateParams
	{
		get
		{
			var cp = base.CreateParams;
			cp.ExStyle |= 0x80; return cp;
		}
	}
}
