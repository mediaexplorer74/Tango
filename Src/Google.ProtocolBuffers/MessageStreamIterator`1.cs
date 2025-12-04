// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.MessageStreamIterator`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers
{
  public class MessageStreamIterator<TMessage> : IEnumerable<TMessage>, IEnumerable where TMessage : IMessage<TMessage>
  {
    private readonly StreamProvider streamProvider;
    private readonly ExtensionRegistry extensionRegistry;
    private readonly int sizeLimit;
    private static readonly Type[] EmptyTypes = new Type[0];
    private static readonly Func<CodedInputStream, ExtensionRegistry, TMessage> messageReader = MessageStreamIterator<TMessage>.BuildMessageReader();
    private static Exception typeInitializationException;
    private static readonly uint ExpectedTag = WireFormat.MakeTag(1, WireFormat.WireType.LengthDelimited);

    private static Func<CodedInputStream, ExtensionRegistry, TMessage> BuildMessageReader()
    {
      try
      {
        Type builderType = MessageStreamIterator<TMessage>.FindBuilderType();
        MethodInfo method = typeof (TMessage).GetMethod("CreateBuilder", MessageStreamIterator<TMessage>.EmptyTypes);
        // Stub for UWP - Delegate.CreateDelegate is not available
        // return (Func<CodedInputStream, ExtensionRegistry, TMessage>) Delegate.CreateDelegate(typeof (Func<CodedInputStream, ExtensionRegistry, TMessage>), (object) Delegate.CreateDelegate(typeof (Func<>).MakeGenericType(builderType), (object) null, method), typeof (MessageStreamIterator<TMessage>).GetMethod("BuildImpl", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof (TMessage), builderType));
        return (input, registry) => 
        {
            var builder = method.Invoke(null, null);
            var buildMethod = typeof(MessageStreamIterator<TMessage>).GetMethod("BuildImpl", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof(TMessage), builderType);
            return (TMessage)buildMethod.Invoke(null, new object[] { input, registry, builder });
        };
      }
      catch (ArgumentException ex)
      {
        MessageStreamIterator<TMessage>.typeInitializationException = (Exception) ex;
      }
      catch (InvalidOperationException ex)
      {
        MessageStreamIterator<TMessage>.typeInitializationException = (Exception) ex;
      }
      catch (InvalidCastException ex)
      {
        MessageStreamIterator<TMessage>.typeInitializationException = (Exception) ex;
      }
      return (Func<CodedInputStream, ExtensionRegistry, TMessage>) null;
    }

    private static Type FindBuilderType()
    {
      MethodInfo method = typeof (TMessage).GetMethod("CreateBuilder", MessageStreamIterator<TMessage>.EmptyTypes);
      if ((object) method == null)
        throw new ArgumentException("Message type " + typeof (TMessage).FullName + " has no CreateBuilder method.");
      Type type1 = (object) method.ReturnType != (object) typeof (void) ? method.ReturnType : throw new ArgumentException("CreateBuilder method in " + typeof (TMessage).FullName + " has void return type");
      Type type2 = typeof (IMessage<,>).MakeGenericType(typeof (TMessage), type1);
      Type type3 = typeof (IBuilder<,>).MakeGenericType(typeof (TMessage), type1);
      if (Array.IndexOf<Type>(typeof (TMessage).GetInterfaces(), type2) == -1)
        throw new ArgumentException("Message type " + (object) typeof (TMessage) + " doesn't implement " + type2.FullName);
      return Array.IndexOf<Type>(type1.GetInterfaces(), type3) != -1 ? type1 : throw new ArgumentException("Builder type " + (object) typeof (TMessage) + " doesn't implement " + type3.FullName);
    }

    private static TMessage BuildImpl<TMessage2, TBuilder>(
      Func<TBuilder> builderBuilder,
      CodedInputStream input,
      ExtensionRegistry registry)
      where TMessage2 : TMessage, IMessage<TMessage2, TBuilder>
      where TBuilder : IBuilder<TMessage2, TBuilder>
    {
      TBuilder builder = builderBuilder();
      input.ReadMessage((IBuilderLite) builder, registry);
      return (TMessage) builder.Build();
    }

    private MessageStreamIterator(
      StreamProvider streamProvider,
      ExtensionRegistry extensionRegistry,
      int sizeLimit)
    {
      if (MessageStreamIterator<TMessage>.messageReader == null)
        throw MessageStreamIterator<TMessage>.typeInitializationException;
      this.streamProvider = streamProvider;
      this.extensionRegistry = extensionRegistry;
      this.sizeLimit = sizeLimit;
    }

    private MessageStreamIterator(
      StreamProvider streamProvider,
      ExtensionRegistry extensionRegistry)
      : this(streamProvider, extensionRegistry, 67108864)
    {
    }

    public MessageStreamIterator<TMessage> WithExtensionRegistry(ExtensionRegistry newRegistry)
    {
      return new MessageStreamIterator<TMessage>(this.streamProvider, newRegistry, this.sizeLimit);
    }

    public MessageStreamIterator<TMessage> WithSizeLimit(int newSizeLimit)
    {
      return new MessageStreamIterator<TMessage>(this.streamProvider, this.extensionRegistry, newSizeLimit);
    }

    public static MessageStreamIterator<TMessage> FromFile(string file)
    {
      return new MessageStreamIterator<TMessage>((StreamProvider) (() => (Stream) File.OpenRead(file)), ExtensionRegistry.Empty);
    }

    public static MessageStreamIterator<TMessage> FromStreamProvider(StreamProvider streamProvider)
    {
      return new MessageStreamIterator<TMessage>(streamProvider, ExtensionRegistry.Empty);
    }

    public IEnumerator<TMessage> GetEnumerator()
    {
      using (Stream stream = this.streamProvider())
      {
        CodedInputStream input = CodedInputStream.CreateInstance(stream);
        input.SetSizeLimit(this.sizeLimit);
        uint tag;
        while ((tag = input.ReadTag()) != 0U)
        {
          if ((int) tag != (int) MessageStreamIterator<TMessage>.ExpectedTag)
            throw InvalidProtocolBufferException.InvalidMessageStreamTag();
          yield return MessageStreamIterator<TMessage>.messageReader(input, this.extensionRegistry);
          input.ResetSizeCounter();
        }
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
