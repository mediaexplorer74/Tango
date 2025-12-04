// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Collections.PopsicleList`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Collections
{
  public sealed class PopsicleList<T> : 
    IPopsicleList<T>,
    IList<T>,
    ICollection<T>,
    IEnumerable<T>,
    IEnumerable
  {
    private readonly List<T> items = new List<T>();
    private bool readOnly;

    public void MakeReadOnly() => this.readOnly = true;

    public int IndexOf(T item) => this.items.IndexOf(item);

    public void Insert(int index, T item)
    {
      this.ValidateModification();
      this.items.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
      this.ValidateModification();
      this.items.RemoveAt(index);
    }

    public T this[int index]
    {
      get => this.items[index];
      set
      {
        this.ValidateModification();
        this.items[index] = value;
      }
    }

    public void Add(T item)
    {
      this.ValidateModification();
      this.items.Add(item);
    }

    public void Clear()
    {
      this.ValidateModification();
      this.items.Clear();
    }

    public bool Contains(T item) => this.items.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) => this.items.CopyTo(array, arrayIndex);

    public int Count => this.items.Count;

    public bool IsReadOnly => this.readOnly;

    public bool Remove(T item)
    {
      this.ValidateModification();
      return this.items.Remove(item);
    }

    public void Add(IEnumerable<T> collection)
    {
      if (this.readOnly)
        throw new NotSupportedException("List is read-only");
      this.items.AddRange(collection);
    }

    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) this.items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    private void ValidateModification()
    {
      if (this.readOnly)
        throw new NotSupportedException("List is read-only");
    }
  }
}
