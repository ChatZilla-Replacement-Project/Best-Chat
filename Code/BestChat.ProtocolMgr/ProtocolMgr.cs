// Ignore Spelling: Defs

using System.Linq;

namespace BestChat.ProtocolMgr
{
	public abstract class ProtocolMgr : System.ComponentModel.INotifyPropertyChanged
	{
		#region Constructors & Deconstructors
			protected ProtocolMgr()
			{
				System.Reflection.Assembly? assemblyEntry = System.Reflection.Assembly.GetEntryAssembly() ?? throw
					new System.InvalidProgramException("For some reason, BestChat.ProtocolMgr.ProtocolMgr was" +
						" called from non-managed code.");

			string? strEntryAssemblyLoc = System.IO.Path.GetDirectoryName(assemblyEntry.Location);
				if(strEntryAssemblyLoc == null || strEntryAssemblyLoc == "")
					throw new System.InvalidProgramException("For some reason, we can't get the location of " +
						"the executable that's creating a BestChat.ProtocolMgr.ProtocolMgr instance.  We're expecting"
						+ " protocol module DLLs to be in a subdirectory thereof.");
				System.IO.DirectoryInfo dirProtocolModuleLoc = new(System.IO.Path
					.Combine(strEntryAssemblyLoc, strProtocolModuleSubdirectory));

				if(dirProtocolModuleLoc.Exists)
				{
					foreach(System.IO.FileInfo fileCurProtocolModule in dirProtocolModuleLoc
							.GetFiles(strMaskForProtocolModules))
						AddNewProtocolModule(fileCurProtocolModule);
				}

				fsw = new(dirProtocolModuleLoc.FullName, strMaskForProtocolModules);

				fsw.Created += OnProtocolModuleFileCreated;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
			public const string strProtocolModuleSubdirectory = "Protocol Modules";

			public const string strMaskForProtocolModules = "*.Protocol Module.dll";
		#endregion

		#region Helper Types
			public interface IProtocolDef : ProtocolDef.IProtocolDef
			{
				Platform.Prefs.Data.AbstractChildMgr? ProtocolMgrForRootPrefObj
				{
					get;
				}

				Platform.Conversations.IGroupViewOrConversation? TopLevelViewGroupOrConversation
				{
					get;
				}

				bool GuiRecommended
				{
					get;
				}
			}
		#endregion

		#region Members
			private readonly System.IO.FileSystemWatcher fsw;

			private readonly System.Collections.Generic.Dictionary<string, IProtocolDef> mapNameToProtocolDefs =
				new();

			private readonly System.Collections.ObjectModel.ObservableCollection<IProtocolDef>
				ocUnsortedProtocolDefs = new();
		#endregion

		#region Properties
			public System.Collections.Generic.IReadOnlyDictionary<string, IProtocolDef> AllProtocolDefsByName =>
				mapNameToProtocolDefs;

			public System.Collections.Generic.IEnumerable<IProtocolDef> AllUnsortedProtocols =>
				ocUnsortedProtocolDefs;
		#endregion

		#region Methods
			private void AddNewProtocolModule(System.IO.FileInfo fileProtocolModule)
			{
				System.Reflection.Assembly assemblyCurProtocolModule = System.Reflection.Assembly
					.LoadFile(fileProtocolModule.FullName);

				foreach(System.Type typeCurProtocolInCurProtocolModule in assemblyCurProtocolModule
					.ExportedTypes.Where((System.Type typeCurProtocolInCurProtocolModule) =>
					typeCurProtocolInCurProtocolModule.GetInterface(nameof(IProtocolDef)) != null &&
					!typeCurProtocolInCurProtocolModule.IsAbstract && typeCurProtocolInCurProtocolModule
					.GetConstructor(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags
					.Instance, System.Array.Empty<System.Type>()) != null))
				{
					System.Reflection.ConstructorInfo? constructorDef = typeCurProtocolInCurProtocolModule
						.GetConstructor(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags
						.Instance, System.Array.Empty<System.Type>());

					if(constructorDef != null)
					{
						IProtocolDef protocolCurDef = (IProtocolDef)constructorDef.Invoke(null);

						if(mapNameToProtocolDefs.ContainsKey(protocolCurDef.Name))
						{
							// TODO: Log the event.  We already have a protocol with the same name.
							return;
						}

						mapNameToProtocolDefs[protocolCurDef.Name] = protocolCurDef;
						ocUnsortedProtocolDefs.Add(protocolCurDef);
					}
				}
			}
		#endregion

		#region Event Handlers
			private void OnProtocolModuleFileCreated(object objSender, System.IO.FileSystemEventArgs e) =>
				AddNewProtocolModule(new(e.FullPath));
		#endregion
	}
}