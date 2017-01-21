using System;

namespace ExpressionToIL
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine(typeof(Console));
			var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
				new System.Reflection.AssemblyName("helloworld"),
				System.Reflection.Emit.AssemblyBuilderAccess.Save
			);

			var module = assembly.DefineDynamicModule("helloworld", "helloworld.exe");
			var myType = module.DefineType(
				"Main", 
				System.Reflection.TypeAttributes.Public);
			var methodBuilder = myType.DefineMethod("Main",
													System.Reflection.MethodAttributes.Public |
													System.Reflection.MethodAttributes.Static,
			                                        typeof(void),
													new Type[] { typeof(string[]) });
			var ilGen = methodBuilder.GetILGenerator();
			ilGen.Emit(System.Reflection.Emit.OpCodes.Ldstr,
				"Hello, World!");
			ilGen.Emit(System.Reflection.Emit.OpCodes.Ldstr, 
				"Hello, World!");
			ilGen.Emit(System.Reflection.Emit.OpCodes.Call,
			               typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string[]) }));
			//ilGen.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_0);
			ilGen.Emit(System.Reflection.Emit.OpCodes.Ret);
			myType.CreateType();
			assembly.SetEntryPoint(methodBuilder, 
			                       System.Reflection.Emit.PEFileKinds.ConsoleApplication);
			assembly.Save("helloworld.exe");
		}
	}
}
