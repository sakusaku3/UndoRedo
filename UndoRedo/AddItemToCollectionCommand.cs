using System.Collections.Generic;

namespace UndoRedo
{
	public class AddItemToCollectionCommand<T> : IUndoableCommand
	{
		private readonly IList<T> collection;
		private readonly T item;

		public AddItemToCollectionCommand(
			IList<T> collection,
			T item)
		{
			this.collection = collection;
			this.item = item;
		}

		public void Execute() => this.collection.Add(this.item);
		public void Undo() => this.collection.Remove(this.item);
		public void Redo() => this.collection.Add(this.item);
	}
}
