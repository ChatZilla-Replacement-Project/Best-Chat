// Ignore Spelling: Ctnts

namespace BestChat.Platform.Conversations
{
	public abstract class AbstractGroupInlinePlaceHolder : PlaceHolder.IInlinePlaceHolder, System
		.ComponentModel.INotifyPropertyChanged
	{
		public AbstractGroupInlinePlaceHolder(in System.Collections.Generic.IEnumerable<PlaceHolder
			.IInlinePlaceHolder> ieCtnts) => llistCtnts = new System.Collections.Generic.List<PlaceHolder
			.IInlinePlaceHolder>(ieCtnts);

		/// <inheritdoc/>
		public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

		private System.Collections.Generic.List<PlaceHolder.IInlinePlaceHolder> llistCtnts;

		public System.Collections.Generic.IEnumerable<PlaceHolder.IInlinePlaceHolder> Ctnts
		{
			get => llistCtnts;

			protected set
			{
				llistCtnts = new(value);

				PropertyChanged?.Invoke(this, new(nameof(Ctnts)));
			}
		}

		public string AsText => string.Join("", llistCtnts);
	}
}