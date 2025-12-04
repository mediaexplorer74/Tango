// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.SortedList`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  internal sealed class SortedList<TKey, TValue> : 
    IDictionary<TKey, TValue>,
    ICollection<KeyValuePair<TKey, TValue>>,
    IEnumerable<KeyValuePair<TKey, TValue>>,
    IEnumerable
  {
    private readonly IDictionary<TKey, TValue> wrapped = (IDictionary<TKey, TValue>) new Dictionary<TKey, TValue>();

    public SortedList()
    {
    }

    public SortedList(IDictionary<TKey, TValue> dictionary)
    {
      foreach (KeyValuePair<TKey, TValue> keyValuePair in (IEnumerable<KeyValuePair<TKey, TValue>>) dictionary)
        this.Add(keyValuePair.Key, keyValuePair.Value);
    }

    public void Add(TKey key, TValue value) => this.wrapped.Add(key, value);

    public bool ContainsKey(TKey key) => this.wrapped.ContainsKey(key);

    public ICollection<TKey> Keys
    {
      get
      {
        List<TKey> keys = new List<TKey>(this.wrapped.Count);
        foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
          keys.Add(keyValuePair.Key);
        return (ICollection<TKey>) keys;
      }
    }

    public bool Remove(TKey key) => this.wrapped.Remove(key);

    public bool TryGetValue(TKey key, out TValue value) => this.wrapped.TryGetValue(key, out value);

    public ICollection<TValue> Values
    {
      get
      {
        List<TValue> values = new List<TValue>(this.wrapped.Count);
        foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
          values.Add(keyValuePair.Value);
        return (ICollection<TValue>) values;
      }
    }

    public TValue this[TKey key]
    {
      get => this.wrapped[key];
      set => this.wrapped[key] = value;
    }

    public void Add(KeyValuePair<TKey, TValue> item) => this.wrapped.Add(item);

    public void Clear() => this.wrapped.Clear();

    public bool Contains(KeyValuePair<TKey, TValue> item) => this.wrapped.Contains(item);

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
      this.wrapped.CopyTo(array, arrayIndex);
    }

    public int Count => this.wrapped.Count;

    public bool IsReadOnly => this.wrapped.IsReadOnly;

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
      return ((ICollection<KeyValuePair<TKey, TValue>>) this.wrapped).Remove(item);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
      IComparer<TKey> comparer = (IComparer<TKey>) Comparer<TKey>.Default;
      List<KeyValuePair<TKey, TValue>> keyValuePairList = new List<KeyValuePair<TKey, TValue>>((IEnumerable<KeyValuePair<TKey, TValue>>) this.wrapped);
      keyValuePairList.Sort((Comparison<KeyValuePair<TKey, TValue>>) ((x, y) => comparer.Compare(x.Key, y.Key)));
      return (IEnumerator<KeyValuePair<TKey, TValue>>) keyValuePairList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
