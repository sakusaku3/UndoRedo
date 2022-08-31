using System.Collections.Generic;

namespace UndoRedo
{
	public class InsertItemToCollectionCommand<T> : IUndoableCommand
	{
		private readonly IList<T> collection;
		private readonly T item;
		private readonly int index;

		public InsertItemToCollectionCommand(
			IList<T> collection,
			int index,
			T item)
		{
			this.collection = collection;
			this.index = index;
			this.item = item;
		}

		public void Execute() => this.collection.Insert(this.index, this.item);
		public void Undo() => this.collection.Remove(this.item);
		public void Redo() => this.collection.Insert(this.index, this.item);
	}
}
