using System.Collections.Generic;
using System.Linq;

namespace UndoRedo
{
	public class InsertItemsToCollectionCommand<T> : IUndoableCommand
	{
		private readonly SequentialCommand commands; 

		public InsertItemsToCollectionCommand(
			IList<T> collection,
			int index,
			IEnumerable<T> items)
		{
			this.commands = new SequentialCommand(
				items.Select((x, i) => new InsertItemToCollectionCommand<T>(collection, i + index, x)));
		}

		public void Execute() => this.commands.Execute();
		public void Undo() => this.commands.Undo();
		public void Redo() => this.commands.Redo();
	}
}
