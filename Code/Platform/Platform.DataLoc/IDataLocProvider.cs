namespace BestChat.Platform.DataLoc
{
	public interface IDataLocProvider
	{
		System.IO.DirectoryInfo LocalDataLoc
		{
			get;
		}
	}
}