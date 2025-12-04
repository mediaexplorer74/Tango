// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.FrameRateCounter
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace Tango.Toolbox
{
  public class FrameRateCounter
  {
    private int frameCounter;
    private long m_ElapsedTime;
    private Vector2 m_pos;
    private Vector2 m_pos1;
    private Stopwatch watch;
    private SpriteFont m_spriteFont;
    private List<long> m_record;

    public double frameRate { get; private set; }

    public double frameRateVar { get; private set; }

    public FrameRateCounter(Vector2 pos, SpriteFont spriteFont)
    {
      this.m_pos = pos;
      this.m_pos1 = new Vector2(pos.X + 1f, pos.Y);
      this.watch = new Stopwatch();
      this.m_spriteFont = spriteFont;
      this.m_record = new List<long>();
    }

    public void Reset()
    {
      this.m_ElapsedTime = 0L;
      this.frameCounter = 0;
      this.m_record.Clear();
    }

    public void Update()
    {
      this.watch.Stop();
      this.Update(this.watch.ElapsedMilliseconds);
      this.watch.Reset();
      this.watch.Start();
    }

    public void Update(long ElapsedTime)
    {
      ++this.frameCounter;
      this.m_ElapsedTime += ElapsedTime;
      this.m_record.Add(ElapsedTime);
      if (this.m_ElapsedTime <= 2000L)
        return;
      this.frameRate = (double) this.frameCounter * 1000.0 / (double) this.m_ElapsedTime;
      double num1 = 0.0;
      double num2 = 0.0;
      foreach (long num3 in this.m_record)
      {
        num1 += (double) num3;
        num2 += (double) (num3 * num3);
      }
      this.frameRateVar = Math.Sqrt(num2 / (double) this.m_record.Count - Math.Pow(num1 / (double) this.m_record.Count, 2.0));
      this.m_ElapsedTime = 0L;
      this.frameCounter = 0;
      this.m_record.Clear();
    }

    public void Draw(SpriteBatch spriteBatch, string tip)
    {
      string text = string.Format(tip, (object) this.frameRate, (object) this.frameRateVar);
      spriteBatch.DrawString(this.m_spriteFont, text, this.m_pos, Color.Black);
      spriteBatch.DrawString(this.m_spriteFont, text, this.m_pos1, Color.White);
    }

    public void Draw(SpriteBatch spriteBatch, string tip, double rate)
    {
      string text = string.Format(tip, (object) rate);
      spriteBatch.DrawString(this.m_spriteFont, text, this.m_pos, Color.Black);
      spriteBatch.DrawString(this.m_spriteFont, text, this.m_pos1, Color.White);
    }
  }
}
