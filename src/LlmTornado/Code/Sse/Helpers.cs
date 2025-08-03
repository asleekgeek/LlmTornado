﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Buffers;
using System.Globalization;
using System.Text;

namespace LlmTornado.Code.Sse;

internal static class Helpers
{
    public static void WriteUtf8Number(this IBufferWriter<byte> writer, long value)
    {
        const int MaxDecimalDigits = 20;
#if MODERN
            Span<byte> buffer = writer.GetSpan(MaxDecimalDigits);
            bool success = value.TryFormat(buffer, out int bytesWritten, provider: CultureInfo.InvariantCulture);
#else 
        string numberString = value.ToString(CultureInfo.InvariantCulture);
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(numberString);
        int bytesWritten = utf8Bytes.Length;
        Span<byte> buffer = writer.GetSpan(bytesWritten);
        utf8Bytes.CopyTo(buffer.ToArray(), 0); 
#endif
        writer.Advance(bytesWritten);
    }

    public static void WriteUtf8String(this IBufferWriter<byte> writer, ReadOnlySpan<byte> value)
    {
        if (value.IsEmpty)
        {
            return;
        }

        Span<byte> buffer = writer.GetSpan(value.Length);
        value.CopyTo(buffer);
        writer.Advance(value.Length);
    }

    public static void WriteUtf8String(this IBufferWriter<byte> writer, ReadOnlySpan<char> value)
    {
        if (value.IsEmpty)
        {
            return;
        }

#if MODERN
            int maxByteCount = Encoding.UTF8.GetMaxByteCount(value.Length);
            Span<byte> buffer = writer.GetSpan(maxByteCount);
            int bytesWritten = Encoding.UTF8.GetBytes(value, buffer);
#else
        string stringValue = value.ToString();
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(stringValue);
        int bytesWritten = utf8Bytes.Length;
        Span<byte> buffer = writer.GetSpan(bytesWritten);
        Array.Copy(utf8Bytes, 0, buffer.ToArray(), 0, bytesWritten);
#endif
    
        writer.Advance(bytesWritten);
    }
        
    public static void WriteUtf8String(this IBufferWriter<byte> writer, string? val)
    {
        if (val is null || val.Length is 0)
        {
            return;
        }

#if MODERN
            int maxByteCount = Encoding.UTF8.GetMaxByteCount(val.Length);
            Span<byte> buffer = writer.GetSpan(maxByteCount);
            int bytesWritten = Encoding.UTF8.GetBytes(val, buffer);
#else
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(val);
        int bytesWritten = utf8Bytes.Length;
        Span<byte> buffer = writer.GetSpan(bytesWritten);
        Array.Copy(utf8Bytes, 0, buffer.ToArray(), 0, bytesWritten);
#endif
    
        writer.Advance(bytesWritten);
    }

        
    public static bool ContainsLineBreaks(this ReadOnlySpan<char> text) => 
        text.IndexOfAny('\r', '\n') >= 0;
}