using System.Collections.Generic;

namespace UndoRedo
{
	public class RemoveItemFromCollectionCommand<T> : IUndoableCommand
	{
		private readonly IList<T> collection;
		private readonly T item;

		private int currentIndex;

		public RemoveItemFromCollectionCommand(
			IList<T> collection,
			T item)
		{
			this.collection = collection;
			this.item = item;
		}

		public void Execute()
		{
			this.currentIndex = this.collection.IndexOf(this.item);
			this.collection.Remove(this.item);
		}

		public void Undo() => this.collection.Insert(this.currentIndex, this.item);
		public void Redo() => this.collection.Remove(this.item);
	}
}
