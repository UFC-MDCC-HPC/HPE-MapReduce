using System;

using br.ufc.mdcc.mapreduce.impl.FetchValuesImpl;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.String;
using System.Runtime.Remoting;
using br.ufc.mdcc.common.Integer;
using br.ufc.pargo.hpe.basic;

namespace MapReduceforHPE
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IMapperFetchValuesImpl<IData,IData,IPartitionFunction<IData>> v 
				= new IMapperFetchValuesImpl<IData,IData,IPartitionFunction<IData>>();

			ObjectHandle obj = Activator.CreateInstance("br.ufc.mdcc.mapreduce.impl.FetchValuesImpl.IMapperFetchValuesImpl, Culture=neutral, Version=0.0.0.0, PublicKey=00240000048000009400000006020000002400005253413100040000110000006518BBB156EE20C9A632DD75F46D9DF539EC781711B994ED08DE1049591AB9AC4319A82B258D1C622338E61FB85C652661560B27541D7B2CC457451F1EA2348342655FA3B31EFAD8ED69D70AB2FB206EFBF3F0EED29A2C4858909D4F34524B746A69057F1176A7BA63CA347CFBC3C1BA10083D26A12A0F1487C942CE7BFC93B9", "br.ufc.mdcc.mapreduce.impl.FetchValuesImpl.IMapperFetchValuesImpl`3[[br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.String.IString, Version=0.0.0.0, Culture=neutral, PublicKeyToken=210b717c41e5fb9a],[br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.common.Integer.IInteger, Version=0.0.0.0, Culture=neutral, PublicKeyToken=6e4ef4e52862aa0b],[br.ufc.mdcc.mapreduce.user.PartitionFunction.IPartitionFunction`1[[br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.String.IString, Version=0.0.0.0, Culture=neutral, PublicKeyToken=210b717c41e5fb9a]], br.ufc.mdcc.mapreduce.user.PartitionFunction.IPartitionFunction, Version=0.0.0.0, Culture=neutral, PublicKeyToken=5dc901255e59d908]]");

			IUnit u = (IUnit) obj.Unwrap();	

			//IMapperFetchValuesImpl<IString,IInteger,IPartitionFunction<IString>> vv = (IMapperFetchValuesImpl<IString,IInteger,IPartitionFunction<IString>>) obj.Unwrap();

			Console.WriteLine ("Hello World!");
		}
	}
}
