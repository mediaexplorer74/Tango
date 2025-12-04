// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Collections.ReadOnlyDictionary`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Collections
{
  public sealed class ReadOnlyDictionary<TKey, TValue> : 
    IDictionary<TKey, TValue>,
    ICollection<KeyValuePair<TKey, TValue>>,
    IEnumerable<KeyValuePair<TKey, TValue>>,
    IEnumerable
  {
    private readonly IDictionary<TKey, TValue> wrapped;

    public ReadOnlyDictionary(IDictionary<TKey, TValue> wrapped) => this.wrapped = wrapped;

    public void Add(TKey key, TValue value) => throw new InvalidOperationException();

    public bool ContainsKey(TKey key) => this.wrapped.ContainsKey(key);

    public ICollection<TKey> Keys => this.wrapped.Keys;

    public bool Remove(TKey key) => throw new InvalidOperationException();

    public bool TryGetValue(TKey key, out TValue value) => this.wrapped.TryGetValue(key, out value);

    public ICollection<TValue> Values => this.wrapped.Values;

    public TValue this[TKey key]
    {
      get => this.wrapped[key];
      set => throw new InvalidOperationException();
    }

    public void Add(KeyValuePair<TKey, TValue> item) => throw new InvalidOperationException();

    public void Clear() => throw new InvalidOperationException();

    public bool Contains(KeyValuePair<TKey, TValue> item) => this.wrapped.Contains(item);

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
      this.wrapped.CopyTo(array, arrayIndex);
    }

    public int Count => this.wrapped.Count;

    public bool IsReadOnly => true;

    public bool Remove(KeyValuePair<TKey, TValue> item) => throw new InvalidOperationException();

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => this.wrapped.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.wrapped.GetEnumerator();

    public override bool Equals(object obj) => this.wrapped.Equals(obj);

    public override int GetHashCode() => this.wrapped.GetHashCode();

    public override string ToString() => this.wrapped.ToString();
  }
}
