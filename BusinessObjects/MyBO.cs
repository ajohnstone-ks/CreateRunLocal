using System;
using BusinessObjects.Server;
using Csla;

namespace BusinessObjects
{
	[Serializable]
	public sealed class MyBO : BusinessBase<MyBO>
	{
		public static readonly PropertyInfo<string> MyNameProperty = RegisterProperty<string>(nameof(MyName));
		public string MyName
		{
			get => GetProperty(MyNameProperty);
			set => SetProperty(MyNameProperty, value);
		}

		public static MyBO NewBO() => DataPortal.Create<MyBO>();


		// TODO:  We'd like to compile way the entire method signature, but can't because Create won't be called
		//#if SERVER_CODE

		/// <summary>This doesn't compile in the .Client project b/c the interface only exists in the .Server project</summary>
		/// <param name="serverObj"></param>
		[Create]
		private void Create([Inject] IOnlyExistOnTheServer serverObj)
		{
			#if SERVER_CODE
			Console.WriteLine($"{serverObj}");
			#endif
		}

		// TODO:  We'd like to compile way the entire method signature, but can't
		//#endif
	}
}
