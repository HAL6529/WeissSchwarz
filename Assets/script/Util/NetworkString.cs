using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;

public struct NetworkString : INetworkSerializable
{
	private FixedString32Bytes info;
	public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
	{
		serializer.SerializeValue(ref info);
	}
	public override string ToString()
	{
		return info.ToString();
	}
	public static implicit operator string(NetworkString s) => s.ToString();
	public static implicit operator NetworkString(string s) => new NetworkString() { info = new FixedString32Bytes(s) };
}
